using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppWeb.NuGetClient.Services
{
    interface IHttpService : IDisposable
    {
        Task<T> GetAsync<T>(string endpoint);
    }
}
