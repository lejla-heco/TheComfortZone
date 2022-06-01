using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.WINUI.Properties;
using TheComfortZone.WINUI.Utils;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.WINUI.Service
{
    public class BaseReadAPIService<T, TSearch> where T : class where TSearch : class
    {
        protected string resource = null;
        public string endpoint = Settings.Default.ApiURL;

        public BaseReadAPIService(string resource)
        {
            this.resource = resource;
        }

        public async Task<List<T>> Get(object search = null)
        {
            try
            {
                string url = $"{endpoint}{resource}";
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }
                return await url.WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password)
                    .GetJsonAsync<List<T>>();
            }
            catch (Exception ex)
            {
                var stringBuilder = new StringBuilder(ex.Message);
                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(List<T>);
            }
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                return await new Uri(endpoint)
                        .AppendPathSegment(resource)
                        .AppendPathSegment(id)
                        .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password).GetJsonAsync<T>();
            }
            catch (Exception ex)
            {
                var stringBuilder = new StringBuilder(ex.Message);
                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }
    }
}
