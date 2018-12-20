using AppWeb.NuGetClient.Models;
using AppWeb.NuGetClient.Services;
using System;
using System.Threading.Tasks;

namespace AppWeb.NuGetClient
{
    public class NugetClient : INuGetClient
    {
        private readonly string _baseUrl = "https://api.nuget.org/v3";
        private readonly IHttpService _httpService;

        public NugetClient()
        {
            _httpService = new HttpService(_baseUrl);
        }
        
        // https://docs.microsoft.com/en-us/nuget/api/registration-base-url-resource
        // Example endpoint: https://api.nuget.org/v3/registration3/appweb.pagestatusmonitor/index.json
        // lowered_id Example: appweb.pagestatusmonitor
        public async Task<NuGetPackageMetaData> GetPackageMetaDataAsync(string packageId)
        {
            var loweredId = packageId.ToLower();
            return await _httpService.GetAsync<NuGetPackageMetaData>($"/registration3/{loweredId}/index.json");
        }

        public NuGetPackageMetaData GetPackageMetaData(string packageId)
        {
            return GetPackageMetaDataAsync(packageId).Result;
        }

        public void Dispose()
        {
            _httpService.Dispose();
        }
    }
}
