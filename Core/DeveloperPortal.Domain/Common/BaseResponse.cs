using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Models.Common
{
    /// <summary>
    /// web api response.
    /// </summary>
    public class BaseResponse
    {
        public HttpStatusCode ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public ErrorResult ErrorResult { get; set; }
        public object Response { get; set; }
    }
    public class BaseResponse1<T>
    {
        public HttpStatusCode ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public ErrorResult ErrorResult { get; set; }
        public T Response { get; set; }
    }


    /// <summary>
    /// web api error result.
    /// </summary>
    public class ErrorResult
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
