using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.Common
{
    public static class WebApiConstant
    {

        public const string DeleteContact = "api/ContactMgmt/Delete?contactId={0}&userName={1}&projectId={2}&projectSiteId={3}";
        public const string PostContact = "api/ContactMgmt/Save";
    }
}
