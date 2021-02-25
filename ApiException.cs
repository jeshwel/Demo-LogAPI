using System;
using System.Net;

namespace Demo_LogAPI
{
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        //public ApiException(HttpStatusCode statusCode, string content)
        //{
        //    StatusCode = statusCode;
        //}
    }
}
