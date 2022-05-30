using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Utils;
using TheComfortZone.WINUI.Properties;
using TheComfortZone.WINUI.Utils;

namespace TheComfortZone.WINUI.Service
{
    public class BaseAPIService<T, TSearch, TInsert, TUpdate>
    {
        protected string resource = null;
        public string endpoint = Settings.Default.ApiURL;

        public BaseAPIService(string resource)
        {
            this.resource = resource;
        }

        public async Task<List<T>> Get(object search = null)
        {
            string url = $"{endpoint}{resource}";
            if (search != null)
            {
                url += "?";
                url += await search.ToQueryString();
            }
            return await url.WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password).GetJsonAsync<List<T>>();
        }

        public async Task<T> GetById(int id)
        {
            return await new Uri(endpoint)
                    .AppendPathSegment(resource)
                    .AppendPathSegment(id)
                    .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password).GetJsonAsync<T>();
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
                var stringBuilder = new StringBuilder(ex.Message);
                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
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
                var stringBuilder = new StringBuilder(ex.Message);
                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }
    }
}
