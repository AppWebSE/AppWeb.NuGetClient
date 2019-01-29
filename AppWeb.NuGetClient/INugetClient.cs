using AppWeb.NuGetClient.Models;
using System;
using System.Threading.Tasks;

namespace AppWeb.NuGetClient
{
    public interface INuGetClient : IDisposable
    {
        Task<NuGetPackageMetaData> GetPackageMetaDataAsync(string packageId);
        NuGetPackageMetaData GetPackageMetaData(string packageId);
               
        Task<NuGetPackageVersions> GetPackageVersionsAsync(string packageId);
        NuGetPackageVersions GetPackageVersions(string packageId);

        Task<NuGetPackageManifest> GetPackageManifestAsync(string packageId, string verison = null);
        NuGetPackageManifest GetPackageManifest(string packageId, string verison = null);
    }
}
