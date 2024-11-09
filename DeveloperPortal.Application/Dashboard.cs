using DeveloperPortal.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application
{
    public class Dashboard
    {
        public List<uspRoGetAllConstructionCasesResult> GetAllConstructionCases()
        {
            List<uspRoGetAllConstructionCasesResult> result = GetAllConstructionCasesData().Result;
            return result;
        }
        /// <summary>
        /// Get all construction cases to be displayed on the dashboard
        /// </summary>
        /// <returns>List</returns>
        private async Task<List<uspRoGetAllConstructionCasesResult>> GetAllConstructionCasesData()
        {
            AahrdevContext context = new AahrdevContext();
            List<uspRoGetAllConstructionCasesResult> result = await context.uspRoGetAllConstructionCases();

            return result;
        }
    }
}
