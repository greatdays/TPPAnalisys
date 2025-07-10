using DeveloperPortal.Models;
using DeveloperPortal.Models.PlanReview;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.ServiceClient
{
    public class AAHRServiceClient
    {

        public static FolderModel GetFolderData(string baseAddress, string driveID, string folderName)
        {
            // 🧼 Make sure folder name is URL-encoded
            string encodedFolderName = Uri.EscapeDataString(folderName);

            // ✅ Combine full URL
            string fullUrl = $"{baseAddress.TrimEnd('/')}/api/GoogleDrive/GetFolderData?folderName={encodedFolderName}&driveID={driveID}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsJsonAsync(fullUrl, new object()).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    if (result != null && result!= string.Empty)
                    {
                        var folderModelJson = JsonConvert.DeserializeObject(result)?.ToString();
                        return JsonConvert.DeserializeObject<FolderModel>(folderModelJson);
                    }
                    else
                        return new FolderModel(); ;
                        
                }
                response.Dispose();
                response.Headers.ConnectionClose = true;
                return new FolderModel();
            }
        }

        public static string CreateFolder(string baseAddress, string driveID, string folderName, string parentFolderName)
        {
            var parameter = "?newFolderName=" + folderName.Trim() + "&parentFolderName=" + parentFolderName + "&driveID=" + driveID;
            var url = AAHRServiceConstant.CreateFolder + parameter;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;
                response = client.PostAsJsonAsync(url, new object()).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
                response.Dispose();
                response.Headers.ConnectionClose = true;
                return "";
            }
        }

        public static string UploadFiel(string baseAddress, string driveID, string folderName, IFormFile file, string filteType)
        {
            /* string encodedFolderName = Uri.EscapeDataString(folderName);
             string fullUrl = $"{baseAddress.TrimEnd('/')}/{AAHRServiceConstant.UploadFile}?folderName={Uri.EscapeDataString(folderName)}&driveID={Uri.EscapeDataString(driveID)}";
             using (HttpClient client = new HttpClient())
             {
                 client.BaseAddress = new Uri(baseAddress);
                 client.DefaultRequestHeaders.Accept.Clear();
                 client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(filteType));

                 HttpResponseMessage response = client.PostAsJsonAsync(fullUrl, file).Result;
                 if (response.IsSuccessStatusCode)
                 {
                     var result = response.Content.ReadAsStringAsync().Result;
                     if(result != null && result != string.Empty)
                     {
                         return result;
                     }
                 }
                 response.Dispose();
                 response.Headers.ConnectionClose = true;
                 return "";
             }*/
            string fullUrl = $"{baseAddress.TrimEnd('/')}/{AAHRServiceConstant.UploadFile}/?folderName={Uri.EscapeDataString(folderName)}&driveID={Uri.EscapeDataString(driveID)}";

            using (HttpClient client = new HttpClient())
            using (var form = new MultipartFormDataContent())
            using (var fileContent = new StreamContent(file.OpenReadStream()))
            {
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(filteType); // e.g., "application/pdf", "image/jpeg"
                form.Add(fileContent, "file", file.FileName); // "file" must match the parameter name in the API

                HttpResponseMessage response = client.PostAsync(fullUrl, form).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }

                return $"Error: {response.StatusCode}, Reason: {response.ReasonPhrase}";
            }

        }
    }

    public static class AAHRServiceConstant
    {
        public const string GetFolderData = "api/GoogleDrive/GetFolderData";
        public const string CreateFolder = "api/GoogleDrive/CreateFolder";
        public const string UploadFile = "api/GoogleDrive/UploadFile";

    }
}
