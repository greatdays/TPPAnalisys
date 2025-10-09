using DeveloperPortal.Application.Common;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.ProjectDetail;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;


namespace DeveloperPortal.Application.ProjectDetail.Implementation
{

    public class BuildingIntakeService : IBuildingIntakeService
    {
        #region Constructor

        private readonly IBuildingIntakeRepository _buildingIntakeRepository;
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;

        public BuildingIntakeService(IBuildingIntakeRepository buildingIntakeRepository, IStoredProcedureExecutor storedProcedureExecutor)
        {
            _buildingIntakeRepository = buildingIntakeRepository;
            _storedProcedureExecutor = storedProcedureExecutor;
        }

        #endregion

        /// <summary>
        /// SaveAddBuilding
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> SaveAddBuilding(BuildingModel model)
        {
            try
            {
                bool isSaved = false;
                var serviceRequest = await _buildingIntakeRepository.ServiceRequest(model.CaseId);
                if (null != serviceRequest)
                {
                    // building or structure.
                    Structure structure = new Structure
                    {
                        StructureNo = model.BuildingName,
                        Apnid = model.APNId,
                        LutStructureTypeId = 1,
                        TotalUnits = model.NumberofUnits,
                        Source = "Construction",
                        Attributes = "{\"Status\":\"V\"}",
                        Status = "X",
                        Description = model.BuildingDescription,
                        //structure.BuildingFileNumber = generatedFileNumber;
                        CreatedBy = model.Username,
                        CreatedOn = DateTime.Now,
                        ModifiedBy = model.Username,
                        ModifiedOn = DateTime.Now
                    };
                    await _buildingIntakeRepository.SaveStructureAsync(structure);

                    // site address
                    int? siteAddressId = siteAddressId = model.BuildingAddressID;
                    if (model.IsAddAddress)
                    {
                        SiteAddress siteAddress = new SiteAddress
                        {
                            HouseNum = model.HouseNum.ToString(),
                            HouseFracNum = model.HouseFracNum,
                            PreDirCd = model.LutPreDirCd,
                            StreetName = model.StreetName,
                            StreetTypeCd = model.LutStreetTypeCD,
                            City = model.City,
                            State = model.LutStateCD,
                            Zip = model.Zip,
                            Source = "Construction",
                            Status = "X",
                            IsDeleted = false,
                            CreatedBy = model.Username,
                            CreatedOn = DateTime.Now,
                            ModifiedBy = model.Username,
                            ModifiedOn = DateTime.Now
                        };
                        await _buildingIntakeRepository.SaveSiteAddressAsync(siteAddress);
                        siteAddressId = siteAddress.SiteAddressId;
                    }

                    // structure attribute.
                    StructureAttribute structureAttribute = new StructureAttribute();
                    structureAttribute.NonResidental = model.IsNonResidential;
                    structureAttribute.BuildingDescription = model.BuildingDescription;
                    structureAttribute.CreatedBy = model.Username;
                    structureAttribute.CreatedOn = DateTime.Now;
                    structureAttribute.ModifiedBy = model.Username;
                    structureAttribute.ModifiedOn = DateTime.Now;
                    structureAttribute.StructureId = structure.StructureId;

                    // property snap shot
                    PropSnapshot propSnapshot = new PropSnapshot();
                    propSnapshot.IdentifierType = "Building";
                    propSnapshot.ProjectSiteId = model.ProjectSiteId;
                    propSnapshot.ProjectId = model.ProjectId;
                    propSnapshot.SiteAddressId = siteAddressId;
                    propSnapshot.StructureId = structure.StructureId;
                    propSnapshot.Status = "X";
                    propSnapshot.Apnid = model.APNId;
                    propSnapshot.CreatedBy = model.Username;
                    propSnapshot.CreatedOn = DateTime.Now;
                    propSnapshot.ModifiedBy = model.Username;
                    propSnapshot.ModifiedOn = DateTime.Now;
                    propSnapshot.StructureAttributes.Add(structureAttribute);
                    serviceRequest.PropSnapshots.Add(propSnapshot);
                    await _buildingIntakeRepository.SaveChangesAsync();
                    isSaved = true;
                }

                return isSaved; // returns
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Save Building Summary
        /// </summary>
        /// <param name="buildingModel"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool> SaveBuildingSummary(BuildingParkingInformationModal buildingModel, string userName)
        {
            try
            {
                return await _buildingIntakeRepository.SaveBuildingSummary(buildingModel, userName);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// GetAddBuildingDetails
        /// </summary>
        /// <param name="projectSiteId"></param>
        /// <returns></returns>
        public async Task<BuildingModel> GetAddBuildingDetails(int projectSiteId)
        {
            BuildingModel model = new BuildingModel();
            SelectListItem address = new SelectListItem();
            model.BuildingAddressList = new List<SelectListItem>();
            var propSSProjectSite = await _buildingIntakeRepository.PropSnapshots(projectSiteId);
            if (propSSProjectSite != null)
            {
                model.BuildingAddressList = await GetBuildingAddressDetails(new List<int>() { projectSiteId });
                model.siteAddressId = (int)propSSProjectSite.SiteAddressId;
                model.ProjectSiteId = propSSProjectSite.ProjectSiteId;
                model.ProjectId = (int)propSSProjectSite.ProjectId;
                model.APNId = (int)propSSProjectSite.Apnid;
            }

            await _buildingIntakeRepository.SetBuildingModelData(model);
            return model;
        }

        /// <summary>
        /// GetBuildingAddressDetails
        /// </summary>
        /// <param name="projectSiteIds"></param>
        /// <returns></returns>
        public async Task<List<SelectListItem>> GetBuildingAddressDetails(List<int> projectSiteIds)
        {
            var parameters = new List<SqlParameter>()
                {
                    new SqlParameter() { ParameterName = "@ProjecIds", Value = string.Join(",", projectSiteIds) },
                };

            using (var siteAddress = _storedProcedureExecutor.ExecuteStoreProcedure(StoredProcedureNames.SP_uspGetSiteAddressByProject, parameters))
            {
                List<SelectListItem> lstAddress = new List<SelectListItem>();
                if (siteAddress != null && siteAddress.Rows.Count > 0)
                {
                    for (int i = 0; i < siteAddress.Rows.Count; i++)
                    {
                        lstAddress.Add(new SelectListItem
                        {
                            Text = Convert.ToString(siteAddress.Rows[i]["FullAddress"]),
                            Value = Convert.ToString(siteAddress.Rows[i]["SiteAddressID"])
                        });

                    }
                }
                return lstAddress.Distinct().ToList();
            }

        }

        /// <summary>
        /// GetBuildingDetailForEdit
        /// </summary>
        /// <param name="projectSiteId"></param>
        /// <returns></returns>
        public async Task<BuildingModel> GetBuildingDetailForEdit(int projectSiteId)
        {
            BuildingModel buildingModel = new BuildingModel();
            SelectListItem address = new SelectListItem();
            List<SelectListItem> lstAddress = new List<SelectListItem>();
            var propSSProjectSite = await _buildingIntakeRepository.PropSnapshots(projectSiteId);
            if (propSSProjectSite != null)
            {
                lstAddress = await GetBuildingAddressDetails(new List<int>() { projectSiteId });
                buildingModel.siteAddressId = (int)propSSProjectSite.SiteAddressId;
                buildingModel.ProjectSiteId = propSSProjectSite.ProjectSiteId;
                buildingModel.ProjectId = (int)propSSProjectSite.ProjectId;
                buildingModel.APNId = (int)propSSProjectSite.Apnid;
            }
            buildingModel.BuildingAddressList = lstAddress;
            //model.LutTypeofProject= _dbAAHPContext.LUTPRO.FirstOrDefault(x => x.IdentifierType == "ProjectSite" && x.ProjectSiteID == projectsiteId)

            buildingModel.BuildingDescriptionList = BuildingDescriptionList();
            buildingModel.LutApplicableAccessibilityStandardList = GetApplicableAccessibilityStandard();


            return buildingModel;
        }


        /// <summary>
        /// Save Building parking Attributes
        /// </summary>
        /// <param name="buildingModel"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public async Task<bool> SaveBuildingParkingAttributes(BuildingParkingInformationModal buildingModel, string userName)
        {
            try
            {
                StructureAttribute? structureAttribute = await _buildingIntakeRepository.StructureAttribute(buildingModel.PropSnapshotID);
                if (structureAttribute == null)
                {
                    structureAttribute = new StructureAttribute();
                    structureAttribute.PropSnapshotId = buildingModel.PropSnapshotID;
                    structureAttribute.CreatedOn = DateTime.Now;
                    structureAttribute.CreatedBy = userName;
                }
                structureAttribute.ParkingAvailableAtbuildingLevel = buildingModel.ParkingAvailableAtbuildingLevel;
                structureAttribute.ResindentialSpaces = buildingModel.ResindentialSpaces;
                structureAttribute.AccessibleSpaces = buildingModel.AccessibleSpaces;
                structureAttribute.VanAccessibleSpaces = buildingModel.VanAccessibleSpaces;
                structureAttribute.StandardCommercialSpaces = buildingModel.StandardCommercialSpaces;
                structureAttribute.CommercialAccessibleSpaces = buildingModel.CommercialAccessibleSpaces;
                structureAttribute.CommercialVanAccessibleSpaces = buildingModel.CommercialVanAccessibleSpaces;
                structureAttribute.ElectricVehicleChargingStations = buildingModel.ElectricVehicleChargingStations;
                structureAttribute.TotalResidentialParking = buildingModel.TotalResidentialParking;
                structureAttribute.TotalCommercialParking = buildingModel.TotalCommercialParking;
                structureAttribute.CommercialVehicleChargingStations = buildingModel.CommercialVehicleChargingStations;
                structureAttribute.StandardAccessibleChargingStations = buildingModel.StandardAccessibleChargingStations;
                structureAttribute.VanAccessibleChargingStations = buildingModel.VanAccessibleChargingStations;
                structureAttribute.AmbulatoryChargingStations = buildingModel.AmbulatoryChargingStations;
                structureAttribute.StandardVisitorSpaces = buildingModel.StandardVisitorSpaces;
                structureAttribute.VisitorAccessibleSpaces = buildingModel.VisitorAccessibleSpaces;
                structureAttribute.TotalVisitorParking = buildingModel.TotalVisitorParking;
                structureAttribute.VisitorVanAccessibleSpaces = buildingModel.VisitorVanAccessibleSpaces;
                structureAttribute.CommercialElectricVanAccessibleChargingStation = buildingModel.CommercialElectricVanAccessibleChargingStation;
                structureAttribute.CommercialElectricAmbulatoryChargingStation = buildingModel.CommercialElectricAmbulatoryChargingStation;
                structureAttribute.TotalNumberofCommercialElectricVehicleChargingStations = buildingModel.TotalNumberofCommercialElectricVehicleChargingStations;
                structureAttribute.CommercialElectricStandardAccessibleChargingStation = buildingModel.CommercialElectricStandardAccessibleChargingStation;
                structureAttribute.ModifiedOn = DateTime.Now;
                structureAttribute.ModifiedBy = userName;
                await _buildingIntakeRepository.UpdateStructureAttributesAsync(structureAttribute);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region Private

        /// <summary>
        /// BuildingDescriptionList
        /// </summary>
        /// <returns></returns>
        private static List<SelectListItem> BuildingDescriptionList() => [
                new SelectListItem{Text = "Select"},
                new SelectListItem{Text = "Parking structure"},
                new SelectListItem{Text = "Common area"},
                new SelectListItem{Text = "Community room"},
                new SelectListItem{Text = "Gym"},
                new SelectListItem{Text = "Exterior area"},
                new SelectListItem{Text = "Conference Room"},
                new SelectListItem{Text = "Pools"},
                new SelectListItem{Text = "Rec area"},
                new SelectListItem{Text = "Common Parking"},
                new SelectListItem{Text = "Dog walk area"},
                new SelectListItem{Text = "Medical building/area"},
                new SelectListItem{Text = "Daycare"}
            ];

        /// <summary>
        /// GetApplicableAccessibilityStandard
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> GetApplicableAccessibilityStandard() => new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Section 504" },
                new SelectListItem { Value = "2", Text = "2010 ADA w/ 11 HUD Exceptions" },
                new SelectListItem { Value = "3", Text = "2010 ADA" },
                new SelectListItem { Value = "4", Text = "Fair Housing Act" },
                new SelectListItem { Value = "5", Text = "CBC 2013 Chapter 11A" },
                new SelectListItem { Value = "6", Text = "CBC 2013 Chapter 11B" },
                new SelectListItem { Value = "7", Text = "CBC 2016 Chapter 11A" },
                new SelectListItem { Value = "8", Text = "CBC 2016 Chapter 11B" },
                new SelectListItem { Value = "9", Text = "CBC 2019 Chapter 11A" },
                new SelectListItem { Value = "10", Text = "CBC 2019 Chapter 11B" },
                new SelectListItem { Value = "11", Text = "Community Development Department of County of Los Angeles Universal Design Principles" },
                new SelectListItem { Value = "12", Text = "California Tax Credit Allocation Committee Regulations 50% Mobility Units" },
                new SelectListItem { Value = "13", Text = "UFAS" },
                new SelectListItem { Value = "14", Text = "Enhanced Accessiblity Program (EAP)" },
                new SelectListItem { Value = "15", Text = "2019 CBC w/ intervening cycle effective July 1st, 2021" },
                new SelectListItem { Value = "16", Text = "LACDA NOFA" },
                new SelectListItem { Value = "17", Text = "TCAC Universal Design" },
                new SelectListItem { Value = "18", Text = "CBC 2022 Chapter 11A" },
                new SelectListItem { Value = "19", Text = "CBC 2022 Chapter 11B" }
            };

        #endregion
    }
}
