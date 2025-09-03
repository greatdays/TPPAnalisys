using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;

namespace HCIDLA.ServiceClient.TemplateManagement
{
    public class Template
    {
        private static JavaScriptSerializer serializer = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue, RecursionLimit = 100 };

        public static byte[] GenerateDocument<T>(string templateName, T data, string webAPIURL, bool useFakeTMS = false)
        {
            byte[] file = null;
            if (useFakeTMS)
            {
                file = GenerateFakePDF(data);
            }
            else
            {
                //Create request data from template data object
                StringBuilder requestData = new StringBuilder();

                requestData.Append("[[");
                foreach (var property in data.GetType().GetProperties())
                {
                    string propName = string.Empty;
                    var attribs = (DescriptionAttribute[])property.GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (attribs != null && attribs.Length > 0)
                    {
                        propName = attribs[0].Description;  //there is a description attrib
                    }
                    else
                        propName = property.Name;

                    requestData.Append("{\"Name\":\"" + propName + "\",\"Value\":\"" + Convert.ToString(property.GetValue(data)) + "\"},");
                }
                requestData.Append("{\"Name\":\"TemplateName\",\"Value\":\"" + (templateName.Contains(".dotx") ? templateName : templateName) + ".dotx" + "\"}");
                requestData.Append("]]");

                //Call TMS service to generate document.
                //TMS.ITemplate template = new TMS.TemplateClient();
                //file = template.GetTemplate(requestData.ToString());

                using (var clients = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip }))
                {
                    clients.BaseAddress = new Uri(webAPIURL);
                    var postTask = clients.PostAsJsonAsync("Template", requestData.ToString());
                    postTask.Wait();

                    var results = postTask.Result;

                    if (results.IsSuccessStatusCode)
                    {
                        var readTask = results.Content.ReadAsAsync<byte[]>();
                        readTask.Wait();
                        file = readTask.Result;
                    }
                }

            }

            return file;
        }

        private static byte[] GenerateFakePDF<T>(T data)
        {
            byte[] file = null;
            StringBuilder requestData = new StringBuilder();
            foreach (var property in data.GetType().GetProperties())
            {
                requestData.Append(property.Name + ":" + Convert.ToString(property.GetValue(data)) + "<br/>");
            }

            StringReader sr = new StringReader(requestData.ToString());

            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();

                htmlparser.Parse(sr);
                pdfDoc.Close();

                file = memoryStream.ToArray();
                memoryStream.Close();
            }
            return file;
        }

    }
}
