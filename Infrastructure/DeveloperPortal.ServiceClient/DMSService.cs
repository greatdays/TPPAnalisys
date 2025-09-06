using DeveloperPortal.Domain.Helper;
using HCIDLA.ServiceClient.DMS;
using HCIDLA.ServiceClient.LaserFiche;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO.Compression;
using System.ServiceModel;

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
        public JsonResult SubmitUploadedDocument(IFormFile file,string emailId,int caseId,string Category,string subCategory)
        {
            JsonData<UploadResponse> result = new JsonData<UploadResponse>(new UploadResponse());
            UploadResponse response = new UploadResponse();
            int? fileThreshold = null;
            var isBackground = true;
            FileUploadInfo info = new FileUploadInfo
            {
                ApplicationId = new Guid(string.IsNullOrWhiteSpace(_config["DMSConfig:DMSAppIdExternal"])?"": _config["DMSConfig:DMSAppIdExternal"]),
                DocumentType = DocType.AcHP,
                MetaData = new Dictionary<FieldType, string[]>(),
                SysData = new Dictionary<SysFieldType, string>
                {
                    { SysFieldType.CreatedBy, emailId }
                },
                FileName= file.FileName,
                
            };
            info.MetaData.Add(FieldType.PrimaryKey, new string[] { Guid.NewGuid().ToString()});
            info.MetaData.Add(FieldType.Category, new string[] { Category });
            info.MetaData.Add(FieldType.SubCategory, new string[] { subCategory });
          
           
            if (Int32.TryParse(GetFormDataValue(_config["DMSConfig:LargeFileThreshold"]), out int parsedThreshold))
            {
                fileThreshold = parsedThreshold;
            }
           
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

        public DMSDocument GetDocument(Guid uniqueId, bool useFakeDMS = false)
        {
            DMSDocument document = new DMSDocument();
            if (useFakeDMS)
            {
                document.DocumentName = "3DI_Logo.png";
                // string file = Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, document.DocumentName);
                string file = "";
                 var fileContent = File.ReadAllBytes(file);
                document.DocumentByte = fileContent;
                document.DocumentGuid = uniqueId;
            }
            else
            {
                string endpointUrl = "http://43dmsw2/DMSServiceDev_V5/DMS.svc";

                // 2. Create the binding and endpoint address programmatically
                var binding = new BasicHttpBinding(); // Use the correct binding type (e.g., WSHttpBinding)
                var endpointAddress = new EndpointAddress(endpointUrl);
                binding.MaxReceivedMessageSize = int.MaxValue;
                binding.MaxBufferSize = int.MaxValue;
                using (DMSClient dms = new DMSClient(binding, endpointAddress))
                {
                    ContentRetrievalResponse response = dms.GetContentByUnid(uniqueId);
                    if (response != null)
                    {
                        document.DocumentName = response.FileName;
                        document.DocumentByte = response.FileStream;
                        if (IsGzipCompressed(response.FileStream))
                        {
                            document.DocumentByte = CompressDecompressBytes(response.FileStream, CompressionMode.Decompress);
                        }
                        else
                        {
                            document.DocumentByte = new byte[response.FileStream.Length];
                            response.FileStream.CopyTo(document.DocumentByte, 0);
                        }
                    }
                }
            }
            return document;
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

        private bool IsGzipCompressed(byte[] data)
        {
            // Gzip files start with 0x1F8B
            return data.Length >= 2 && data[0] == 0x1F && data[1] == 0x8B;
        }
        protected byte[] CompressDecompressBytes(byte[] data, CompressionMode compressionMode, CompressionLevel compressionLevel = CompressionLevel.Optimal)
        {
            using (var outputStream = new MemoryStream())
            {
                if (compressionMode == CompressionMode.Compress)
                {
                    using (var gzipStream = new GZipStream(outputStream, compressionLevel))
                    {
                        gzipStream.Write(data, 0, data.Length);
                    }
                }
                else if (compressionMode == CompressionMode.Decompress)
                {
                    using (var inputStream = new MemoryStream(data))
                    using (var gzipStream = new GZipStream(inputStream, CompressionMode.Decompress))
                    {
                        gzipStream.CopyTo(outputStream);
                    }
                }

                return outputStream.ToArray();
            }
        }



    }
}
