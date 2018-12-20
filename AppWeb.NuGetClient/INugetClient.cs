using AppWeb.NuGetClient.Models;
using System;
using System.Threading.Tasks;

namespace AppWeb.NuGetClient
{
    public interface INuGetClient : IDisposable
    {
        Task<NuGetPackageMetaData> GetPackageMetaDataAsync(string packageId);
        NuGetPackageMetaData GetPackageMetaData(string packageId);
    }
}
