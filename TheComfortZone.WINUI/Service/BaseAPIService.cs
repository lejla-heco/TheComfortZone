using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TheComfortZone.DTO.Utils;
using TheComfortZone.WINUI.Properties;
using TheComfortZone.WINUI.Utils;

namespace TheComfortZone.WINUI.Service
{
    public class BaseAPIService<T, TSearch, TInsert, TUpdate> : BaseReadAPIService<T, TSearch> where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        public BaseAPIService(string resource) : base(resource)
        {
        }

        public async Task<T> Post(TInsert request)
        {
            try
            {
                return await new Uri(endpoint)
                   .AppendPathSegment(resource)
                   .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password)
                   .PostJsonAsync(request)
                   .ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();
                return ExceptionHandler.HandleException<T>(errors);
            }
        }

        public async Task<T> Put(int id, TUpdate request)
        {
            try
            {
                return await new Uri(endpoint)
                   .AppendPathSegment(resource)
                   .AppendPathSegment(id)
                   .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password)
                   .PutJsonAsync(request)
                   .ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();
                return ExceptionHandler.HandleException<T>(errors);
            }
        }

        public async Task<string> Delete(int id)
        {
            try
            {
                return await new Uri(endpoint)
                   .AppendPathSegment(resource)
                   .AppendPathSegment(id)
                   .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password)
                   .DeleteAsync()
                   .ReceiveString();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();
                return ExceptionHandler.HandleException<string>(errors);
            }
        }
    }
}
