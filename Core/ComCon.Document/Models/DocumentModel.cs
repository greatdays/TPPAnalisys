using ComCon.Document.Entity;
using HCIDLA.ServiceClient.LaserFiche;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Configuration;

namespace ComCon.DMS.Models
{
    #region Document Model
    /// <summary>
    /// Document Model
    /// </summary>
    public class DocumentModel
    {
        [Required]
        public string FileName { get; set; }

        [Required]
        public string FilePath { get; set; }

        public int DocumentID { get; set; }
        public int? DocumentTypeId { get; set; }

        [Required]
        public List<string> DocumentType { get; set; }
        public List<string> Group { get; set; }

        public Dictionary<ReferenceType, string> DocReferences { get; set; }

        public string OtherDocumentType { get; set; }
        public string Size { get; set; }

        public string Comment { get; set; }
        public DateTime? ExpDate { get; set; }
        public string Attributes { get; set; }
        public string ServiceTrackingID { get; set; }

        public int DocumentTemplateId { get; set; }
        public string DocumentTemplate { get; set; }
        public string DocumentNum { get; set; }
        public string DocumentEntity { get; set; }
        public Nullable<bool> IsCurrent { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public byte[] FileContent { get; set; }
        public int PropSnapShotId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

    }
    #endregion

    public enum DocumentType
    {
        [Description("Government Order")]
        GovernmentOrderRecived,

        [Description("Acceptance Letter")]
        AcceptanceLetter,

        [Description("Permanent Relocation")]
        PermanentReloationForm,

        [Description("Per Diem Agreement")]
        PerDiem,

        [Description("Moving or Storage Agreement")]
        MovingStorage,

        [Description("3rd Party Agreement")]
        AgreementByParty,

        [Description("Tenant information")]
        TenantInformation,

        [Description("Declaration Require More Info")]
        DeclarationRequireMoreInfo,

        [Description("Submit Declaration Offline")]
        SubmitDeclarationOffline,

        [Description("Appeal")]
        MarkAppeal,

        [Description("Supplemental Documents")]
        SupplementalDocuments,

        [Description("Appelant Additional Documents")]
        AppelantAdditionalDocuments,

        [Description("Fee Waiver Form")]
        FeeWaiverForm,

        [Description("GMCheckList Property")]
        GMCheckListProperty,

        [Description("GMCheckList Owner")]
        GMCheckListOwner,

        [Description("GMCheckList Schedule")]
        GMCheckListSchedule,

        [Description("GMCheckList Order")]
        GMCheckListOrder,

        [Description("GMCheckList Documents")]
        GMCheckListDocuments,

        [Description("GMCheckList Worklog")]
        GMCheckListWorklog,

        [Description("GMCheckList")]
        GMCheckList,

        [Description("Project")]
        Project,

        [Description("ProjectSite")]
        ProjectSite
    }

    public enum ReferenceType
    {
        Case,
        ServiceRequest,
        Inspection,
        Violation,
        Notice,
        Contact,
        PropSnapshot,
        APN,
        FloorPlanType
    }

    public class DocumentAttributeModel
    {
        public List<string> Types { get; set; }
        public List<string> Groups { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

    public class DocumentAttribute
    {
        public string Type { get; set; }
        public string LaserficheID { get; set; }
    }

    public class RefDocumentModel
    {
        #region Property Declaration
        public List<DocumentModel> DocumentModel { get; set; }

        public string RefId { get; set; }

        public string FolderName { get; set; }

        public ReferenceType RefType { get; set; }

        public string ServiceRequestID { get; set; }

        public string APN { get; set; }

        [Required]
        public string UserName { get; set; }

        public List<DMSResponse> DMSResponse { get; set; }

        #endregion


        #region Save Case Document

        /// <summary>
        /// Save Case Document
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<DocumentModel> SaveDocument(RefDocumentModel model)
        {
            //List<DocumentModel> DocumentModelList = new List<DocumentModel>();

            using (DMSEntities db = DMSEntities.GetDMSConnection())
            {
                // Saves the document data in Document table against ReferenceID and ReferenceType.

                if (model.DocumentModel != null)
                {
                    foreach (DocumentModel doc in model.DocumentModel)
                    {
                        ComCon.Document.Entity.DocumentTemplate template = null;

                        //ComCon.Document.Entity.DocumentType docType = db.DocumentTypes.Where(m => m.Type == doc.DocumentType).FirstOrDefault();

                        if (doc.DocumentTemplateId != 0)
                        {
                            template = db.DocumentTemplates.Find(doc.DocumentTemplateId);
                        }
                        string filename = doc.FileName.IndexOf("^") > -1 ? doc.FileName.Substring(doc.FileName.IndexOf("^") + 1) : doc.FileName;
                        var attributes = new
                        {
                            Types = doc.DocumentType != null ? doc.DocumentType.ToArray() : new List<string> { }.ToArray(),
                            Groups = doc.Group != null ? doc.Group.ToArray() : new List<string> { }.ToArray()
                        };
                        ComCon.Document.Entity.Document d = new ComCon.Document.Entity.Document
                        {
                            //DocumentType = docType,
                            //OtherDocumentType = doc.OtherDocumentType,
                            Name = filename,
                            Link = doc.FilePath,
                            FileSize = doc.Size,
                            CreatedBy = model.UserName,
                            CreatedOn = System.DateTime.Now,
                            ExpDate = doc.ExpDate == null ? doc.ExpDate : Convert.ToDateTime(doc.ExpDate),
                            Comment = doc.Comment,
                            DocumentNum = doc.DocumentNum,
                            DocumentTemplate = template,
                            DocumentEntity = doc.DocumentEntity,
                            ServiceTrackingID = doc.ServiceTrackingID,
                            Attributes = JsonConvert.SerializeObject(attributes)
                        };
                        foreach (KeyValuePair<ReferenceType, string> reference in doc.DocReferences)
                        {
                            d.AssnDocuments.Add(new AssnDocument { ReferenceID = reference.Value, ReferenceType = reference.Key.ToString() });
                        }

                        db.Documents.Add(d);
                    }

                    int recordStat = db.SaveChanges(model.UserName);

                    //string refId = Convert.ToString(model.RefId);
                    //string referenceType = Convert.ToString(model.RefType);

                    //if (recordStat > -1)
                    //{
                    //    foreach (DocumentModel item in model.DocumentModel)
                    //    {
                    //        DocumentModel docmodel = new DocumentModel
                    //        {
                    //            DocumentID = db.AssnDocuments
                    //                            .Where(y => y.ReferenceID == refId && y.ReferenceType == referenceType && y.Document.Name == item.FileName)
                    //                            .Select(x => x.DocumentID)
                    //                            .FirstOrDefault()
                    //        };
                    //        DocumentModelList.Add(docmodel);
                    //    }
                    //}
                    //else
                    //{
                    //    DocumentModelList = null;
                    //}
                }

            }
            return model.DocumentModel;
        }


        #endregion

        #region Update Case Document
        /// <summary>
        /// Update Case Document with UniqueId from DMS
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateDMSIdInDocument(RefDocumentModel model)
        {
            bool updateCaseDoc = false;
            using (DMSEntities db = DMSEntities.GetDMSConnection())
            {
                if (model.DMSResponse.Count > 0)
                {
                    // Update the link column in CaseDocument table after documents get saved at DMS with UniqueId. 
                    foreach (DMSResponse item in model.DMSResponse)
                    {
                        ComCon.Document.Entity.Document cDoc = db.Documents.Where(x => x.DocumentID == item.DocumentID).FirstOrDefault();
                        cDoc.Name = item.FileName;
                        cDoc.Link = item.UniqueId;
                    }

                    int recordStat = db.SaveChanges(model.UserName);

                    if (recordStat > 0)
                    {
                        updateCaseDoc = true;
                    }
                    else
                    {
                        updateCaseDoc = false;
                    }
                }


                return updateCaseDoc;
            }

        }
        #endregion  

        #region Get Case Document
        /// <summary>
        /// Get Case Document 
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns></returns>
        public static List<DocumentModel> GetDocument(string refId, ReferenceType refType = ReferenceType.Case, string documentType = "")
        {
            List<DocumentModel> documentModel = new List<DocumentModel>();
            string refTypes = refType.ToString();
            string refPropSnapshot = ReferenceType.PropSnapshot.ToString();

            using (DMSEntities db = DMSEntities.GetDMSConnection())
            {
                if (!string.IsNullOrEmpty(refId))
                {
                    // Get doument list from Documents table with CaseID.
                    IQueryable<AssnDocument> documents = db.AssnDocuments
                         .Where(y => y.ReferenceID == refId && y.ReferenceType == refTypes && y.Document.IsDeleted != true);

                    foreach (AssnDocument doc in documents)
                    {
                        DocumentModel model = new DocumentModel();
                        if (!string.IsNullOrEmpty(doc.Document.Attributes))
                        {
                            DocumentAttributeModel attributes = JsonConvert.DeserializeObject<DocumentAttributeModel>(doc.Document.Attributes);
                            model.DocumentType = attributes.Types;
                            model.Group = attributes.Groups;
                        }

                        model.FileName = doc.Document.Name;
                        model.FilePath = doc.Document.Link;
                        model.DocumentID = doc.DocumentID;
                        model.CreatedBy = doc.CreatedBy;
                        model.CreatedOn = doc.CreatedOn;
                        model.DocumentTemplate = (doc.Document.DocumentTemplate != null ? doc.Document.DocumentTemplate.LutTemplate.TemplateName : "");
                        documentModel.Add(model);
                    }

                    if (!string.IsNullOrEmpty(documentType))
                    {
                        // Get doument list from Documents table with document type.
                        documentModel = documentModel.Where(x => x.DocumentType.Contains(documentType)).ToList();
                    }
                }
            }

            return documentModel;
        }
        #endregion

        #region Get Document Template 
        /// <summary>
        /// Get Document type by Template name
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public static string GetDocumentTypeByTemplate(string templateName)
        {
            if (!string.IsNullOrEmpty(templateName))
            {
                using (DMSEntities db = DMSEntities.GetDMSConnection())
                {
                    IQueryable<LutTemplate> templates = db.LutTemplates.Where(m => m.TemplateName.Contains(templateName));
                    return templates != null && templates.Count() > 0 ? templates.FirstOrDefault().DocumentType : string.Empty;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Get Document Templates
        /// </summary>
        /// <param name="template"></param>
        /// <returns>DocumentTemplate</returns>
        public static List<DocumentTemplate> GetDocumentTemplates(string documentType)
        {
            if (!string.IsNullOrEmpty(documentType))
            {
                using (DMSEntities db = DMSEntities.GetDMSConnection())
                {
                    List<LutTemplate> templates = db.LutTemplates.Where(m => m.DocumentType.ToLower() == documentType.ToLower() && m.IsObsolete == false).ToList();

                    List<DocumentTemplate> docTemplates = new List<DocumentTemplate>();

                    foreach (LutTemplate t in templates)
                    {
                        ComCon.Document.Entity.DocumentTemplate temp = t.DocumentTemplates.OrderByDescending(m => m.DocumentTemplateID).FirstOrDefault(x => x.IsDeleted == false && x.IsActive == true);
                        if (temp != null)
                        {
                            DocumentTemplate template = new DocumentTemplate
                            {
                                TemplateName = t.TemplateName,
                                Description = t.Description,
                                DocumentType = t.DocumentType,
                                DocumentTemplateId = temp.DocumentTemplateID,
                                TMSName = temp.TMSName
                            };
                            docTemplates.Add(template);
                        }
                    }
                    return docTemplates;
                }
            }
            return null;
        }

        #endregion

        #region Delete Document
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DocumentId"></param>
        /// <returns></returns>
        public static bool DeleteDocument(int DocumentId, string userName)
        {
            bool updateCaseDoc = false;
            using (DMSEntities db = DMSEntities.GetDMSConnection())
            {
                ComCon.Document.Entity.Document cDoc = db.Documents.Where(x => x.DocumentID == DocumentId).FirstOrDefault();
                cDoc.IsDeleted = true;

                int recordStat = db.SaveChanges(userName);

                if (recordStat > 0)
                {
                    updateCaseDoc = true;
                }
                else
                {
                    updateCaseDoc = false;
                }
            }

            return updateCaseDoc;

        }
        #endregion

        #region DocumentAttribute
        public static List<KeyValuePair<string, string>> GetLutDocumentAttributeByName(string attributeName)
        {
            List<KeyValuePair<string, string>> selectList = new List<KeyValuePair<string, string>>();
            using (DMSEntities db = DMSEntities.GetDMSConnection())
            {
                // get lut document attribute by name.
                string attribute = db.LutDocumentAttributes.FirstOrDefault(w => w.AttributeName == attributeName)?.AttributeValue;
                if (null != attribute)
                {
                    // split attribute value.
                    List<DocumentAttribute> attributeArray = JsonConvert.DeserializeObject<List<DocumentAttribute>>(attribute);

                    // add to select list.
                    selectList = attributeArray.Select(s => new KeyValuePair<string, string>(s.Type, s.Type)).ToList();
                }
            }
            return selectList; // return.
        }

        public static string GetLaserFichGUIDbyDocumentAttribute(string attributeName, string type)
        {
            string GUID = string.Empty;
            using (DMSEntities db = DMSEntities.GetDMSConnection())
            {
                // get lut document attribute by name.
                string attribute = db.LutDocumentAttributes.FirstOrDefault(w => w.AttributeName == attributeName)?.AttributeValue;
                if (null != attribute)
                {
                    // split attribute value.
                    List<DocumentAttribute> attributeArray = JsonConvert.DeserializeObject<List<DocumentAttribute>>(attribute);

                    // add to select list.
                    GUID = attributeArray.FirstOrDefault(s => s.Type == type)?.LaserficheID;
                }
            }
            if (string.IsNullOrEmpty(GUID))
            {
                GUID = WebConfigurationManager.AppSettings.Get("DMSAppIdExternal");
            }
            return GUID;
        }

        /// <summary>
        ///  Delete Document By ReferenceID and ReferenceType
        /// </summary>
        /// <param name="refID"></param>
        /// <param name="refType"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool DeleteDocumentByReferenceID(string refID, ReferenceType refType, string userName)
        {
            bool updateCaseDoc = false;
            using (DMSEntities db = DMSEntities.GetDMSConnection())
            {
                var docIds = db.AssnDocuments.Where(p => p.ReferenceID == refID && p.ReferenceType == refType.ToString()).Select(x => x.DocumentID).ToList();

                foreach (var item in docIds)
                {
                    updateCaseDoc = DeleteDocument(item, userName);
                }
            }

            return updateCaseDoc;

        }

        #endregion
    }


}
