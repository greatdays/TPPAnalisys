using DeveloperPortal.Domain.Helper;
using DeveloperPortal.Models.Common;
using HCIDLA.ServiceClient.DMS;
using HCIDLA.ServiceClient.LaserFiche;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IO.Compression;
using System.Net;
using System.ServiceModel;
using System.Text;
using static DeveloperPortal.ServiceClient.ServiceClient;

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
        public async Task<List<UploadResponse>> SubmitUploadedDocument(List<IFormFile> files, int caseId, string category, string fileSubCategory, string createdBy)
        {
            if (files == null || !files.Any())
            {
                return new List<UploadResponse> { new UploadResponse { ReturnStatus = Status.Failed, ErrorMessages = new[] { "No files were provided." } } };
            }

            // Prepare base upload info
            var baseInfo = new FileUploadInfo
            {
                ApplicationId = new Guid(string.IsNullOrWhiteSpace(_config["DMSConfig:DMSAppIdExternal"]) ? "" : _config["DMSConfig:DMSAppIdExternal"]),
                DocumentType = DocType.AcHP,
                MetaData = new Dictionary<FieldType, string[]>
            {
                { FieldType.PrimaryKey, new string[] { Guid.NewGuid().ToString() } },
                { FieldType.Category, new string[] { category } },
                { FieldType.SubCategory, new string[] { fileSubCategory } }
            },
                SysData = new Dictionary<SysFieldType, string>
            {
                { SysFieldType.CreatedBy, createdBy }
            }
            };

            // 3. Directly call the async processing method and await its result.
            // We no longer need the isBackground flag or Task.Run logic here,
            // as the asynchronous nature is handled correctly by the method itself.
            var responses = await ProcessFiles(files, baseInfo);

            return responses;
        }
        private async Task<List<UploadResponse>> ProcessFiles(List<IFormFile> files, FileUploadInfo baseInfo)
        {
            var uploadTasks = new List<Task<UploadResponse>>();

            foreach (var f in files)
            {
                // 5. Create a new task for each file. This is the key to concurrent processing.
                // The lambda function ensures each task gets its own scope.
                uploadTasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        using var memoryStream = new MemoryStream();
                        await f.CopyToAsync(memoryStream); // Await this call
                        byte[] byteArray = memoryStream.ToArray();

                        var info = new FileUploadInfo
                        {
                            ApplicationId = baseInfo.ApplicationId,
                            DocumentType = baseInfo.DocumentType,
                            MetaData = new Dictionary<FieldType, string[]>(baseInfo.MetaData),
                            SysData = new Dictionary<SysFieldType, string>(baseInfo.SysData),
                            FileName = f.FileName,
                            FileStream = byteArray
                        };

                        // Assume DMSClientProxy.Upload is synchronous, so we run it on a background thread.
                        // If it's already an async method (e.g., UploadAsync), you would just `await` it.
                        return DMSClientProxy.Upload(info);
                    }
                    catch (Exception ex)
                    {
                        // This catch block is crucial for handling errors on a per-file basis
                        return new UploadResponse
                        {
                            ReturnStatus = Status.Failed,
                            ErrorMessages = new string[] { ex.Message }
                        };
                    }
                }));
            }

            // 6. Await all the tasks to complete. This ensures all files are processed
            // before the method returns.
            var uploadResponses = await Task.WhenAll(uploadTasks);

            return uploadResponses.ToList();
        }

        /* public JsonResult SubmitUploadedDocument(IFormFileCollection file,int caseId, string category, string fileSubCategory, string createdBy)
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
                     { SysFieldType.CreatedBy, createdBy }
                 },

             };
             info.MetaData.Add(FieldType.PrimaryKey, new string[] { Guid.NewGuid().ToString()});
             info.MetaData.Add(FieldType.Category, new string[] { category });
             info.MetaData.Add(FieldType.SubCategory, new string[] { fileSubCategory });


             if (Int32.TryParse(GetFormDataValue(_config["DMSConfig:LargeFileThreshold"]), out int parsedThreshold))
             {
                 fileThreshold = parsedThreshold;
             }

             if (file != null && file.Count==1) // file is IFormFile
             {
                 var f = file[0];
                 using var memoryStream = new MemoryStream();
                 f.CopyTo(memoryStream); 
                 byte[] byteArray = memoryStream.ToArray();

                 info.FileName = f.FileName;
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

         }*/

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
        //private List<UploadResponse> ProcessFiles(List<IFormFile> files, FileUploadInfo baseInfo)
        //{
        //    var uploadFiles = new List<UploadResponse>();

        //    foreach (var f in files)
        //    {
        //        try
        //        {
        //            using var memoryStream = new MemoryStream();
        //            f.CopyToAsync(memoryStream);
        //            byte[] byteArray = memoryStream.ToArray();

        //            // Create a new info object per file to avoid race conditions
        //            var info = new FileUploadInfo
        //            {
        //                ApplicationId = baseInfo.ApplicationId,
        //                DocumentType = baseInfo.DocumentType,
        //                MetaData = new Dictionary<FieldType, string[]>(baseInfo.MetaData),
        //                SysData = new Dictionary<SysFieldType, string>(baseInfo.SysData),
        //                FileName = f.FileName,
        //                FileStream = byteArray
        //            };

        //            UploadResponse response = DMSClientProxy.Upload(info);
        //            uploadFiles.Add(response);
        //        }
        //        catch (Exception ex)
        //        {
        //            uploadFiles.Add(new UploadResponse
        //            {
        //                ReturnStatus = Status.Failed,
        //                ErrorMessages = new string[] { ex.Message }
        //            });
        //        }
        //    }

        //    return uploadFiles;
        //}

        /* private List<UploadResponse> ProcessFiles(IFormFileCollection files, FileUploadInfo info)
         {
             string errorMsg = null;
             List<UploadResponse> uploadFiles = new List<UploadResponse>();
             Parallel.For(0, files.Count, i =>
             {
                 var f = files[i];

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
                 uploadFiles.Add(response);
             });

             return uploadFiles;
         }*/

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
