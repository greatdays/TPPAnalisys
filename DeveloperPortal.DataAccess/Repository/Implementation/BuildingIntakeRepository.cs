using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.ProjectDetail;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperPortal.DataAccess.Repository.Implementation
{
    public class BuildingIntakeRepository : IBuildingIntakeRepository
    {
        private readonly AAHREntities _context;

        public BuildingIntakeRepository(IStoredProcedureExecutor storedProcedureExecutor,
            AAHREntities context)
        {
            _context = context;
        }

        /// <summary>
        /// ServiceRequest
        /// </summary>
        /// <param name="caseId"></param>
        /// <returns></returns>
        public async Task<ServiceRequest?> ServiceRequest(int caseId)
        {
            return await _context.ServiceRequests.FirstOrDefaultAsync(f => f.CaseId == caseId);
        }
        /// <summary>
        /// SaveStructureAsync
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveStructureAsync(Structure structure)
        {
            _context.Structures.Add(structure);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// SaveSiteAddressAsync
        /// </summary>
        /// <param name="siteAddress"></param>
        /// <returns></returns>
        public async Task<int> SaveSiteAddressAsync(SiteAddress siteAddress)
        {
            _context.SiteAddresses.Add(siteAddress);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// SaveChangesAsync
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        /// <summary>
        /// SaveBuildingSummary
        /// </summary>
        /// <param name="buildingModel"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool> SaveBuildingSummary(BuildingParkingInformationModal buildingModel, string userName)
        {
            try
            {
                var propSnapshot = _context.PropSnapshots.FirstOrDefault(p => p.PropSnapshotId == buildingModel.PropSnapshotID && p.IdentifierType == "Building");
                if (propSnapshot != null)
                {
                    propSnapshot.SiteAddressId = buildingModel.BuildingAddressId;
                    var structureAttribute = _context.StructureAttributes.FirstOrDefault(p => p.PropSnapshotId == buildingModel.PropSnapshotID);
                    if (structureAttribute != null)
                    {
                        if (!string.IsNullOrWhiteSpace(buildingModel.BuildingPermitNumber))
                        {
                            structureAttribute.BuildingPermitNumber = Convert.ToInt32(buildingModel.BuildingPermitNumber);
                        }

                        structureAttribute.BuildingDescription = buildingModel.BuildingDescription;
                        structureAttribute.NonResidental = buildingModel.NonResidental;
                        structureAttribute.LutApplicableAccessibilityStandardId = "";
                        if (buildingModel.LutApplicableAccessibilityStandardIdList!=null && buildingModel.LutApplicableAccessibilityStandardIdList.Any())
                        {
                            structureAttribute.LutApplicableAccessibilityStandardId = string.Join(",", buildingModel.LutApplicableAccessibilityStandardIdList);
                        }

                        structureAttribute.MobilityDesignatedUnitNumbers = buildingModel.NumberOfMobilityUnits;
                        structureAttribute.HearingVisionDesignatedUnitNumbers = buildingModel.NumberOfCommunicationUnits;
                        structureAttribute.UnitDesignationTotal = buildingModel.NumberOfAdaptableUnits;
                        structureAttribute.NumberOfFloors = buildingModel.NumberOfFloors;
                        structureAttribute.Elevator = buildingModel.IsElevator;
                        structureAttribute.TotalResidentialParking = buildingModel.NumberOfParkings;
                        structureAttribute.ParkingAvailableAtbuildingLevel = buildingModel.ParkingAvailableAtbuildingLevel;
                        structureAttribute.ModifiedBy = userName;
                        structureAttribute.ModifiedOn = DateTime.Now;
                        _context.StructureAttributes.Update(structureAttribute);
                    }
                    var structure = _context.Structures.FirstOrDefault(p => p.StructureId == buildingModel.BuildingId && p.Source == "Construction");
                    if (structure != null)
                    {
                        structure.StructureNo = buildingModel.StructureNo;
                        structure.TotalUnits = buildingModel.NumberOfUnits;
                        structure.Description = buildingModel.BuildingDescription;
                        structure.ModifiedBy = userName;
                        structure.ModifiedOn = DateTime.Now;
                        _context.Structures.Update(structure);
                    }
                    propSnapshot.ModifiedBy = userName;
                    propSnapshot.ModifiedOn = DateTime.Now;
                    _context.PropSnapshots.Update(propSnapshot);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// SetBuildingModelData
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task SetBuildingModelData(BuildingModel model)
        {
            var lutPreDirCdList = await _context.LutPreDirs.Where(x => x.LutPreDirCd != "").ToListAsync();
            foreach (var item in lutPreDirCdList)
            {
                model.LutPreDirCdListItems.Add(new SelectListItem
                {
                    Value = item.LutPreDirCd
                });
            }
            var lutStreetTypeList = await _context.LutStreetTypes.Where(x => x.IsDeleted == false && x.LutStreetTypeCd != "").ToListAsync();
            foreach (var item in lutStreetTypeList)
            {
                model.LutStreetTypeListItems.Add(new SelectListItem
                {
                    Value = item.LutStreetTypeCd,

                });
            }
            var LutStateCDList = await _context.LutStates.Where(x => x.IsDeleted == false).ToListAsync();
            foreach (var item in LutStateCDList)
            {
                model.LutStateCDListItems.Add(new SelectListItem
                {
                    Text = item.Description,
                    Value = item.LutStateCd
                });
            }
        }



        /// <summary>
        /// PropSnapshots
        /// </summary>
        /// <param name="projectSiteId"></param>
        /// <returns></returns>
        public async Task<PropSnapshot?> PropSnapshots(int projectSiteId)
        {
            return await _context.PropSnapshots.Include(x => x.ProjectSite).FirstOrDefaultAsync(x => x.IdentifierType == "ProjectSite" && x.ProjectSiteId == projectSiteId);
        }

    }
}
