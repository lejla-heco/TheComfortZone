using AutoMapper;
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

namespace TheComfortZone.SERVICES.CORE.Implementation
{
    public class CategoryService : BaseCRUDService<DTO.Category.CategoryResponse, DAO.Model.Category, BaseSearchObject, DTO.Category.CategoryUpsertRequest, DTO.Category.CategoryUpsertRequest>, ICategoryService
    {
        public CategoryService(TheComfortZoneContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<CategoryResponse>> GetCategoriesBySpaceId(int id)
        {
            if (context.Spaces.FirstOrDefault(s => s.SpaceId == id) == null)
            {
                throw new UserException("Space with specified ID does not exist!");
            }
            var entities = context.Categories.Where(c => c.SpaceId == id);
            return mapper.Map<List<CategoryResponse>>(entities.ToList());
        }
    }
}
