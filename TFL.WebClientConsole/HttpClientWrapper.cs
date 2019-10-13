using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TFL.WebClientConsole
{
    public interface IClient
    {
        Task<HttpResponseMessage> GetAsync(string controller, string appId, string appKey);
    }

    public class HttpClientWrapper : IClient
    {
        private string url;

        public HttpClientWrapper(string url = "https://api.tfl.gov.uk/road/")
        {
            this.url = url;
        }

        public async Task<HttpResponseMessage> GetAsync(string controller, string appId, string appKey)
        {
            using (var client = new HttpClient())
            {
                UriBuilder urlParams = new UriBuilder(url + controller);
                urlParams.Query = $"app_id={appId}&app_key={appKey}";
                HttpResponseMessage response = await client.GetAsync(urlParams.Uri);
                return response;
            }
        }
    }
}