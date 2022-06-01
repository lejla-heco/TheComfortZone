using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.SERVICES.API
{
    public interface ICategoryService : ICRUDService<DTO.Category.CategoryResponse, BaseSearchObject, DTO.Category.CategoryUpsertRequest, DTO.Category.CategoryUpsertRequest>
    {
        public Task<List<DTO.Category.CategoryResponse>> GetCategoriesBySpaceId(int id);
    }
}
