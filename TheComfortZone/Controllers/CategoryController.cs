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

        [HttpGet("categories-by-space-id/{id}")]
        public async Task<List<DTO.Category.CategoryResponse>> GetCategoriesBySpaceId(int id)
        {
            return await categoryService.GetCategoriesBySpaceId(id);
        }
    }
}
