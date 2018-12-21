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

            Console.WriteLine(metaData.Count);

            Console.ReadLine();
        }
    }
}
