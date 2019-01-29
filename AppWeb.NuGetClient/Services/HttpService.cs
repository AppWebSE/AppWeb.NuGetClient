using AppWeb.NuGetClient.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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

        public async Task<T> GetByJsonAsync<T>(string endpoint)
        {
            try
            {
                var responseString = await _httpClient.GetStringAsync(_baseUrl + endpoint);
                
                var result = JsonConvert.DeserializeObject<T>(responseString);

                return result;
            }
            catch (Exception e)
            {
                throw new HttpServiceException("HttpGet failed in HttpService.GetByJsonAsync", e);
            }
        }

        public async Task<T> GetByXmlAsync<T>(string endpoint)
        {
            try
            {
                var responseStream= await _httpClient.GetStreamAsync(_baseUrl + endpoint);

                XmlSerializer mySerializer = new XmlSerializer(typeof(T));

                return (T)mySerializer.Deserialize(responseStream);
            }
            catch (Exception e)
            {
                throw new HttpServiceException($"HttpGet failed in HttpService.GetByXmlAsync", e);
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
