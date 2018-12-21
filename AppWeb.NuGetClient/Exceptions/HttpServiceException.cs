using System;

namespace AppWeb.NuGetClient.Exceptions
{
    public class HttpServiceException : Exception
    {
        public HttpServiceException() : base() { }

        public HttpServiceException(string message) : base(message) { }

        public HttpServiceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
