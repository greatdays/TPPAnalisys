using HCIDLA.ServiceClient.DMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Configuration;

namespace HCIDLA.ServiceClient.LaserFiche
{
    public class Document
    {
        public int _MaxFileNameLength { get; } = 50;

        public async Task<List<DMSResponse>> UploadMultipleFilesAsync(IList<System.Net.Http.HttpContent> files, string apn, string requestId, string Category, string ServiceYear, bool useFakeDMS = false, string FolderGUID = "", string userName = "")
        {

            List<DMSResponse> fileUploadSuccessStatus = new List<DMSResponse>();

            foreach (HttpContent file in files)
            {
                var thisFileName = file.Headers.ContentDisposition.FileName.Trim('\"');
                byte[] filedata = await file.ReadAsByteArrayAsync();

                if (filedata != null)
                {
                    if (useFakeDMS)
                    {
                        fileUploadSuccessStatus.Add(new DMSResponse { UniqueId = Guid.NewGuid().ToString(), FileName = "3DI_Logo.png", ReturnStatus = "Success" });
                    }
                    else
                    {
                        var _dmsres = await SaveDocumentAsync(filedata, thisFileName, apn, requestId, Category, ServiceYear, FolderGUID, userName);
                        if (_dmsres.ReturnStatus == Status.Success.ToString())
                        {
                            fileUploadSuccessStatus.Add(_dmsres);
                        }
                    }
                }

            }
            return fileUploadSuccessStatus;
        }

        public List<DMSResponse> UploadMultipleFiles(IList<HttpContent> files, string apn, string requestId, string category, string serviceYear, bool useFakeDMS = false, string FolderGUID = "", string userName = "")
        {

            List<DMSResponse> fileUploadSuccessStatus = new List<DMSResponse>();

            foreach (HttpContent file in files)
            {
                var thisFileName = file.Headers.ContentDisposition.FileName.Trim('\"');
                byte[] filedata = file.ReadAsByteArrayAsync().Result;

                if (filedata != null)
                {
                    if (useFakeDMS)
                    {
                        fileUploadSuccessStatus.Add(new DMSResponse { UniqueId = Guid.NewGuid().ToString(), FileName = "3DI_Logo.png", ReturnStatus = "Success" });
                    }
                    else
                    {
                        var _dmsres = new Document().SaveDocument(filedata, thisFileName, apn, requestId, category, serviceYear, FolderGUID, userName);
                        if (_dmsres.ReturnStatus == Status.Success.ToString())
                        {
                            fileUploadSuccessStatus.Add(_dmsres);
                        }
                    }
                }
            }
            return fileUploadSuccessStatus;
        }

        public List<DMSResponse> UploadMultipleFiles(HttpFileCollection files, string apn, string requestId, string category, string serviceYear, bool useFakeDMS = false, string FolderGUID = "", string userName = "")
        {

            List<DMSResponse> fileUploadSuccessStatus = new List<DMSResponse>();

            foreach (string filename in files)
            {
                HttpPostedFile file = HttpContext.Current.Request.Files[filename];
                var thisFileName = filename.Trim('\"');

                byte[] filedata = new byte[file.ContentLength];
                file.InputStream.Read(filedata, 0, file.ContentLength);

                //byte[] filedata = file.

                if (filedata != null)
                {
                    if (useFakeDMS)
                    {
                        fileUploadSuccessStatus.Add(new DMSResponse { UniqueId = Guid.NewGuid().ToString(), FileName = "3DI_Logo.png", ReturnStatus = "Success" });
                    }
                    else
                    {
                        var _dmsres = new Document().SaveDocument(filedata, thisFileName, apn, requestId, category, serviceYear, FolderGUID, userName);
                        if (_dmsres.ReturnStatus == Status.Success.ToString())
                        {
                            fileUploadSuccessStatus.Add(_dmsres);
                        }
                    }
                }
            }
            return fileUploadSuccessStatus;
        }

        public List<DMSResponse> UploadMultipleFiles(List<DMSDocument> files, string apn, string requestId, string category, string serviceYear, bool useFakeDMS = false, string FolderGUID = "", string userName = "")
        {

            List<DMSResponse> fileUploadSuccessStatus = new List<DMSResponse>();

            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file.DocumentByte != null)
                    {
                        if (useFakeDMS)
                        {
                            fileUploadSuccessStatus.Add(new DMSResponse { UniqueId = Guid.NewGuid().ToString(), FileName = file.DocumentName, ReturnStatus = "Success", DocumentID = file.DocumentID });
                        }
                        else
                        {
                            string GUID = "";
                            if (string.IsNullOrEmpty(FolderGUID))
                            {
                                GUID = file.FolderGUID;
                            }
                            else {
                                GUID = FolderGUID;
                            }
                            var _dmsres = new Document().SaveDocument(file.DocumentByte, file.DocumentName, apn, requestId, file.documentType, serviceYear, GUID, userName);
                            if (_dmsres.ReturnStatus == Status.Success.ToString())
                            {
                                _dmsres.DocumentID = file.DocumentID;
                                fileUploadSuccessStatus.Add(_dmsres);
                            }
                        }
                    }
                }
            }
            return fileUploadSuccessStatus;
        }

        /// <summary>
        /// SaveDocument
        /// </summary>
        /// <param name="fileStream"></param>
        /// <param name="fileName"></param>
        /// <param name="APN"></param>
        /// <param name="RequestId"></param>
        /// <param name="Category"></param>
        /// <param name="ServiceYear"></param>
        /// <returns></returns>
        public async Task<DMSResponse> SaveDocumentAsync(byte[] fileStream, string fileName, string APN, string RequestId, string Category, string ServiceYear, string FolderGUID = "", string userName = "")
        {
            using (DMSClient dms = new DMSClient())
            {
               
                FileUploadInfo fi = PopulateDMSObject(fileStream, fileName, APN, RequestId, Category, ServiceYear, FolderGUID, userName);

                UploadResponse response = await dms.UploadFileAsync(fi);
                DMSResponse res = new DMSResponse();
                res.ErrorMessage = response.ErrorMessages;
                res.ReturnStatus = response.ReturnStatus.ToString();
                res.UniqueId = response.UniqueId.ToString();
                res.FileName = fi.FileName;
                return res;
            }
        }

        public DMSResponse SaveDocument(byte[] fileStream, string fileName, string APN, string RequestId, string Category, string ServiceYear, string FolderGUID = "", string userName = "")
        {
            using (DMSClient dms = new DMSClient())
            {
               
                FileUploadInfo fi = PopulateDMSObject(fileStream, fileName, APN, RequestId, Category, ServiceYear, FolderGUID, userName);

                UploadResponse response = dms.UploadFile(fi);
                DMSResponse res = new DMSResponse();
                res.ErrorMessage = response.ErrorMessages;
                res.ReturnStatus = response.ReturnStatus.ToString();
                res.UniqueId = response.UniqueId.ToString();
                res.FileName = fi.FileName;
                return res;
            }
        }
        //Added ReceivedDate parameter by Eric Kim
        private FileUploadInfo PopulateDMSObject(byte[] fileStream, string fileName, string APN, string RequestId, string Category, string ServiceYear, string FolderGUID = "", string userName = "")
        {
            DateTime now = DateTime.Now;
            string nowFormatted = now.ToString("yyyy.MM.dd_HH.mm.ss");

            FileUploadInfo fi = new FileUploadInfo();
            if (string.IsNullOrEmpty(FolderGUID))
            {
                fi.ApplicationId = new Guid(WebConfigurationManager.AppSettings.Get("DMSAppIdExternal"));
            }
            fi.ApplicationId = new Guid(FolderGUID);
            fi.FileStream = fileStream;
            fi.DocumentType = DocType.AcHP;
            fi.FileName = CleanTrimFileName(nowFormatted + "__" + fileName);
            fi.MetaData = new Dictionary<FieldType, string[]>();
            if (Category == "Project")
            {
                fi.MetaData.Add(FieldType.AchpProjectId, new string[] { APN });
            }
            else
            {
                fi.MetaData.Add(FieldType.AchpPropertyId, new string[] { APN });
            }

            fi.MetaData.Add(FieldType.PrimaryKey, new string[] { APN });
            fi.MetaData.Add(FieldType.CaseId, new string[] { RequestId });
            fi.MetaData.Add(FieldType.Category, new string[] { Category });
            fi.SysData = new Dictionary<SysFieldType, string>();
            fi.SysData.Add(SysFieldType.CreatedBy, userName);
            fi.SysData.Add(SysFieldType.ModifiedBy, userName);
            //fi.MetaData.Add(FieldType.ServiceYear, new string[] { ServiceYear });
            //fi.MetaData.Add(FieldType.ReceivedDate, new string[] { DateTime.Now.ToString("yyyy-MM-dd") });
            return fi;
        }

        /// <summary>
        /// Search documents on APN or RequestID or Category
        /// </summary>
        /// <param name="APN"></param>
        /// <param name="RequestId"></param>
        /// <param name="Category"></param>
        /// <returns></returns>
        public static List<DMSResponse> SearchDocument(string APN, string RequestId, string Category, bool useFakeDMS = false, string FolderGUID = "")
        {
            List<DMSResponse> resultFiles = new List<DMSResponse>();

            if (useFakeDMS)
            {
                resultFiles.Add(new DMSResponse { UniqueId = Guid.NewGuid().ToString(), ReturnStatus = "Success" });
            }
            else
            {
                using (DMSClient dms = new DMSClient())
                {

                    SearchParameters parameters = new SearchParameters();

                    if (string.IsNullOrEmpty(FolderGUID))
                    {
                        parameters.ApplicationId = new Guid(WebConfigurationManager.AppSettings.Get("DMSAppIdExternal"));
                    }
                    parameters.ApplicationId = new Guid(FolderGUID);
                    parameters.DocumentType = DocType.AcHP;
                    parameters.MetaData = new Dictionary<FieldType, string>();
                    if (!string.IsNullOrEmpty(APN))
                    {
                        parameters.MetaData.Add(FieldType.APN, APN);
                    }
                    if (!string.IsNullOrEmpty(RequestId))
                    {
                        parameters.MetaData.Add(FieldType.PrimaryKey, RequestId);
                    }
                    if (!string.IsNullOrEmpty(Category))
                    {
                        parameters.MetaData.Add(FieldType.Category, Category);
                    }

                    SearchResponse response = dms.SearchForm(parameters);
                    if (response.ReturnStatus != Status.Failed)
                    {

                        foreach (DataRow row in response.Results.Rows)
                        {
                            DMSResponse res = new DMSResponse();
                            res.UniqueId = row["UniqueId"].ToString();
                            //res.FileName = row["File Name"].ToString();
                            resultFiles.Add(res);
                        }
                    }
                }
            }

            return resultFiles;
        }

        /// <summary>
        /// removes invalid characters in file names and trims to _MaxFileNameLength
        /// </summary>
        /// <param name="fileNameExt"></param>
        /// <returns></returns>
        private string CleanTrimFileName(string fileNameExt)
        {
            fileNameExt = Path.GetInvalidFileNameChars().Aggregate(fileNameExt, (current, c) => current.Replace(c.ToString(), ""));
            if (fileNameExt.Length < 1)
            {
                return "_";
            }
            else if (fileNameExt.Length <= _MaxFileNameLength)
            {
                return fileNameExt;
            }
            else
            {
                string fileExt = Path.GetExtension(fileNameExt);
                string fileName = Path.GetFileNameWithoutExtension(fileNameExt).Substring(0, _MaxFileNameLength - fileExt.Length);
                return fileName + fileExt;
            }
        }

        public DMSDocument GetDocument(Guid uniqueId, bool useFakeDMS = false)
        {
            DMSDocument document = new DMSDocument();
            if (useFakeDMS)
            {
                document.DocumentName = "3DI_Logo.png";
                string file = Path.Combine(System.Web.HttpRuntime.AppDomainAppPath, document.DocumentName);
                var fileContent = File.ReadAllBytes(file);
                document.DocumentByte = fileContent;
                document.DocumentGuid = uniqueId;
            }
            else
            {
                using (DMSClient dms = new DMSClient())
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

        private bool IsGzipCompressed(byte[] data)
        {
            // Gzip files start with 0x1F8B
            return data.Length >= 2 && data[0] == 0x1F && data[1] == 0x8B;
        }

    }

    /// <summary>
    /// DMSResponse
    /// </summary>
    public class DMSResponse
    {
        public string UniqueId { get; set; }
        public string ReturnStatus { get; set; }
        public string[] ErrorMessage { get; set; }

        public string FileName { get; set; }

        public int DocumentID { get; set; }
    }

    public class DMSDocument
    {
        public string DocumentName { get; set; }
        public byte[] DocumentByte { get; set; }
        public int DocumentID { get; set; }
        public Guid DocumentGuid { get; set; }
        public string documentType { get; set; }
        public string FolderGUID { get; set; }
    }

    public static class ThumbnailHelper
    {
        private const double _DefaultSearchCacheDays = 2;
        private const double _DefaultFileCacheDays = 30;
        private const string _ThumbnailSearchCacheKeyFormat = "ThumbSearch_{0}";
        private const string _ThumbnailFileCacheKeyFormat = "ThumbFile_{0}_{1}";

        private const int _ThumbnailSmallWidth = 480;
        private const int _ThumbnailSmallHeight = 360;
        private const int _ThumbnailMediumWidth = 640;
        private const int _ThumbnailMediumHeight = 480;
        private const int _ThumbnailLargeWidth = 1024;
        private const int _ThumbnailLargeHeight = 768;

        private const int _ThumbnailDefaultQuaility = 50;
        public enum ThumbnailSize { Small, Medium, Large }

        public static DMSDocument GetThumbnail(Guid uid, ThumbnailSize thumbnailSize = ThumbnailSize.Small)
        {
            // Set File Cache Key
            string fileCacheKey = string.Format(_ThumbnailFileCacheKeyFormat, thumbnailSize, uid);
            var fileCache = HttpContext.Current?.Cache?[fileCacheKey];
            if (fileCache != null)
            {
                return (DMSDocument)fileCache;
            }

            DMSDocument file = new DMSDocument();

            if (uid != Guid.Empty)
            {
                // Get Document from DMS
                Document download = new Document();
                DMSDocument getFileTask = download.GetDocument(uid, true);
                file = getFileTask;
                if (file.DocumentByte != null)
                {
                    // Check for size
                    int thumbWidth;
                    int thumbHeight;
                    if (thumbnailSize == ThumbnailSize.Small)
                    {
                        thumbWidth = _ThumbnailSmallWidth;
                        thumbHeight = _ThumbnailSmallHeight;
                    }
                    else if (thumbnailSize == ThumbnailSize.Medium)
                    {
                        thumbWidth = _ThumbnailMediumWidth;
                        thumbHeight = _ThumbnailMediumHeight;
                    }
                    else
                    {
                        thumbWidth = _ThumbnailLargeWidth;
                        thumbHeight = _ThumbnailLargeHeight;
                    }

                    // Set values
                    file.DocumentByte = GetJpegThumbnail(file.DocumentByte, thumbWidth, thumbHeight);
                    //file.MimeType = "image/jpeg";
                    file.DocumentName = Path.ChangeExtension(file.DocumentName, ".jpg");
                    file.DocumentGuid = uid;
                    // Add to cache for day this will help to improve performance if file is already loaded in cache
                    if (!double.TryParse(WebConfigurationManager.AppSettings["ThunbnailFileCacheDays"], out double fileCacheDays))
                        fileCacheDays = _DefaultFileCacheDays;
                    HttpContext.Current.Cache.Insert(fileCacheKey, file, null, DateTime.Now.AddDays(fileCacheDays), Cache.NoSlidingExpiration);
                }
            }
            return file;
        }

        /// <summary>
        /// Resize the image to the specified width and height if larger
        /// Encode image a jpeg with specified quality
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static byte[] GetJpegThumbnail(byte[] imageBytes, int width, int height, int quality = _ThumbnailDefaultQuaility)
        {
            Bitmap image;
            Bitmap destImage = new Bitmap(width, height);

            using (var ms = new MemoryStream(imageBytes))
            {
                image = new Bitmap(ms);
            }

            var destRect = new Rectangle(0, 0, width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighSpeed;
                graphics.InterpolationMode = InterpolationMode.Bicubic;
                graphics.SmoothingMode = SmoothingMode.HighSpeed;
                graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            var jpegEncoder = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);

            // Create an Encoder object based on the GUID
            // for the Quality parameter category.
            System.Drawing.Imaging.Encoder qualityEncoder = System.Drawing.Imaging.Encoder.Quality;

            // Create an EncoderParameters object.
            // An EncoderParameters object has an array of EncoderParameter
            // objects. In this case, there is only one
            // EncoderParameter object in the array.
            EncoderParameters encoderParameters = new EncoderParameters(1);

            EncoderParameter encoderParameter = new EncoderParameter(qualityEncoder, quality);
            encoderParameters.Param[0] = encoderParameter;

            using (var ms = new MemoryStream())
            {
                destImage.Save(ms, jpegEncoder, encoderParameters);
                return ms.ToArray();
            }
        }

    }
    public static class DMSClientProxy 
    {
        public static SearchResponse Search(SearchParameters args)
        {
            using (DMSClient dms = new DMSClient())
            {
                SearchResponse sr = dms.SearchForm(args);                
                return sr;
            }
        }

        public static UploadResponse Upload(FileUploadInfo uploadInfo)
        {

            string endpointUrl = "http://43dmsw2/DMSServiceDev_V5/DMS.svc";

            // 2. Create the binding and endpoint address programmatically
            var binding = new BasicHttpBinding(); // Use the correct binding type (e.g., WSHttpBinding)
            var endpointAddress = new EndpointAddress(endpointUrl);

            // 3. Instantiate the client using the new constructor
            using (DMSClient dms = new DMSClient(binding, endpointAddress))
            {
                return dms.UploadFile(uploadInfo);
                // Now you can make calls to the WCF service
                // ...
            }


            //using (DMSClient dms = new DMSClient())
            //{
                
            //    return dms.UploadFile(uploadInfo);                
            //}
        }

        public static string GetXmlForLargeFile(FileUploadInfo info, int fileSize)
        {
            string endpointUrl = "http://43dmsw2/DMSServiceDev_V5/DMS.svc";

            // 2. Create the binding and endpoint address programmatically
            var binding = new BasicHttpBinding(); // Use the correct binding type (e.g., WSHttpBinding)
            var endpointAddress = new EndpointAddress(endpointUrl);

            using (DMSClient dms = new DMSClient(binding, endpointAddress))
            {
                return dms.GetXMLForLargeFile(info, fileSize);
            }
        }

        public static DeleteResponse Delete(DeleteFileInfo deleteFileInfo)
        {
            using (DMSClient dms = new DMSClient())
            {
                return dms.DeleteFile(deleteFileInfo);
            }
        }

        public static ResponseBase Update(ReplaceDataInfo replaceDataInfo)
        {
            using (DMSClient dms = new DMSClient())
            {
                return dms.ReplaceData(replaceDataInfo);
        }
        }

      


    }

}
