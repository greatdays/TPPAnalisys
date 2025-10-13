using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.ProjectDetail;

namespace DeveloperPortal.DataAccess.Repository.Interface
{
    public interface IProjectDetailRepository
    {

        /// <summary>
        /// StructureAttribute
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <returns></returns>
         Task<StructureAttribute?> StructureAttribute(int propSnapshotId);

        /// <summary>
        /// UpdateStructureAttributesAsync
        /// </summary>
        /// <param name="structureAttribute"></param>
        /// <returns></returns>
        Task<StructureAttribute> UpdateStructureAttributesAsync(StructureAttribute structureAttribute);


        /// <summary>
        /// PolicyComplianceDetail
        /// </summary>
        /// <param name="serviceRequestId"></param>
        /// <returns></returns>
        Task<PolicyComplianceDetail?> PolicyComplianceDetail(long? serviceRequestId);

        /// <summary>
        /// UnitAttribute
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <returns></returns>
        Task<UnitAttribute?> UnitAttribute(long propSnapshotId);

        /// <summary>
        /// AddUnit
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> AddUnit(Unit unit, string userName);

        /// <summary>
        /// Unit
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <returns></returns>
        Task<Unit?> Unit(long propSnapshotId);

        /// <summary>
        /// AddPolicyComplianceDetail
        /// </summary>
        /// <param name="policyComplianceDetail"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> AddPolicyComplianceDetail(PolicyComplianceDetail policyComplianceDetail, string userName);

        /// <summary>
        /// UpdatePolicyComplianceDetail
        /// </summary>
        /// <param name="policyComplianceDetail"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> UpdatePolicyComplianceDetail(PolicyComplianceDetail policyComplianceDetail, string userName);
        /// <summary>
        /// SaveChangesWithAuditAsync
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> SaveChangesWithAuditAsync(string userName);

        /// <summary>
        /// AddPropSnapshots
        /// </summary>
        /// <param name="caseId"></param>
        /// <param name="ps"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<bool> AddPropSnapshots(int caseId, PropSnapshot ps, string userName);
        /// <summary>
        /// DeleteUnit
        /// </summary>
        /// <param name="propSnapshotId"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<bool> DeleteUnit(int propSnapshotId, string username);


        /// <summary>
        /// PropSnapshot By Building Type
        /// </summary>
        /// <param name="structureId"></param>
        /// <returns></returns>
        Task<List<PropSnapshot>> PropSnapshotByBuilding(int structureId);

        /// <summary>
        /// PropSnapshot By Project
        /// </summary>
        /// <param name="projectSiteId"></param>

        /// <returns></returns>
        Task<PropSnapshot> PropSnapshotByProject(int projectSiteId);

        /// <summary>
        /// LutTotalBedrooms
        /// </summary>
        /// <returns></returns>
        Task<List<LutTotalBedroom>> LutTotalBedrooms();


        /// <summary>
        /// LutUnitTypes
        /// </summary>
        /// <returns></returns>
        Task<List<LutUnitType>> LutUnitTypes();

        Task<ProjectSite> GetProjectSiteDetails(int projectId);
    }
}
