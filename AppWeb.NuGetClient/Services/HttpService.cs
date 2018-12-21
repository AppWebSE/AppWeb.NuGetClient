using AppWeb.NuGetClient.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppWeb.NuGetClient.Services
{
    class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        public HttpService(string baseUrl)
        {
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));

            _httpClient = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            try
            {
                var responseString = await _httpClient.GetStringAsync(_baseUrl + endpoint);
                
                var result = JsonConvert.DeserializeObject<T>(responseString);

                return result;
            }
            catch (Exception e)
            {
                throw new HttpServiceException("HttpGet failed in HttpService", e);
            }
        }
        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
