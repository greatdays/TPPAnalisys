using DeveloperPortal.Models;
using DeveloperPortal.Models.PlanReview;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        /*public static string UploadFile(string baseAddress, string driveID, string folderName, IFormFile file, string filteType,
            string gAPIUname=null,string gAPIpwd=null)
        {

            string fullUrl = $"{baseAddress.TrimEnd('/')}/{AAHRServiceConstant.UploadFile}/?folderName={Uri.EscapeDataString(folderName)}&driveID={Uri.EscapeDataString(driveID)}";
            var URL = new Uri(fullUrl);
            var referrer = $"{URL.Scheme}://{URL.Authority}";
            
            HttpClient client = CreateHttpClient(gAPIUname, gAPIpwd);
            client.DefaultRequestHeaders.Referrer = new Uri(referrer);

            //using (HttpClient client = new HttpClient())
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

        }*/
        public static string UploadFileAsync(
        string baseAddress,
        string driveID,
        string folderName,
        IFormFile file,
        string fileType,
        string gAPIUname = null,
        string gAPIpwd = null)
        {
            // Ensure base URL and endpoint are correctly combined
            string endpoint = $"{baseAddress.TrimEnd('/')}/{AAHRServiceConstant.UploadFile}";
            var query = $"?folderName={Uri.EscapeDataString(folderName)}&driveID={Uri.EscapeDataString(driveID)}";
            string fullUrl = endpoint + query;

            using var client = CreateHttpClient(gAPIUname, gAPIpwd);

            // Set referrer based on base address
            var url = new Uri(fullUrl);
            client.DefaultRequestHeaders.Referrer = new Uri($"{url.Scheme}://{url.Authority}");

            using var form = new MultipartFormDataContent();
            using var fileContent = new StreamContent(file.OpenReadStream());

            fileContent.Headers.ContentType = new MediaTypeHeaderValue(fileType);
            form.Add(fileContent, "file", file.FileName);

            HttpResponseMessage response =  client.PostAsync(fullUrl, form).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }

            return $"Error: {response.StatusCode}, Reason: {response.ReasonPhrase}, URL: {fullUrl}";
        }


        public static async Task<(Stream Stream, string FileName, string ContentType)?> DownloadDocument(string baseAddress, string fileID)
        {
            string url = $"{baseAddress.TrimEnd('/')}/{AAHRServiceConstant.DownloadDocument}?fileId={fileID}";


            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    var contentDisposition = response.Content.Headers.ContentDisposition;
                    var fileName = contentDisposition?.FileName?.Trim('"') ?? "downloaded_file";
                    var contentType = response.Content.Headers.ContentType?.ToString() ?? "application/octet-stream";

                    return (stream, fileName, contentType);
                }

                return null;
            }
        }
        private static HttpClient CreateHttpClient(string username, string password)
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                UseCookies = false
            };

            var httpClient = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromMinutes(10)
            };

            // Accept JSON (most APIs return JSON), fallback to anything
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

            // Language
            httpClient.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-US"));

            // User-Agent (keep minimal)
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("HttpClient/1.0");

            // GZip compression
            httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));

            // Only add auth if provided
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
            }

            return httpClient;
        }

    }

    public static class AAHRServiceConstant
    {
        public const string GetFolderData = "api/GoogleDrive/GetFolderData";
        public const string CreateFolder = "api/GoogleDrive/CreateFolder";
        public const string UploadFile = "api/GoogleDrive/UploadFile";
        public const string DownloadDocument = "api/GoogleDrive/DownloadDocument";
    }
}
