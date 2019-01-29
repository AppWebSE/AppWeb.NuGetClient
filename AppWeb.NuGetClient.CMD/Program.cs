using System;

namespace AppWeb.NuGetClient.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("started");

            INuGetClient nugetClient = new NuGetClient();

            var metaData = nugetClient.GetPackageMetaDataAsync("AppWeb.NuGetClient").Result;
            var packageVersions = nugetClient.GetPackageVersionsAsync("AppWeb.NuGetClient").Result;
            var packageManifest = nugetClient.GetPackageManifestAsync("AppWeb.PageStatusMonitor").Result;
            //var manifest2 = nugetClient.GetPackageManifestAsync("AppWeb.NuGetClient", "0.1.2").Result;

            Console.WriteLine($"Metadata count: {metaData.Count}");

            foreach(var version in packageVersions?.Versions)
            {
                Console.WriteLine($"version: {version}");
            }
            
            Console.WriteLine($"Manifest1 Id: {packageManifest?.Id}");
            //Console.WriteLine($"Manifest2 RepositoryUrl: {manifest2?.Repository?.Url}");

            Console.ReadLine();
        }
    }
}
