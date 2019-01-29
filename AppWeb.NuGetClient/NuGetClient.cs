using AppWeb.NuGetClient.Models;
using AppWeb.NuGetClient.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AppWeb.NuGetClient
{
    public class NuGetClient : INuGetClient
    {
        private readonly string _baseUrl = "https://api.nuget.org";
        private readonly IHttpService _httpService;

        public NuGetClient()
        {
            _httpService = new HttpService(_baseUrl);
        }
        
        // https://docs.microsoft.com/en-us/nuget/api/registration-base-url-resource
        // Example endpoint: https://api.nuget.org/v3/registration3/appweb.pagestatusmonitor/index.json
        // lowered_id Example: appweb.pagestatusmonitor
        public async Task<NuGetPackageMetaData> GetPackageMetaDataAsync(string packageId)
        {
            if (string.IsNullOrEmpty(packageId))
            {
                throw new ArgumentNullException(nameof(packageId));
            }

            var loweredId = packageId.ToLower();
            var endpoint = $"/v3/registration3/{loweredId}/index.json";
            return await _httpService.GetByJsonAsync<NuGetPackageMetaData>(endpoint);
        }

        public NuGetPackageMetaData GetPackageMetaData(string packageId)
        {
            if (string.IsNullOrEmpty(packageId))
            {
                throw new ArgumentNullException(nameof(packageId));
            }

            return GetPackageMetaDataAsync(packageId).Result;
        }
               
        public async Task<NuGetPackageVersions> GetPackageVersionsAsync(string packageId)
        {
            if (string.IsNullOrEmpty(packageId))
            {
                throw new ArgumentNullException(nameof(packageId));
            }

            var loweredId = packageId.ToLower();
            var endpoint = $"/v3-flatcontainer/{loweredId}/index.json";
            return await _httpService.GetByJsonAsync<NuGetPackageVersions>(endpoint);
        }

        public NuGetPackageVersions GetPackageVersions(string packageId)
        {
            if (string.IsNullOrEmpty(packageId))
            {
                throw new ArgumentNullException(nameof(packageId));
            }

            return GetPackageVersionsAsync(packageId).Result;
        }

        public async Task<NuGetPackageManifest> GetPackageManifestAsync(string packageId, string version = null)
        {
            if (string.IsNullOrEmpty(packageId))
            {
                throw new ArgumentNullException(nameof(packageId));
            }

            if(version == null)
            {
                var versions = await GetPackageVersionsAsync(packageId);                
                version = versions?.Versions?.LastOrDefault();
            }

            if(version == null)
            {
                throw new ArgumentException(nameof(packageId));
            }

            var loweredId = packageId.ToLower();
            var endpoint = $"/v3-flatcontainer/{loweredId}/{version}/{loweredId}.nuspec";

            var nuGetPackageManifestRoot = await _httpService.GetByXmlAsync<NuGetPackageManifestRoot>(endpoint);

            return nuGetPackageManifestRoot?.Manifest;
        }

        public NuGetPackageManifest GetPackageManifest(string packageId, string version = null)
        {
            if (string.IsNullOrEmpty(packageId))
            {
                throw new ArgumentNullException(nameof(packageId));
            }
            
            return GetPackageManifestAsync(packageId, version).Result;
        }

        public void Dispose()
        {
            _httpService.Dispose();
        }
    }
}
