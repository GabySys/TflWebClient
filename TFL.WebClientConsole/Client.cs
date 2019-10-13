using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TFL.WebClientConsole
{
    public class Client
    {
        IClient clientWrapper;

        public Client(IClient clientWrapper)
        {
            this.clientWrapper = clientWrapper;
        }

        public async Task<RoadCorridor> Run(string roadId, string appId, string appKey)
        {
            HttpResponseMessage response = await clientWrapper.GetAsync(roadId, appId, appKey);

            if (response.IsSuccessStatusCode)
            {
                List<RoadCorridor> roadInfo = await GetContentFromJsonAsync<List<RoadCorridor>>(response);
                return roadInfo[0];
            }
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                ApiError error = await GetContentFromJsonAsync<ApiError>(response);
                ApiException ex = new ApiException(error.Message)
                {
                    ApiError = error
                };
                throw ex;
            }
            else
            {
                throw new Exception($"Unexpected Error. Status code: {response.StatusCode}");
            }
        }

        private async Task<T> GetContentFromJsonAsync<T>(HttpResponseMessage response)
        {
            string content = await response.Content.ReadAsStringAsync();
            T result = JsonConvert.DeserializeObject<T>(content);
            return result;
        }
    }
}
