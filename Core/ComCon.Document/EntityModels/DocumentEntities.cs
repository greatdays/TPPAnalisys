using System;
using System.ComponentModel.DataAnnotations;

namespace ComCon.Document.Entity
{
    [MetadataType(typeof(DMSEntitiesMD))]
    public partial class DMSEntities
    {
        public class DMSEntitiesMD
        {
        }

        public DMSEntities(string connectionString)
            : base(connectionString)
        {
        }

        public static DMSEntities GetDMSConnection()
        {
            string ConnectionString = (System.Web.HttpContext.Current!=null && System.Web.HttpContext.Current.Session != null) ? Convert.ToString(System.Web.HttpContext.Current.Session["DMSConnectionString"]) : "";
            if (string.IsNullOrEmpty(ConnectionString))
            {
                return new DMSEntities();
            }
            else
            {
                return new DMSEntities(ConnectionString);
            }
        }
    }
}