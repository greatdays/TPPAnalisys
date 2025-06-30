using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DeveloperPortal.DataAccess.Entity.Data.AAHREntities;

namespace DeveloperPortal.DataAccess.Entity.Models.Generated
{
    [MetadataType(typeof(CaseMD))]
    public partial class Case : IAuditable
    {
        /// <summary>
        /// Meta Data class for Case
        /// </summary>
        public class CaseMD
        {
            public int CaseID { get; set; }
            public int CaseTypeID { get; set; }
            public string Summary { get; set; }
            public string Description { get; set; }
            public string Status { get; set; }
            public Nullable<short> AssigneeID { get; set; }
            public string AssigneeName { get; set; }
        }

        internal static Case GetCase(string id)
        {
            using (var db = new AAHREntities())
            {
                return db.Cases.Find(int.Parse(id));
            }
        }

        internal static string GetCurrentState(string id)
        {
            string status = null;

            using (var db = new AAHREntities())
            {
                status = db.Cases.Find(int.Parse(id)).Status;
            }

            return status;
        }

        internal static ICollection<CaseLog> GetCaseLogs(string id)
        {
            ICollection<CaseLog> caseLogs = null;
            
            using (var db = new AAHREntities())
            {
                caseLogs = db.Cases.Find(int.Parse(id)).CaseLogs;
            }

            return caseLogs;
        }
    }
}
