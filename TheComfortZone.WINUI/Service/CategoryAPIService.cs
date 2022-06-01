using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Category;
using TheComfortZone.DTO.Utils;
using TheComfortZone.WINUI.Utils;

namespace TheComfortZone.WINUI.Service
{
    internal class CategoryAPIService : BaseAPIService<CategoryResponse, BaseSearchObject, CategoryUpsertRequest, CategoryUpsertRequest>
    {
        private const string API_ROUTE = "Category";
        public CategoryAPIService() : base(API_ROUTE)
        {
        }

        public async Task<List<CategoryResponse>> GetCategoriesBySpaceId(int id)
        {
            return await new Uri(endpoint)
                .AppendPathSegments(resource, "categories-by-space-id", id)
                .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password)
                .GetJsonAsync<List<CategoryResponse>>();
        }
    }
}
