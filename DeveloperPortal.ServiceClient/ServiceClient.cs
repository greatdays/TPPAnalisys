using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace DeveloperPortal.ServiceClient
{
    public class ServiceClient
    {
        public IConfiguration _config;
        public ServiceClient(IConfiguration config)
        {
            _config = config;
        }
        public T CreateRequest<T>(object requestObject, string URL, ActionType actionType)
        {
            string serializeqObject = string.Empty;

            bool canEnableTLS = false;
            bool.TryParse(_config["EnableTLS"], out canEnableTLS);
            // security protocol type.
            if (canEnableTLS)
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            if (actionType == ActionType.GET)
            {
                string queryString = GetQueryString(requestObject);

                if (!string.IsNullOrEmpty(queryString))
                {
                    URL = URL + "?" + queryString;
                }
            }
            else
            {
                serializeqObject = JsonConvert.SerializeObject(requestObject)
                    .Replace("’", "'"); //serializer.Serialize(requestObject);
            }

            string previousURL = URL;
            if (URL.ToLower().Contains("username"))
            {
                string[] separateURL = URL.Split('?');
                string[] querpara = separateURL[1].Split('&');
                string updatedUserName = string.Empty;
                string updatedUrl = string.Empty;
                for (int i = 0; i < querpara.Count(); i++)
                {
                    if (querpara[i].ToLower().Contains("username") && querpara[i].ToLower().Contains("+"))
                    {
                        string[] qParaList = querpara[i].Split('=');
                        updatedUserName = qParaList[1].Replace("+", "%2B");
                        updatedUrl = URL.Replace(querpara[i], (qParaList[0] + "=" + updatedUserName));
                        break;
                    }

                }
                URL = string.IsNullOrEmpty(updatedUrl) ? previousURL : updatedUrl;
            }
            WebRequest theRequest = WebRequest.Create(URL);
            theRequest.Method = actionType.ToString();
            theRequest.Timeout = Convert.ToInt32(ConfigurationManager.AppSettings["ServiceRequestTimeout"]);
            theRequest.ContentType = "application/json";
            theRequest.ContentLength = serializeqObject.Length;

            if (actionType == ActionType.POST || actionType == ActionType.PUT || actionType == ActionType.DELETE)
            {
                Stream requestStream = theRequest.GetRequestStream();

                requestStream.Write(Encoding.ASCII.GetBytes(serializeqObject), 0, serializeqObject.Length);
                requestStream.Close();
            }

            HttpWebResponse response = (HttpWebResponse)theRequest.GetResponse();
            HttpStatusCode status = response.StatusCode;

            string result = string.Empty;
            if (status == HttpStatusCode.OK)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    result = reader.ReadToEnd();
                }
            }

            JObject jResult = JsonConvert.DeserializeObject<JObject>(result);

            T returnResult = JsonConvert.DeserializeObject<T>((jResult != null) ? jResult.ToString() : ""); //JsonConvert.DeserializeObject<T>(jResult.SelectToken("Result").ToString());

            return returnResult;
        }

        /// <summary>
        /// Action to get query string values
        /// </summary>
        /// <returns>
        /// Query String
        /// </returns>
        public static string GetQueryString(object obj)
        {
            if (obj == null)
                return string.Empty;

            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + System.Web.HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            // queryString will be set to "Id=1&State=26&Prefix=f&Index=oo
            return String.Join("&", properties.ToArray());
        }

        /// <summary>
        /// Enum for action type
        /// </summary>
        /// <returns>
        /// Enum
        /// </returns>
        public enum ActionType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
