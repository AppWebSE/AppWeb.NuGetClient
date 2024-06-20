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

            Console.WriteLine($"Metadata count: {metaData.Count}");

            foreach(var version in packageVersions?.Versions)
            {
                Console.WriteLine($"version: {version}");
            }
            
            Console.WriteLine($"Manifest Id: {packageManifest?.Id}");

            Console.ReadLine();
        }
    }
}
