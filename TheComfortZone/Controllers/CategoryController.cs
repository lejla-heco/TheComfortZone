using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheComfortZone.DTO.Category;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;

namespace TheComfortZone.Controllers
{
    public class CategoryController : BaseCRUDController<DTO.Category.CategoryResponse, BaseSearchObject, DTO.Category.CategoryUpsertRequest, DTO.Category.CategoryUpsertRequest>
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService service) : base(service)
        {
            categoryService = service;
        }

        [Authorize(Roles = "Administrator,Employee")]
        public override CategoryResponse Insert([FromBody] CategoryUpsertRequest insert)
        {
            return base.Insert(insert);
        }

        [Authorize(Roles = "Administrator,Employee")]
        public override CategoryResponse Update(int id, [FromBody] CategoryUpsertRequest update)
        {
            return base.Update(id, update);
        }

        [HttpGet("categories-by-space-id/{id}")]
        [Authorize]
        public async Task<List<DTO.Category.CategoryResponse>> GetCategoriesBySpaceId(int id)
        {
            return await categoryService.GetCategoriesBySpaceId(id);
        }
    }
}
