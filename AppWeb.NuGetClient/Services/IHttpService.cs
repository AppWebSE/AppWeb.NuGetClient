using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppWeb.NuGetClient.Services
{
    interface IHttpService : IDisposable
    {
        Task<T> GetByJsonAsync<T>(string endpoint);
        Task<T> GetByXmlAsync<T>(string endpoint);
    }
}
