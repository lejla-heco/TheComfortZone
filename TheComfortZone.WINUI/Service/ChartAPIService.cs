using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Charts;
using TheComfortZone.WINUI.Properties;
using TheComfortZone.WINUI.Utils;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.WINUI.Service
{
    public class ChartAPIService
    {
        protected string resource = "Chart";
        public string endpoint = Settings.Default.ApiURL;

        public async Task<List<DTO.Charts.LineChartListResponse>> GetLineChartData(string space)
        {
            try
            {
                return await new Uri(endpoint)
                    .AppendPathSegments(resource, "best-selling-items", space)
                    .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password)
                    .GetJsonAsync<List<DTO.Charts.LineChartListResponse>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();
                return ExceptionHandler.HandleException<List<DTO.Charts.LineChartListResponse>>(errors);
            }
        }

        public async Task<List<SalesResponse>> GetSalesByPeriod(DateRangeSearchRequest search = null)
        {
            try
            {
                string url = new Uri(endpoint)
                    .AppendPathSegment(resource)
                    .AppendPathSegment("sales-by-period");
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }
                return await url
                    .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password)
                    .GetJsonAsync<List<SalesResponse>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();
                return ExceptionHandler.HandleException<List<SalesResponse>>(errors);
            }
        }

        public async Task<List<PieChartEmployeeResponse>> GetIncomePerEmployee(DateRangeSearchRequest search = null)
        {
            try
            {
                string url = new Uri(endpoint)
                    .AppendPathSegment(resource)
                    .AppendPathSegment("income-per-employee");
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }
                return await url
                    .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password)
                    .GetJsonAsync<List<PieChartEmployeeResponse>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();
                return ExceptionHandler.HandleException<List<PieChartEmployeeResponse>>(errors);
            }
        }

        public async Task<List<PieChartCustomerResponse>> GetLoyalCustomers()
        {
            try
            {
                return await new Uri(endpoint)
                    .AppendPathSegment(resource)
                    .AppendPathSegment("loyal-customers")
                    .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password)
                    .GetJsonAsync<List<PieChartCustomerResponse>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();
                return ExceptionHandler.HandleException<List<PieChartCustomerResponse>>(errors);
            }
        }
    }
}
