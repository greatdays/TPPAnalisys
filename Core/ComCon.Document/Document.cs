using ComCon.DMS.Models;
using HCIDLA.ServiceClient.LaserFiche;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace ComCon.DMS
{
    public class Document
    {
        #region Properties
        public List<string> DocumentTypes { get; set; }
        public List<string> DocumentGroup { get; set; }

        public Dictionary<ReferenceType, string> References { get; set; }

        #endregion 


        #region Upload file temporarily
        /// <summary>
        ///  Upload file temporarily
        /// </summary>
        /// <param name="file"></param>
        /// <param name="errorMessage"></param>
        /// <param name="context"></param>
        /// <param name="refId"></param>
        /// <param name="DocumentType"></param>
        /// <param name="IsVirusScanOn"></param>
        /// <param name="UploadFilePath"></param>
        /// <param name="refType"></param>
        /// <returns></returns>
        public string TemporaryUploadFile(out string errorMessage,
            HttpPostedFileBase file,
            Dictionary<ReferenceType, string> docReference,
            string documentType,
            List<string> docGroup,
            ControllerContext context,
            bool IsVirusScanOn = false,
            string UploadFilePath = "\\Documents"
            )
        {
            //check for required parameter
            if (file == null)
            {
                throw new ArgumentNullException("file");
            }
            //if (docReference.Count == 0)
            //{
            //    throw new ArgumentNullException("docReference");
            //}

            //check for existing session
            if (context.HttpContext.Session[$"FileList{documentType}"] == null)
            {
                context.HttpContext.Session[$"FileList{documentType}"] = new RefDocumentModel();
            }

            RefDocumentModel docs = (RefDocumentModel)context.HttpContext.Session[$"FileList{documentType}"];

            if (docs.FolderName == null)
            {
                docs.FolderName = Guid.NewGuid().ToString();
            }

            string tempFileDir = GetTempDirectory(docs.FolderName + "\\" + documentType, UploadFilePath); // Get Temporary file directory.
            string fileExtension = Path.GetExtension(file.FileName); // Get file extension.
            string time = DateTime.Now.ToString("ddMMyyyyHHmmss"); // Get current date and time
            string fileName = Guid.NewGuid().ToString() + "^" + file.FileName.Substring(0, file.FileName.LastIndexOf('.')) + "_" + time + fileExtension; // Set fileName

            errorMessage = string.Empty;
            if (!IsVirusScanOn)
            {
                // Save file to the target location
                file.SaveAs(Path.Combine(tempFileDir, fileName));
            }
            else if (IsVirusScanOn && HCIDLA.ServiceClient.VirusScan.VirusScan.ScanForVirus(file))
            {
                // Save file to the target location
                file.SaveAs(Path.Combine(tempFileDir, fileName));
            }
            else
            {
                errorMessage = "File is infected with Virus";
                fileName = "";
            }
            int size = file.ContentLength;
            string filePath = "~" + UploadFilePath + "\\" + docs.FolderName + "\\" + documentType + "\\" + fileName;

            // Adds the document in Session            
            if (docs.DocumentModel == null)
            {
                docs.DocumentModel = new List<DocumentModel>();
            }
            // Add the document in DocumentModel
            docs.DocumentModel.Add(new DocumentModel
            {
                FileName = fileName,
                FilePath = filePath,
                DocumentType = new List<string> { documentType },
                Group = docGroup,
                DocReferences = docReference,
                Size = Convert.ToString(size),
                Comment = ""
            });
            return fileName;
        }

        public void UpdateDocReferenceInSession(ControllerContext context, string documentType, Dictionary<ReferenceType, string> docReference)
        {
            RefDocumentModel model = (RefDocumentModel)context.HttpContext.Session[$"FileList{documentType}"];
            if (model?.DocumentModel != null)
            {
                foreach (DocumentModel doc in model.DocumentModel)
                {
                    doc.DocReferences = docReference;
                }
            }
        }

        #endregion

        #region Delete temp File

        /// <summary>
        /// Delete temp uploaded documents from session and temp location
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="documentType"></param>
        /// <param name="context"></param>
        /// <param name="UploadFilePath"></param>
        public void DeleteTempUplodedFile(string fileName, string documentType, ControllerContext context, string UploadFilePath = "\\Documents")
        {
            RefDocumentModel docs = (RefDocumentModel)context.HttpContext.Session[$"FileList{documentType}"];
            if (docs != null)
            {
                string tempFileDir = "~" + UploadFilePath + "\\" + docs.FolderName + "\\" + documentType;
                string filePath = Path.Combine(tempFileDir, fileName); //  Combine path

                /* Check if file exists and if exists then delete */
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                if (docs.DocumentModel != null && docs.DocumentModel.Count > 0)
                {
                    // Remove Document from list          
                    DocumentModel docFile = docs.DocumentModel.Find(m => m.FileName == fileName);

                    if (docFile != null)
                    {
                        docs.DocumentModel.Remove(docFile);
                    }
                }
            }
        }

        #endregion


        #region Creates and Returns temperory Directory
        /// <summary>
        /// Creates and Returns temperory Directory
        /// </summary>
        /// <param name="tempDir"></param>
        /// <param name="UploadFilePath"></param>
        /// <returns></returns>
        private string GetTempDirectory(string tempDir
            , string UploadFilePath = "\\Documents")
        {
            /* Get Temporary File location */
            string tempFileDir = HttpContext.Current.Server.MapPath("~" + UploadFilePath);
            string folderName = tempDir + "\\";
            string tempPath = Path.Combine(tempFileDir, folderName); // Combine the path folder path

            ///* Check if temp. folder exists in directory */
            if (!Directory.Exists(tempFileDir))
            {
                /* Intialize directory security objects */
                DirectorySecurity securityRules = new DirectorySecurity();
                SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                securityRules.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.FullControl | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));

                Directory.CreateDirectory(tempFileDir, securityRules); // Create directories with folder name
            }

            /* Check if folder exists in directory */
            if (!Directory.Exists(tempPath))
            {
                string[] subdirectoryEntries = Directory.GetDirectories(tempFileDir); // Get all the directories
                /* Intialize directory security objects */
                DirectorySecurity securityRules = new DirectorySecurity();
                SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                securityRules.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.FullControl | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                Directory.CreateDirectory(tempPath, securityRules); // Create directories with folder name
            }

            return tempPath;
        }
        #endregion

        #region Get File content Type
        /// <summary>
        /// Get File content Type
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns>contentType</returns>
        public string GetFileContentType(string fileExtension)
        {
            string contentType = string.Empty;

            switch (fileExtension)
            {
                case ".pdf":
                    contentType = "application/pdf";
                    break;
                case ".jpeg":
                    contentType = "image/jpeg";
                    break;
                case ".png":
                    contentType = "image/png";
                    break;
                case ".tiff":
                    contentType = "image/tiff";
                    break;
                case ".tif":
                    contentType = "image/tif";
                    break;
                case ".bmp":
                    contentType = "image/bmp";
                    break;
                case ".gif":
                    contentType = "image/gif";
                    break;
                case ".jpg":
                    contentType = "image/jpg";
                    break;
                case ".doc":
                    contentType = "application/msword";
                    break;
                case ".dot":
                    contentType = "application/msword.docx";
                    break;
                case ".docx":
                    contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                case ".xls":
                case ".xlt":
                case ".xla":
                    contentType = "application/vnd.ms-excel";
                    break;
                case ".xlsx":
                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    break;
                case ".xltx":
                    contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.template";
                    break;
                default:
                    contentType = "";
                    break;
            }

            return contentType;
        }

        #endregion

        #region Save Document

        /// <summary>
        /// Save reference Document
        /// </summary>
        /// <param name="refId"></param>
        /// <param name="context"></param>
        /// <param name="userName"></param>
        /// <param name="refType"></param>
        /// <returns></returns>
        public List<DocumentModel> SaveDocuments(ControllerContext context, string userName, string documentType)
        {
            List<DocumentModel> returnModel = new List<DocumentModel>();
            RefDocumentModel model = (RefDocumentModel)context.HttpContext.Session[$"FileList{documentType}"];
            if (model != null)
            {
                returnModel = RefDocumentModel.SaveDocument(new RefDocumentModel
                {
                    DocumentModel = model.DocumentModel,
                    UserName = userName
                });
                context.HttpContext.Session[$"FileList{documentType}"] = null;
            }
            return returnModel;
        }

        #endregion

        #region Save file to DMS 

        /// <summary>
        /// Save file to DMS 
        /// </summary>
        /// <param name="refId"></param>
        /// <param name="serviceRequestId"></param>
        /// <param name="APN"></param>
        /// <param name="userName"></param>
        /// <param name="refType"></param>
        /// <param name="useFakeDMS"></param>
        /// <returns></returns>
        public static bool SaveFileToDMS(string refId, long serviceRequestId, string APN, string userName, ReferenceType refType = ReferenceType.Case, bool useFakeDMS = false, string FolderGUID="")
        {
            bool UpdateCaseDoument = true;

            List<DocumentModel> objDocumentModel = GetDocument(refId, refType);
            List<DMSDocument> document = new List<DMSDocument>();
            foreach (DocumentModel item in objDocumentModel)
            {
                if (!Guid.TryParse(item.FilePath, out Guid guid))
                {
                    DMSDocument doc = new DMSDocument();
                    string fileAt = Path.Combine(HttpContext.Current.Server.MapPath(item.FilePath));
                    doc.DocumentByte = System.IO.File.ReadAllBytes(fileAt);
                    doc.DocumentName = item.FileName.Contains("^") ? item.FileName.Split('^')[1] : item.FileName;
                    doc.DocumentID = item.DocumentID;
                    doc.documentType = item.DocumentType != null && item.DocumentType.Count > 0 ? item.DocumentType[0] : "";
                    if (string.IsNullOrEmpty(FolderGUID))
                    {
                        doc.FolderGUID = Document.GetLaserFichGUIDbyDocumentAttribute("Type", doc.documentType);
                    }
                    if (System.IO.File.Exists(fileAt))
                    {
                        System.IO.File.Delete(fileAt);
                    }

                    document.Add(doc);
                }
            }

            if (Directory.Exists(HttpContext.Current.Server.MapPath("\\" + refType.ToString() + refId)))
            {
                Directory.Delete(HttpContext.Current.Server.MapPath("\\" + refType.ToString() + refId));
            }

            HCIDLA.ServiceClient.LaserFiche.Document DMSDoc = new HCIDLA.ServiceClient.LaserFiche.Document();
            List<DMSResponse> fileUploadSuccessStatus = DMSDoc.UploadMultipleFiles(document, APN, Convert.ToString(serviceRequestId), "", DateTime.Now.Year.ToString(), useFakeDMS, FolderGUID, userName);
            if (fileUploadSuccessStatus.Count > 0)
            {
                UpdateCaseDoument = RefDocumentModel.UpdateDMSIdInDocument(new RefDocumentModel { DMSResponse = fileUploadSuccessStatus, UserName = userName });
            }
            return UpdateCaseDoument;
        }
        #endregion

        #region Get Document

        /// <summary>
        ///  Get Reference Document
        /// </summary>
        /// <param name="refId"></param>
        /// <param name="refType"></param>
        /// <param name="documentType"></param>
        /// <returns></returns>
        public static List<DocumentModel> GetDocument(string refId, ReferenceType refType = ReferenceType.Case, string documentType = null)
        {
            return RefDocumentModel.GetDocument(refId, refType, documentType);
        }
        #endregion

        #region  Function used for getting String value from enum

        /// <summary>
        /// This function is used for getting String value from enum
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>String</returns>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
        #endregion

        #region Delete Document
        /// <summary>
        /// Delete Document
        /// </summary>
        /// <param name="documentId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool DeleteDocument(int documentId, string userName)
        {
            return RefDocumentModel.DeleteDocument(documentId, userName);
        }
        #endregion

        #region DocumentAttribute
        public static List<KeyValuePair<string, string>> GetLutDocumentAttributeByName(string attributeName)
        {
            return RefDocumentModel.GetLutDocumentAttributeByName(attributeName);
        }

        public static string GetLaserFichGUIDbyDocumentAttribute(string attributeName, string type)
        {
            return RefDocumentModel.GetLaserFichGUIDbyDocumentAttribute(attributeName, type);
        }
        #endregion

        #region Generate Document from TMS
        public static DocumentModel GenerateDocumentfromTemplete<T>(
            string TMSName,
            T data,
            int docTemplateId,
            List<string> documentType,
            List<string> documentGroup,
            Dictionary<ReferenceType, string> references,
            string templateName,
            string webAPIURL,
            bool isSaveDocument,
            string userName,
            bool useFakeTMS = false,
            bool useFakeDMS = false)
        {
            DocumentModel document = new DocumentModel
            {
                FileContent = HCIDLA.ServiceClient.TemplateManagement.Template.GenerateDocument<T>(TMSName, data, webAPIURL, useFakeTMS),
                DocumentType = documentType,
                Group = documentGroup,
                FileName = TMSName + ".pdf",
                DocumentTemplate = templateName,
                DocumentTemplateId = docTemplateId,
                DocumentEntity = JsonConvert.SerializeObject(data)
            };
            document.Size = Convert.ToString(document.FileContent != null && document.FileContent.Length > 0 ? document.FileContent.Length : 0);
            document.DocReferences = references;
            string caseId = string.Empty;
            if (isSaveDocument)
            {
                DMSResponse response = null;
                references.TryGetValue(ReferenceType.Case, out caseId);
                if (!useFakeDMS)
                {
                    HCIDLA.ServiceClient.LaserFiche.Document ldoc = new HCIDLA.ServiceClient.LaserFiche.Document();

                    string cagy = Convert.ToString(document.DocumentTemplate);

                    if (Convert.ToString(document.DocumentTemplate).Length > 38)
                    {
                        cagy = Convert.ToString(document.DocumentTemplate).Substring(0, 38);
                    }
                    references.TryGetValue(ReferenceType.APN, out string APN);
                   
                    string GUID = GetLaserFichGUIDbyDocumentAttribute("Type", documentType.Count>0? documentType[0] : "");

                    response = ldoc.SaveDocument(document.FileContent, document.FileName, APN, caseId, cagy, DateTime.Now.Year.ToString(), GUID);
                }
                else
                {
                    response = new DMSResponse { UniqueId = Guid.NewGuid().ToString() };
                }

                document.FilePath = response.UniqueId;

                List<DocumentModel> docs = new List<DocumentModel>
                        {
                            document
                        };

                
          

                RefDocumentModel.SaveDocument(new RefDocumentModel
                {
                    DocumentModel = docs,
                    UserName = userName
                });



            }
            return document;
        }

        /// <summary>
        ///  Delete Document By ReferenceID and ReferenceType (isDelete update)
        /// </summary>
        /// <param name="refID"></param>
        /// <param name="refType"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool DeleteDocumentByReferenceID(string refID, ReferenceType refType, string userName)
        {
            return RefDocumentModel.DeleteDocumentByReferenceID(refID, refType, userName);

        }
        #endregion
    }

    //public enum ReferenceType
    //{
    //    Case,
    //    ServiceRequest,
    //    Inspection,
    //    Violation,
    //    Notice,
    //    Contact,
    //    PropSnapshot,
    //    Home
    //}
}
