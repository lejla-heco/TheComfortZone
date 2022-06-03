using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Category;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;
using TheComfortZone.SERVICES.CORE.Utils;
using TheComfortZone.SERVICES.DAO;
using TheComfortZone.SERVICES.DAO.Model;

namespace TheComfortZone.SERVICES.CORE.Implementation
{
    public class CategoryService : BaseCRUDService<DTO.Category.CategoryResponse, DAO.Model.Category, BaseSearchObject, DTO.Category.CategoryUpsertRequest, DTO.Category.CategoryUpsertRequest>, ICategoryService
    {
        public CategoryService(TheComfortZoneContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Category> IncludeList(IQueryable<Category> query)
        {
            return query.Include(c => c.Space);
        }

        public async Task<List<CategoryResponse>> GetCategoriesBySpaceId(int id)
        {
            /** VALIDATION **/
            if (context.Spaces.Find(id) == null)
                throw new UserException("Space with specified ID does not exist!");

            var entities = context.Categories.Where(c => c.SpaceId == id);
            return mapper.Map<List<CategoryResponse>>(entities.ToList());
        }

        /** VALIDATION **/
        public override void ValidateInsert(CategoryUpsertRequest insert)
        {
            if (context.Spaces.Find(insert.SpaceId) == null)
                throw new UserException("Space with specified ID does not exist!");
        }
        public override void ValidateUpdate(int id, CategoryUpsertRequest update)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool exception = false;
            if (context.Categories.Find(id) == null)
            {
                exception = true;
                stringBuilder.Append("Category with specified ID does not exist!\n");
            }
            if (context.Spaces.Find(update.SpaceId) == null)
            {
                exception = true;
                stringBuilder.Append("Space with specified ID does not exist!");
            }
            if (exception)
            {
                throw new UserException(stringBuilder.ToString());
            }
        }
    }
}
