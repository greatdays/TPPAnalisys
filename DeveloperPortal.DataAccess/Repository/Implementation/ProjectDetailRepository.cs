using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPortal.DataAccess.Repository.Implementation
{
    public class ProjectDetailRepository : IProjectDetailRepository
    {

        private readonly AAHREntities _context;


        public ProjectDetailRepository(AAHREntities context)
        {
            _context = context;
        }


        /// <summary>
        /// StructureAttribute
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <returns></returns>
        public async Task<StructureAttribute?> StructureAttribute(int propSnapshotId)
        {
            return await _context.StructureAttributes.FirstOrDefaultAsync(p => p.PropSnapshotId == propSnapshotId);
        }

        /// <summary>
        /// UpdateStructureAttributesAsync
        /// </summary>
        /// <param name="structureAttribute"></param>
        /// <returns></returns>
        public async Task<StructureAttribute> UpdateStructureAttributesAsync(StructureAttribute structureAttribute)
        {
            _context.StructureAttributes.Update(structureAttribute);
            await _context.SaveChangesAsync();
            return structureAttribute;
        }

        /// <summary>
        /// UnitAttribute
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <returns></returns>
        public async Task<UnitAttribute?> UnitAttribute(long propSnapshotId)
        {
            return await _context.UnitAttributes.FirstOrDefaultAsync(u => u.PropSnapshotId == propSnapshotId);
        }

        /// <summary>
        /// Unit
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <returns></returns>
        public async Task<Unit?> Unit(long propSnapshotId)
        {
            var prop = await _context.PropSnapshots.FirstOrDefaultAsync(p => p.PropSnapshotId == propSnapshotId);
            if (prop == null)
            {
                return null;
            }
            return await _context.Units.FirstOrDefaultAsync(u => u.UnitId == prop.UnitId);

        }


        /// <summary>
        /// AddUnit
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool> AddUnit(Unit unit, string userName)
        {
            _context.Units.Add(unit);
            return await SaveChangesWithAuditAsync(userName);
        }


        /// <summary>
        /// PolicyComplianceDetail
        /// </summary>
        /// <param name="serviceRequestId"></param>
        /// <returns></returns>
        public async Task<PolicyComplianceDetail?> PolicyComplianceDetail(long? serviceRequestId)
        {
            return await _context.PolicyComplianceDetails.Where(p => p.ServiceRequestId == serviceRequestId).FirstOrDefaultAsync();
        }



        /// <summary>
        /// AddPolicyComplianceDetail
        /// </summary>
        /// <param name="policyComplianceDetail"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool> AddPolicyComplianceDetail(PolicyComplianceDetail policyComplianceDetail, string userName)
        {
            policyComplianceDetail.CreatedBy = userName;
            policyComplianceDetail.CreatedOn = System.DateTime.Now;
            policyComplianceDetail.ModifiedBy = userName;
            policyComplianceDetail.ModifiedOn = System.DateTime.Now;
            _context.PolicyComplianceDetails.Add(policyComplianceDetail);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// UpdatePolicyComplianceDetail
        /// </summary>
        /// <param name="policyComplianceDetail"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool> UpdatePolicyComplianceDetail(PolicyComplianceDetail policyComplianceDetail, string userName)
        {
            policyComplianceDetail.ModifiedBy = userName;
            policyComplianceDetail.ModifiedOn = System.DateTime.Now;
            //_context.Entry(policyComplianceDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// SaveChangesWithAuditAsync
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool> SaveChangesWithAuditAsync(string userName)
        {
            await _context.SaveChangesWithAuditAsync(userName);
            return true;
        }

        /// <summary>
        /// AddPropSnapshots
        /// </summary>
        /// <param name="caseId"></param>
        /// <param name="ps"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool> AddPropSnapshots(int caseId, PropSnapshot ps, string userName)
        {
            var serviceRequest = _context.ServiceRequests.FirstOrDefault(s => s.CaseId == caseId);
            if (serviceRequest != null)
            {
                serviceRequest.PropSnapshots.Add(ps);
                return await SaveChangesWithAuditAsync(userName);
            }
            return false;
        }

        /// <summary>
        /// DeleteUnit
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<bool> DeleteUnit(int propSnapshotId, string username)
        {
            // mark a single construction unit and unitattribute record as deleted
            var propSnapshot = _context.PropSnapshots.Include(c => c.Unit).FirstOrDefault(x => x.PropSnapshotId == propSnapshotId && x.IdentifierType == "Unit");
            if (propSnapshot != null)
            {
                propSnapshot.Status = "X";
                if (propSnapshot.Unit != null)
                {
                    propSnapshot.Unit.Status = "X";
                    propSnapshot.Unit.IsDeleted = true;
                    propSnapshot.Unit.Attributes = "{\"Status\":\"X\"}";
                }
                //if (propsnapshot.UnitAttributes.FirstOrDefault() != null)
                //{
                //    propsnapshot.UnitAttributes.FirstOrDefault().IsDeleted = true;
                //}

                return await SaveChangesWithAuditAsync(username);
            }
            return true;
        }

        /// <summary>
        /// PropSnapshot By Building Type
        /// </summary>
        /// <param name="structureId"></param>
        /// <returns></returns>
        public async Task<List<PropSnapshot>> PropSnapshotByBuilding(int structureId)
        {
            return await _context.PropSnapshots.Where(x => x.StructureId == structureId && x.IdentifierType == "Building").ToListAsync();
        }

        /// <summary>
        /// PropSnapshot By Project
        /// </summary>
        /// <param name="projectSiteId"></param>

        /// <returns></returns>
        public async Task<PropSnapshot> PropSnapshotByProject(int projectSiteId)
        {
            return await _context.PropSnapshots.FirstOrDefaultAsync(x => x.ProjectSiteId == projectSiteId && x.IdentifierType == "ProjectSite");
        }

        /// <summary>
        /// LutTotalBedrooms
        /// </summary>
        /// <returns></returns>
        public async Task<List<LutTotalBedroom>> LutTotalBedrooms()
        {
            return await _context.LutTotalBedrooms.OrderBy(o => o.SortOrder).ToListAsync();
        }

        /// <summary>
        /// LutUnitTypes
        /// </summary>
        /// <returns></returns>
        public async Task<List<LutUnitType>> LutUnitTypes()
        {
            return await _context.LutUnitTypes.Where(x => x.IsDeleted == false).OrderBy(o => o.SortOrder).ToListAsync();
        }



        /// <summary>
        /// GetProjectParticipantsByProjectId
        /// </summary>
        /// <returns></returns>
        /// /// <param name="projectId"></param>
        public async Task<List<AssnPropContact>> GetProjectParticipantsByProjectId(int projectId)
        {
            return await _context.AssnPropContacts
                .Where(x => x.ProjectId == projectId
                            && !x.ContactIdentifier.IsDeleted
                            && x.IsDeleted == false
                            && x.ContactIdentifier.Source == "Development Protal")
                .ToListAsync();
        }


        

    }
}
