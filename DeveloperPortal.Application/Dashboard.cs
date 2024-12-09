using DeveloperPortal.DataAccess;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.Models;
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

        public List<AllConstructionCases> GetAllConstructionCasesForUser()
        {
            var allCases = GetAllConstructionCasesData().Result;
            List<AllConstructionCases> resultList = new List<AllConstructionCases>();
            if (allCases != null && allCases.Count > 0)
            {
                resultList = allCases.Select(x => new AllConstructionCases
                {

                    Type = x.Type,
                    CaseId = x.CaseId,
                    SiteCases = x.SiteCases,
                    ComplianceMatrixLink = x.ComplianceMatrixLink,
                    PropertyDetailsLink = x.PropertyDetailsLink,
                    Status = x.Status,
                    AssigneeID = x.AssigneeID,
                    Summary = x.Summary,
                    ProjectName = x.ProjectName,
                    ProjectAddress = x.ProjectAddress,
                    AcHPFileProjectNumber = x.AcHPFileProjectNumber,
                    ProblemProject = x.ProblemProject
                }).ToList();
            }
            return resultList;
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
