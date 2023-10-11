using Microsoft.Extensions.Configuration;

namespace DeveloperPortal.ServiceClient
{
    internal class WebApiConstant
    {
        internal static string GetLookupLists = "User/LookupList";
        public IConfiguration _config;

        public WebApiConstant(IConfiguration config)
        {
            _config = config;
        }
        public string GetConfigData(string key)
        {
            //            baseUrl = string.Format("{0}", _config["AAHRApiSettings:URL"]);
            return _config["AAHRApiSettings:URL"];
        }
    }
}