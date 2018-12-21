# AppWeb.NuGetClient
📦 .Net Standard package with a NuGet client with typed models for obtaining package meta data.

## Note
Work is in progress, this can be seen as a work in progress. 

Project url: https://appweb.se/en/packages/nuget-client

## Installation
The package can be installed through nuget https://www.nuget.org/packages/AppWeb.NuGetClient/
```nuget
Install-Package AppWeb.NuGetClient
```

## Example usage
```csharp
INuGetClient client = new NuGetClient();
var packageMetaData = await client.GetPackageMetaDataAsync("AppWeb.PageStatusMonitor");
```