using DeveloperPortal.Models;
using DeveloperPortal.Models.PlanReview;
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
            var url = AAHRServiceConstant.GetFolderData + "?folderName=" + folderName + "&driveID=" + driveID;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response;
                response = client.PostAsJsonAsync(url,new object()).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    FolderModel RetIdmUser = JsonConvert.DeserializeObject<FolderModel>(JsonConvert.DeserializeObject(result).ToString());
                    return RetIdmUser;
                }
                response.Dispose();
                response.Headers.ConnectionClose = true;
                return new FolderModel();
            }
        }
    }

    public static class AAHRServiceConstant
    {
        public const string GetFolderData = "api/GoogleDrive/GetFolderData";
    }
}
