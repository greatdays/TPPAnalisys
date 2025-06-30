using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.Domain.PropertySnapshot;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.Application.PropertySnapshot
{
    public class ServiceRequestsService
    {
        public ServiceRequestModel GetServiceRequestById(int caseId)
        {
            ServiceRequestModel serviceRequestModel = new ServiceRequestModel();
                        
            using (AAHREntities _dbContext = new AAHREntities())
            {
                var sr = _dbContext.ServiceRequests
                    .Include(x => x.PropSnapshots)
                    
                    .Include(x=>x.Case.CaseType)
                    .Where(x => x.CaseId == caseId).FirstOrDefault();

                if (sr != null)
                {
                    serviceRequestModel.ServiceRequestId = sr.ServiceRequestId;
                    serviceRequestModel.CaseId = sr.CaseId;
                    serviceRequestModel.ServiceRequestTypeId = sr.LutServiceRequestTypeId;
                    serviceRequestModel.ServiceRequestNumber = sr.ServiceRequestNumber;
                    serviceRequestModel.ServiceTrackingId = sr.ServiceTrackingId;
                    serviceRequestModel.ProgramCycleId = sr.LutProgramCycleId;
                    serviceRequestModel.PropSnapshotId = sr.PropSnapshots.FirstOrDefault().PropSnapshotId;
                    serviceRequestModel.ProjectID = sr.PropSnapshots.FirstOrDefault()?.ProjectId;
                    serviceRequestModel.SiteAddress = sr.PropSnapshots.FirstOrDefault()?.IdentifierType == Domain.PropertySnapshot.Constants.IdentifierTypeProject
                                                        ? _dbContext.PropSnapshots.FirstOrDefault(x => x.ProjectId == serviceRequestModel.ProjectID && x.IdentifierType == "ProjectSite")?.SiteAddress?.FullAddress
                                                        : sr.PropSnapshots.FirstOrDefault()?.SiteAddress?.FullAddress;
                    serviceRequestModel.APN = sr.PropSnapshots.FirstOrDefault().Apn?.Apn1;
                    serviceRequestModel.Status = sr.Case.Status;
                    serviceRequestModel.APNAttributes = sr.PropSnapshots.FirstOrDefault().Apn?.Attributes;
                    serviceRequestModel.ServiceRequestAttributes = sr.Attributes;
                    var obj = sr.PropSnapshots.FirstOrDefault()?.Project;
                    serviceRequestModel.RefProjectID = sr.PropSnapshots.FirstOrDefault()?.Project?.RefProjectId;
                    serviceRequestModel.RefProjectSiteID = sr.PropSnapshots.FirstOrDefault()?.IdentifierType == Domain.PropertySnapshot.Constants.IdentifierTypeProject
                                                            ? _dbContext.PropSnapshots.FirstOrDefault(x => x.ProjectId == serviceRequestModel.ProjectID && x.IdentifierType == "ProjectSite")?.ProjectSite?.RefProjectSiteId
                                                            : sr.PropSnapshots.FirstOrDefault()?.ProjectSite?.RefProjectSiteId;
                    serviceRequestModel.CaseType = sr.Case.CaseType.Type;
                    serviceRequestModel.FileNumber = sr.PropSnapshots.FirstOrDefault()?.IdentifierType == Domain.PropertySnapshot.Constants.IdentifierTypeProject
                                                        ? _dbContext.PropSnapshots.FirstOrDefault(x => x.ProjectId == serviceRequestModel.ProjectID && x.IdentifierType == "ProjectSite")?.ProjectSite?.FileNumber
                                                        : sr.PropSnapshots.FirstOrDefault()?.Project.ProjectSites.FirstOrDefault()?.FileNumber;
                    serviceRequestModel.ProjectName = sr.PropSnapshots.FirstOrDefault()?.Project?.ProjectName;
                    serviceRequestModel.ProjectSiteID = sr.PropSnapshots.FirstOrDefault()?.IdentifierType == Domain.PropertySnapshot.Constants.IdentifierTypeProject
                                                        ? _dbContext.PropSnapshots.FirstOrDefault(x => x.ProjectId == serviceRequestModel.ProjectID && x.IdentifierType == "ProjectSite")?.ProjectSiteId
                                                        : sr.PropSnapshots.FirstOrDefault()?.ProjectSiteId;
                    serviceRequestModel.CESType = "";// sr.PropSnapshots.FirstOrDefault()?.Project.ProjectSites.FirstOrDefault()?.LutCESType?.CESType;
                    serviceRequestModel.ServiceRequestComments = sr.ServiceRequestComments;
                }
            }

            return serviceRequestModel;
        }

        /// <summary>
        /// Get APN by Case
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns></returns>
        public string GetAPNByCase(int caseId)
        {
            string apn = null;

            using (AAHREntities _dbContext = new())
            {
                var sr = _dbContext.ServiceRequests.Where(x => x.CaseId == caseId).FirstOrDefault();

                if (sr != null)
                {
                    apn = sr?.PropSnapshots?.FirstOrDefault(x => x.IdentifierType == "APN")?.Apn?.Apn1;
                }
            }

            return apn;
        }
    }
}
