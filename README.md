# AppWeb.NuGetClient
📦 .Net Standard package with a NuGet client with typed models for obtaining meta data, versions, and manifest of a NuGet package.

## Note
Work is in progress, this can be seen as a work in progress and api's might be changed a bit until we reach a stable version 1.0.0

Project url: https://appweb.se/en/packages/nuget-client

## Installation
The package can be installed through nuget https://www.nuget.org/packages/AppWeb.NuGetClient/
```nuget
Install-Package AppWeb.NuGetClient
```

## Example usage
```csharp
INuGetClient client = new NuGetClient();
// Get's a nuget package available versions
var packageVersions = await nugetClient.GetPackageVersionsAsync("AppWeb.NuGetClient");
// Get's a nuget package 
var packageManifest = await nugetClient.GetPackageManifestAsync("AppWeb.NuGetClient");
```