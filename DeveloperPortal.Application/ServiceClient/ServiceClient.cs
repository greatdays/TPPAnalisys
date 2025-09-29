using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.DataAccess.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Http.Headers;
using System.Configuration;



namespace DeveloperPortal.Application.ServiceClient
{
    public class ServiceClient
    {
        private static IConfiguration _config;
        public ServiceClient(IConfiguration configuration)
        {
            _config = configuration;
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

        //public static string BaseApiURL = AppConfiguration.GetConfigValue("BaseApiURL");
        //public static string BasePropApiURL = AppConfiguration.GetConfigValue("BasePropApiURL");
        //private static JavaScriptSerializer serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue, RecursionLimit = 100 }; //unused statement

        /// <summary>
        /// Action to call service
        /// </summary>
        /// <returns>
        /// Request object
        /// </returns>
        public T CreateRequest<T>(object requestObject, string URL, ActionType actionType)
        {
            try
            {
                string serializeqObject = string.Empty;
                var enableTLS  = _config["EnableTLS"];
                // security protocol type.
                if (Convert.ToBoolean(enableTLS))
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
                    serializeqObject = JsonConvert.SerializeObject(requestObject); //serializer.Serialize(requestObject);
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
               

                using HttpClient httpClient = new HttpClient();

                HttpRequestMessage requestMessage = new HttpRequestMessage();
                switch (actionType)
                {
                    case ActionType.POST:
                        requestMessage.Method = HttpMethod.Post;
                        break;
                    case ActionType.PUT:
                        requestMessage.Method = HttpMethod.Put;
                        break;
                    case ActionType.DELETE:
                        requestMessage.Method = HttpMethod.Delete;
                        break;
                    case ActionType.GET:
                        requestMessage.Method = HttpMethod.Get;
                        break;
                    default:
                        break;
                }

                StringContent content = new StringContent(serializeqObject, Encoding.UTF8, "application/json");
                content.Headers.ContentLength = serializeqObject.Length;

                //WebRequest theRequest = WebRequest.Create(URL);

                //theRequest.Method = actionType.ToString();
                TimeSpan tsTimeout = new TimeSpan();
                //theRequest.Timeout = Convert.ToInt32(ConfigurationManager.AppSettings["ServiceRequestTimeout"];
                TimeSpan.TryParse(ConfigurationManager.AppSettings["ServiceRequestTimeout"], out tsTimeout);
                if (tsTimeout != TimeSpan.Zero)
                {
                    httpClient.Timeout = tsTimeout;
                }
                requestMessage.RequestUri = new Uri(URL);
                requestMessage.Content = content;

                //theRequest.ContentType = "application/json";
                //theRequest.ContentLength = serializeqObject.Length;

                if (actionType == ActionType.POST || actionType == ActionType.PUT || actionType == ActionType.DELETE)
                {
                    /*Stream requestStream = theRequest.GetRequestStream();

                    requestStream.Write(Encoding.ASCII.GetBytes(serializeqObject), 0, serializeqObject.Length);
                    requestStream.Close();*/

                }
                
                HttpResponseMessage response = httpClient.Send(requestMessage);
                response.EnsureSuccessStatusCode();
                
                HttpStatusCode status = response.StatusCode;

                //HttpWebResponse response = (HttpWebResponse)theRequest.GetResponse();
                //HttpStatusCode status = response.StatusCode;

                string result = string.Empty;
                if (status == HttpStatusCode.OK)
                {
                    //string responseBody = response.Content.ReadAsStringAsync().Result;
                    Stream responseBody = response.Content.ReadAsStream();
                    using StreamReader streamReader = new StreamReader(responseBody);
                    result = streamReader.ReadToEnd();

                    /*using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        result = reader.ReadToEnd();
                    }*/
                }
                if (result == "null" || string.IsNullOrWhiteSpace(result))
                {
                    return default;
                }

                JObject jResult = JsonConvert.DeserializeObject<JObject>(result);

                T resultObj = JsonConvert.DeserializeObject<T>(jResult.ToString()); //JsonConvert.DeserializeObject<T>(jResult.SelectToken("Result").ToString());

                return resultObj;
            }
            catch (WebException ex)
            {
                string message = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                throw ex;
            }
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
    }
}
