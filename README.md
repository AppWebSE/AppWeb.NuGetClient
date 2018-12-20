# AppWeb.NuGetClient
📦 .Net Standard package with a NuGet client with typed models for obtaining package meta data.

## Note
Work is in progress, this can be seen as a work in progress. 

A package will soon be pushed to the NuGet feed and then we will provide installation instructions.

## Example usage
```csharp
INuGetClient client = new INuGetClient();
var packageMetaData = await client.GetPackageMetaDataAsync("AppWeb.PageStatusMonitor");
```