using AppWeb.NuGetClient.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
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
                var xml = await _httpClient.GetStringAsync(_baseUrl + endpoint);

                xml = RemoveNameSpaceTagFromXml(xml);

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));                
                using (TextReader textReader = new StringReader(xml))
                {
                    return (T)xmlSerializer.Deserialize(textReader);
                }
            }
            catch (Exception e)
            {
                throw new HttpServiceException($"HttpGet failed in HttpService.GetByXmlAsync", e);
            }
        }

        private static string RemoveNameSpaceTagFromXml(string xml)
        {
            if (!string.IsNullOrEmpty(xml) && xml.Contains("xmlns"))
            {
                xml = Regex.Replace(xml, @"(xmlns:?[^=]*=[""][^""]*[""])", "");
            }
            return xml;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
