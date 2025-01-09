using DeveloperPortal.DataAccess.Entity.Models.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace DeveloperPortal.DataAccess.Entity.ViewModels
namespace DeveloperPortal.DataAccess.Entity.Models.Generated
{
    public class WFLogViewModel
    {
        internal void FetchDisplayConfiguration(WFNavigation_DisplayConfig wfNavigation_DisplayConfig)
        {
            //TODO: Need to enhance further
        }

        public ICollection<CaseLog> FetchParameterValues(string id)
        {
            /* Fetch CaseLog */
            return Case.GetCaseLogs(id);

        }
    }
}
