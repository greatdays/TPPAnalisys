
using HCIDLA.ServiceClient.DMS;
//using Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace AcHP.DataAccess.ViewModels.DMS
{
    public class DMSInventory
    {
        public Guid ApplicationId { get; } = new Guid(WebConfigurationManager.AppSettings.Get("DMSAppIdExternal"));

        public DateTime FromDate { get; set; } = new DateTime(2017, 1, 1);
        public DateTime ToDate { get; set; } = DateTime.Now;
        public DataTable ResultTable { get; set; } = new DataTable();
        public Dictionary<FieldType, string[]> Filters { get; set; } = new Dictionary<FieldType, string[]>();
        public DMSInventory() { }
        public string GetResults()
        {
            try
            {
                using (DMSClient svc = new DMSClient())
                {
                    ReportParameters rp = new ReportParameters()
                    {
                        ApplicationId = ApplicationId,
                        DocumentType = DocType.AcHP,
                        Start = FromDate,
                        End = ToDate
                    };

                    rp.FieldFilters = Filters;

                    rp.SystemFields = new SysFieldType[]
                    {
                        SysFieldType.FileName,
                        SysFieldType.MimeType,
                        SysFieldType.FileSize,
                        SysFieldType.InternalURL,
                        SysFieldType.FileExtension,
                        SysFieldType.CreatedBy,
                        SysFieldType.ModifiedBy,
                        SysFieldType.CreatedOn,
                        SysFieldType.ModifiedOn,
                    };

                    SearchResponse response = svc.SearchFormReport(rp);

                    if (response.ReturnStatus != Status.Success)
                    {
                        return string.Join(",", response.ErrorMessages);
                    }
                    else
                    {
                        ResultTable = response.Results;
                        return string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.Error(ex);
                return ex.Message;
            }
        }
    }
}
