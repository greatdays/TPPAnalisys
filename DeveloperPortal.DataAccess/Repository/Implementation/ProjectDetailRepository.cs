using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.ProjectDetail;
using Microsoft.EntityFrameworkCore;

namespace DeveloperPortal.DataAccess.Repository.Implementation
{
    public class ProjectDetailRepository : IProjectDetailRepository
    {
        
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        private readonly AAHREntities _context;
       

        public ProjectDetailRepository(IStoredProcedureExecutor storedProcedureExecutor,
            AAHREntities context)
        {
           
            _storedProcedureExecutor = storedProcedureExecutor;
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
        
        public bool UpdateUnitDetails(UnitDataModel unitModel, string userName)
        {
            var unitAtt = _context.UnitAttributes.FirstOrDefault(u => u.PropSnapshotId == unitModel.PropSnapshotID);
            if (unitAtt != null)
            {
                var prop = _context.PropSnapshots.FirstOrDefault(p => p.PropSnapshotId == unitModel.PropSnapshotID);
                var unit = _context.Units.FirstOrDefault(u => u.UnitId == prop.UnitId);
                if (unit != null)
                {
                    unit.UnitNum = unitModel.UnitNum;
                }
                unitAtt.IsCsa = unitModel.IsCSA;
                unitAtt.IsVca = unitModel.IsVCA;
                unitAtt.LutTotalBedroomId = unitModel.LutTotalBedroomID;
                unitAtt.LutUnitTypeId = unitModel.LutUnitTypeID;
                unitAtt.FloorPlanType = unitModel.FloorPlanType;
                unitAtt.AccessibleFeatureType = unitModel.AdditionalAccecibility;
                unitAtt.IsManagersUnit = unitModel.ManagersUnit.HasValue ? unitModel.ManagersUnit.HasValue : false;
                _context.SaveChanges(userName);
                PolicyComplianceDetail pcd = _context.PolicyComplianceDetails.Where(p => p.ServiceRequestId == unitModel.ServiceRequestId).FirstOrDefault();
                if (pcd == null && unitModel.IsCompliant)
                {
                    PolicyComplianceDetail newpcd = new PolicyComplianceDetail();
                    newpcd.ServiceRequestId = unitModel.ServiceRequestId;
                    newpcd.CaseId = Convert.ToInt32(unitModel.CaseId);
                    newpcd.IsCompliant = unitModel.IsCompliant;
                    newpcd.CreatedBy = userName;
                    newpcd.CreatedOn = System.DateTime.Now;
                    newpcd.ModifiedBy = userName;
                    newpcd.ModifiedOn = System.DateTime.Now;
                    _context.PolicyComplianceDetails.Add(newpcd);
                    _context.SaveChanges(userName);
                }
                else if (pcd != null && pcd.IsCompliant != unitModel.IsCompliant)
                {
                    pcd.IsCompliant = unitModel.IsCompliant;
                    pcd.ModifiedBy = userName;
                    pcd.ModifiedOn = System.DateTime.Now;
                    _context.Entry(pcd).State = EntityState.Modified;
                    _context.SaveChanges(userName);
                }
            }
            return true;
        }
    }
}
