using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Designer;
using TheComfortZone.DTO.Utils;
using TheComfortZone.WINUI.Utils;

namespace TheComfortZone.WINUI.Service
{
    public class DesignerAPIService : BaseAPIService<DTO.Designer.DesignerResponse, BaseSearchObject, DTO.Designer.DesignerUpsertRequest, DTO.Designer.DesignerUpsertRequest>
    {
        private const string API_ROUTE = "Designer";
        public DesignerAPIService() : base(API_ROUTE)
        {
        }

        public async Task<List<DesignerResponse>> GetDesignersWithCollectionData()
        {
            try
            {
                return await new Uri(endpoint)
                    .AppendPathSegments(resource, "designers-with-collections")
                    .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password)
                    .GetJsonAsync<List<DesignerResponse>>();
            }
            catch (FlurlHttpException ex)
            {
                var stringBuilder = new StringBuilder(ex.Message);
                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(List<DesignerResponse>);
            }
        }
    }
}
