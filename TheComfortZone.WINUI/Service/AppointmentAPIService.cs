using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Appointment;
using TheComfortZone.WINUI.Utils;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.WINUI.Service
{
    public class AppointmentAPIService : BaseAPIService<AppointmentResponse, AppointmentSearchRequest, AppointmentInsertRequest, AppointmentUpdateRequest>
    {
        private const string API_ROUTE = "Appointment";
        public AppointmentAPIService() : base(API_ROUTE)
        {
        }

        public async Task<List<AppointmentResponse>> GetAppointmentsByEmployeeId(int id, object search = null)
        {
            try
            {
                string url = new Uri(endpoint)
                    .AppendPathSegments(resource, "appointments-by-employee", id);

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url
                    .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password)
                    .GetJsonAsync<List<AppointmentResponse>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();
                return ExceptionHandler.HandleException<List<AppointmentResponse>>(errors);
            }
        }
    }
}
