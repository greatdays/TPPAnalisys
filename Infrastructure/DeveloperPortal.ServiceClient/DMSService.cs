using DeveloperPortal.Domain.Common;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.Domain.Helper;
using DeveloperPortal.Models.IDM;
using HCIDLA.ServiceClient.DMS;
using HCIDLA.ServiceClient.LaserFiche;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.ServiceClient
{
    public class DMSService
    {
        public IConfiguration _config;

        public DMSService(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost]
        public JsonResult SubmitUploadedDocument(IFormFile file,string folderName,string emailId,int caseId, string controlId)
        {
            JsonData<UploadResponse> result = new JsonData<UploadResponse>(new UploadResponse());
            UploadResponse response = new UploadResponse();
            FileUploadInfo info = new FileUploadInfo
            {
                ApplicationId = new Guid(string.IsNullOrWhiteSpace(_config["DMSConfig:DMSAppIdExternal"])?"": _config["DMSConfig:DMSAppIdExternal"]),
                DocumentType = DocType.Generic,
                MetaData = new Dictionary<FieldType, string[]>(),
                SysData = new Dictionary<SysFieldType, string>
                {
                    { SysFieldType.CreatedBy, emailId }
                },
                FileName= file.FileName,
                
            };

            //Dictionary<string, FieldType> formValToFieldTypeMap = new Dictionary<string, FieldType>()
            //{
            //    {"AchpProjectId", FieldType.AchpProjectId },
            //    {"AchpPropertyId", FieldType.AchpPropertyId },
            //    //{"APN", FieldType.APN },
            //    {"CaseId", FieldType.CaseId },
            //    {"PrimaryKey", FieldType.PrimaryKey },
            //    {"Category", FieldType.Category },
            //    {"SubCategory", FieldType.SubCategory },
            //    {"Description", FieldType.Description },
            //    {"Audience", FieldType.Audience },
            //    {"Status", FieldType.Status },
            //    {"HIMSNumber", FieldType.HIMSNumber },
            //    {"AcHPNumber", FieldType.AcHPNumber }
            //};

            //foreach (KeyValuePair<string, FieldType> maps in formValToFieldTypeMap)
            //{
            //    string val = GetFormDataValue(data[maps.Key]);
            //    if (!String.IsNullOrEmpty(val))
            //    {
            //        info.MetaData.Add(maps.Value, new string[] { val });
            //    }
            //}

            //string apnVal = GetFormDataValue(data["APN"]);
            //if (!string.IsNullOrWhiteSpace(apnVal))
            //    info.MetaData.Add(FieldType.APN, apnVal.Split(','));

            //string recDate = GetDateOrNull(data["ReceivedDate"]);
            //if (!String.IsNullOrEmpty(recDate))
            //{
            //    info.MetaData.Add(FieldType.ReceivedDate, new string[] { recDate });
            //}

            //FileActivityWorkLogModel fileActivityModel = new FileActivityWorkLogModel();
            //fileActivityModel.Action = FileAction.Add;
            //if (info.MetaData.Keys.Contains(FieldType.AchpPropertyId))
            //{
            //    fileActivityModel.ProjectSiteID = info.MetaData.Where(m => m.Key == FieldType.AchpPropertyId).Select(m => m.Value.FirstOrDefault()).FirstOrDefault().ToString();
            //}
            //fileActivityModel.Category = info.MetaData.Where(m => m.Key == FieldType.Category).Select(m => m.Value.FirstOrDefault()).FirstOrDefault().ToString();
            //fileActivityModel.SubCategory = info.MetaData.Where(m => m.Key == FieldType.SubCategory).Select(m => m.Value.FirstOrDefault()).FirstOrDefault().ToString();
            //fileActivityModel.SystemDescription = GetFormDataValue(data["Description"]); //info.MetaData.Where(m => m.Key == FieldType.Description).Select(m => m.Value.FirstOrDefault()).FirstOrDefault().ToString();
            //fileActivityModel.Comments = GetFormDataValue(data["Comments"]);
            //fileActivityModel.CreatedBy = UserSession.GetUserSession().UserName.ToString();

            int? fileThreshold = null;
            if (Int32.TryParse(GetFormDataValue(_config["DMSConfig:LargeFileThreshold"]), out int parsedThreshold))
            {
                fileThreshold = parsedThreshold;
            }
            var isBackground = true;
            if (file != null) // file is IFormFile
            {
                using var memoryStream = new MemoryStream();
                file.CopyTo(memoryStream); 
                byte[] byteArray = memoryStream.ToArray();

                info.FileName = file.FileName;
                info.FileStream = byteArray;

                if (byteArray.Length <= fileThreshold)
                {
                    response = DMSClientProxy.Upload(info);
                    isBackground = false;
                }
            }
            if (isBackground)
            {
                Task.Run(() => ProcessFiles(file, info));
            }
            return new JsonResult(response);

        }
        string GetFormDataValue(string values)
        {
            return values ?? string.Empty;
            //if (string.IsNullOrEmpty(values))
            //{
            //    return "";
            //}

            //string[] vals = values.Split(',');
            //return vals[0];
        }
        string GetDateOrNull(string dateString)
        {
            if (string.IsNullOrEmpty(dateString))
            {
                return null;
            }

            string[] dates = dateString.Split(',');
            if (DateTime.TryParse(dates[0], out DateTime dtOut))
            {
                return dtOut.ToString("yyyy-MM-dd");
            }
            return null;
        }
        private void ProcessFiles(IFormFile files, FileUploadInfo info)
        {
            string errorMsg = null;

            Parallel.For(0, files.Length, i =>
            {
                var f = files;

                if (info.FileStream == null || !info.FileStream.Any())
                {
                    using var memoryStream = new MemoryStream();
                    f.CopyTo(memoryStream); // ✅ replaces InputStream.CopyTo
                    byte[] byteArray = memoryStream.ToArray();
                    info.FileStream = byteArray;
                }

                info.FileName = f.FileName;
                UploadResponse response = DMSClientProxy.Upload(info);

                if (response.ReturnStatus != Status.Success)
                {
                    errorMsg = string.Join(", ", response.ErrorMessages);
                }
            });
        }


    }
}
