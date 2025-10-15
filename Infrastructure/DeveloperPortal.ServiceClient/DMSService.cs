using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.Helper;
using DeveloperPortal.Domain.ProjectDetail;
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

namespace DeveloperPortal.ServiceClient
{
    public class DMSService
    {

       
        private IConfiguration _config;
        private string getDMSLargeFileUploadPath { get; set; }

        public DMSService(IConfiguration config) 
        {
            _config = config;
        }
        [HttpPost]
        public async Task<List<UploadResponse>> SubmitUploadedDocument(List<IFormFile> files,ProjectSummaryModel projectSummaryModel, string category, 
            string fileSubCategory, string createdBy,string largeFileUploadPath)
        {
            getDMSLargeFileUploadPath = largeFileUploadPath;
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
                { FieldType.PrimaryKey, new string[] { projectSummaryModel.ProjectId.ToString()} },
                { FieldType.Category, new string[] { category } },
                { FieldType.SubCategory, new string[] { fileSubCategory } },
                { FieldType.CaseId, new string[] { projectSummaryModel.CaseID.ToString() } },
                { FieldType.AchpProjectId, new string[] { projectSummaryModel.ProjectId.ToString() } },
                { FieldType.AchpPropertyId, new string[] { projectSummaryModel.ProjectId.ToString() } },
                { FieldType.AcHPNumber, new string[] { projectSummaryModel.ACHPNumber.ToString().Split('-')[0].ToString() } },
                { FieldType.APN, new string[] { projectSummaryModel.APN.ToString() } },
                { FieldType.ReceivedDate, new string[] { DateTime.Now.ToString("yyyy-MM-dd") } },
            },
                SysData = new Dictionary<SysFieldType, string>
            {
                { SysFieldType.CreatedBy, createdBy }
            }
            };

            var responses = await ProcessFiles(files, baseInfo);

            return responses;
        }
        private async Task<List<UploadResponse>> ProcessFiles(List<IFormFile> files, FileUploadInfo baseInfo)
        {
            // Holds all the async upload tasks
            var uploadTasks = new List<Task<UploadResponse>>();

            // Read LargeFileThreshold from configuration
            int? fileThreshold = null;
            if (int.TryParse(_config["DMSConfig:LargeFileThreshold"], out int threshold))
            {
                fileThreshold = threshold;
            }

            foreach (var f in files)
            {
                // Each file gets processed concurrently in its own task
                uploadTasks.Add(Task.Run(async () =>
                {
                    // Clone the base info so each task has its own independent copy
                    var info = new FileUploadInfo
                    {
                        ApplicationId = baseInfo.ApplicationId,
                        DocumentType = baseInfo.DocumentType,
                        MetaData = new Dictionary<FieldType, string[]>(baseInfo.MetaData),
                        SysData = new Dictionary<SysFieldType, string>(baseInfo.SysData),
                        FileName = f.FileName,
                        
                        
                    };

                    try
                    {
                        // Read the file into memory
                        using var memoryStream = new MemoryStream();
                        await f.CopyToAsync(memoryStream); // Await to avoid blocking
                        byte[] byteArray = memoryStream.ToArray();

                        // Handle large files separately
                        if (fileThreshold.HasValue && byteArray.Length >= fileThreshold.Value)
                        {
                            await ProcessLargeFile(info, byteArray);

                            // Return a response indicating it was processed as a large file
                            return new UploadResponse
                            {
                                ReturnStatus = Status.Success,
                                UniqueId= System.Guid.Empty,
                                URL= "BACKGROUND_PROCESSING_INITIATED",
                                ErrorMessages = Array.Empty<string>()
                            };
                        }

                        // Normal-sized file upload
                        info.FileStream = byteArray;
                        return DMSClientProxy.Upload(info);
                    }
                    catch (Exception ex)
                    {
                        // Catch errors on a per-file basis to avoid failing the whole batch
                        return new UploadResponse
                        {
                            ReturnStatus = Status.Failed,
                            ErrorMessages = new[] { ex.Message }
                        };
                    }
                }));
            }

            // Await all tasks before returning
            var uploadResponses = await Task.WhenAll(uploadTasks);
            return uploadResponses.ToList();
        }


        private async Task ProcessLargeFile(FileUploadInfo info, byte[] fileStream)
        {
            try
            { /*
                // Get the XML metadata for the large file
                string xml = DMSClientProxy.GetXmlForLargeFile(info, fileStream.Length);

                // Use application config for large-file path
                string baseDir = "D:\\Ananthu\\Developer Portal\\UI\\DeveloperPortal\\TempUploads\\";
                string targetDir = Path.Combine(baseDir, Guid.NewGuid().ToString());
                string xmlFileName = Path.Combine(targetDir, "process.xml");
                string actualFileName = Path.Combine(targetDir, info.FileName);

                Directory.CreateDirectory(targetDir);
                File.WriteAllText(xmlFileName, xml);
                File.WriteAllBytes(actualFileName, fileStream);*/
                // Get the configured upload folder path (example: "TempUploads" or "Uploads/LargeFiles")

                // Example: Get the XML metadata for the uploaded file
                string xml = DMSClientProxy.GetXmlForLargeFile(info, fileStream.Length);
                
                string relativePath = "TempUploads"; // e.g. "TempUploads"
                string folder = Guid.NewGuid().ToString();

                // Equivalent to HostingEnvironment.MapPath("~" + relativePath)
                string basePath = Path.Combine("D:\\Ananthu\\Developer Portal\\UI\\DeveloperPortal", relativePath); // app root
                string contentPath = Path.Combine(basePath, folder);

                Directory.CreateDirectory(contentPath);

                string filePath = Path.Combine(contentPath, info.FileName);
                string xmlPath = Path.Combine(contentPath, "process.xml");

               

                // Save XML file
                await File.WriteAllTextAsync(xmlPath, xml);

                // Save binary file
                await File.WriteAllBytesAsync(filePath, fileStream);

               


            }
            catch (Exception ex)
            {
                // Log the exception or include inner exception details
                Console.WriteLine($"Error in ProcessLargeFile: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }

                // Optionally, rethrow if you want the calling code to handle it
                throw;
            }
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
