using System.Data;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.ProjectDetail;
using HCIDLA.ServiceClient.DMS;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DeveloperPortal.Application.ProjectDetail.Implementation
{
    public class FloorPlanTypeService : IFloorPlanTypeService
    {
        private IFloorPlanTypeRepository _floorPlanTypeRepository;
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        private IConfiguration _config;
        private IProjectDetailRepository _TypeRepository;
        public FloorPlanTypeService(IConfiguration configuration, IStoredProcedureExecutor storedProcedureExecutor,
           IFloorPlanTypeRepository floorPlanTypeRepository, IProjectDetailRepository projectDetailRepository)
        {
            _config = configuration;
            _storedProcedureExecutor = storedProcedureExecutor;
            _floorPlanTypeRepository = floorPlanTypeRepository;
            _TypeRepository = projectDetailRepository;
        }
        public async Task<FloorPlanTypeModel> GetFloorPlanTypes(int siteId, int projectId)
        {
            var floorPlanTypeModel = new FloorPlanTypeModel();
            floorPlanTypeModel.LutTotalBedrooms = await GetLutTotalBedrooms();
            floorPlanTypeModel.LutTotalBathrooms = await GetLutTotalBathrooms();
            floorPlanTypeModel.LutBathroomType = await GetLutBathroomType();
            floorPlanTypeModel.LutTotalBathroomTypeOption = await GetLutBathroomTypeOption();
            floorPlanTypeModel.ProjectID = projectId;
            floorPlanTypeModel.ProjectSiteID = siteId;
            return floorPlanTypeModel;
        }
        public bool EditFloorPlanType(FloorPlanTypeModel floorPlanTypeModel)
        {
            var floorPlan = _floorPlanTypeRepository.GetFloorPlanTypeByID(floorPlanTypeModel.FloorPlanTypeID);
            if (floorPlan != null)
            {
                floorPlan.Name = floorPlanTypeModel.Name;
                floorPlan.LutTotalBathroomId = floorPlanTypeModel.LutTotalBathroomID;
                floorPlan.LutTotalBedroomId = floorPlanTypeModel.LutTotalBedroomID;
                floorPlan.ProjectSiteId = floorPlanTypeModel.ProjectSiteID;
                floorPlan.StructureId = floorPlanTypeModel.StructureID;
                floorPlan.SquareFeet = floorPlanTypeModel.SquareFeet;
                floorPlan.ModifiedBy = floorPlanTypeModel.UserName;
                var result = _floorPlanTypeRepository.UpdateFloorPlanType(floorPlanTypeModel);
                var floorPlanBathroomTypes = _floorPlanTypeRepository.GetFloorPlanBathroomTypeByFloorPlanID(floorPlanTypeModel.FloorPlanTypeID);
                int bathroomTypeFullId = _floorPlanTypeRepository.GetLutBathroomTypeEdit()
                             .Where(c => c.Description.Equals("Full"))
                             .Select(c => c.LutBathroomTypeId).FirstOrDefault();

                foreach (var item in floorPlanBathroomTypes)
                {
                    _floorPlanTypeRepository.RemoveFloorPlanBathroomType(item);
                }
                foreach (var bathroomType in floorPlanTypeModel.FloorPlanBathroomType)
                {
                    if (bathroomType.LutBathroomTypeID != bathroomTypeFullId)
                        bathroomType.LutBathroomTypeOptionID = 0;
                    _floorPlanTypeRepository.AddFloorPlanBathroomTypeAsync(new FloorPlanBathroomType
                    {
                        LutBathroomTypeId = bathroomType.LutBathroomTypeID,
                        LutBathroomTypeOptionId = bathroomType.LutBathroomTypeOptionID,
                        FloorPlanTypeId = floorPlan.FloorPlanTypeId,
                    });
                }
                var unitAttributes = _floorPlanTypeRepository.GetUnitAttributesbyFloorPlanID(floorPlan.FloorPlanTypeId);
                if (unitAttributes.Count > 0)
                {
                    foreach (var units in unitAttributes)
                    {
                        units.LutTotalBathroomId = floorPlanTypeModel.LutTotalBathroomID;
                        units.LutTotalBedroomId = floorPlanTypeModel.LutTotalBedroomID; ;
                        units.SquareFeet = floorPlanTypeModel.SquareFeet;
                        units.FloorPlanType = floorPlanTypeModel.Name;
                        units.FirstName = floorPlanTypeModel.UserName;
                        var resultEdit = _floorPlanTypeRepository.UpdateUnitAttribute(units);
                        var unitBathroomType = _floorPlanTypeRepository.GetUnitBathroomTypebyUnitAttributeID(units.UnitAttributeId);
                        foreach (var item in unitBathroomType)
                        {
                            _floorPlanTypeRepository.RemoveUnitPlanBathroomType(item);
                        }
                        foreach (var bathroomType in floorPlanTypeModel.FloorPlanBathroomType)
                        {
                            _floorPlanTypeRepository.AddUnitPlanBathroomTypeAsync(new UnitBathroomType
                            {
                                LutBathroomTypeId = bathroomType.LutBathroomTypeID,
                                UnitAttributeId = units.UnitAttributeId,
                            });
                        }
                    }
                }
            }
            return true;
        }
        public async Task<List<LutTotalBedrooms>> GetLutTotalBedrooms()
        {
            var lutTotalBedRooms = await _floorPlanTypeRepository.GetLutTotalBedrooms();
            var LutTotalBedRooms = lutTotalBedRooms.Select(a => new LutTotalBedrooms
            {
                Value = a.LutTotalBedroomsId.ToString(),
                Text = a.Description
            }).ToList();

            foreach (var item in LutTotalBedRooms)
            {
                switch (item.Text)
                {
                    case "1":
                        item.Text = "1 Bedroom";
                        break;
                    case "2":
                        item.Text = "2 Bedroom";
                        break;
                    case "3":
                        item.Text = "3 Bedroom";
                        break;
                    case "4":
                        item.Text = "4 Bedroom";
                        break;
                    case "5+":
                        item.Text = "5 Bedroom";
                        break;
                    default:
                        break;
                }
            }

            return LutTotalBedRooms;
        }
        public async Task<List<LutTotalBathrooms>> GetLutTotalBathrooms()
        {
            var lutTotalBathRooms = await _floorPlanTypeRepository.GetLutTotalBathrooms();
            var LutTotalBathRooms = lutTotalBathRooms.Select(a => new LutTotalBathrooms
            {
                Value = a.LutTotalBathroomsId.ToString(),
                Text = a.Description
            }).ToList();
            return LutTotalBathRooms;
        }
        public List<FloorPlanInformation> GetFloorPlanInformationCompliance(int CaseID)
        {
            var lutFloorPlanTypes = _floorPlanTypeRepository.GetFloorPlanInformationCompliance(CaseID);
            if (lutFloorPlanTypes == null || !lutFloorPlanTypes.Any())
            {
                return new List<FloorPlanInformation>();
            }
            var LutFloorPlanTypes = lutFloorPlanTypes.Select(a => new FloorPlanInformation
            {
                FloorPlanTypeID = a.FloorPlanTypeID,
                Name = a.Name
            }).ToList();
            return LutFloorPlanTypes;
        }
        public async Task<List<LutBathroomTypes>> GetLutBathroomType()
        {
            var lutBathroomTypes = await _floorPlanTypeRepository.GetLutBathroomType();
            var LutBathroomTypes = lutBathroomTypes.Select(a => new LutBathroomTypes
            {
                Value = a.LutBathroomTypeId.ToString(),
                Text = a.Description
            }).ToList();
            return LutBathroomTypes;
        }
        public async Task<List<LutTotalBathroomTypeOption>> GetLutBathroomTypeOption()
        {
            var lutBathroomTypeOption = await _floorPlanTypeRepository.GetLutBathroomTypeOption();
            var LutBathroomTypeOption = lutBathroomTypeOption.Select(a => new LutTotalBathroomTypeOption
            {
                Value = a.LutBathroomTypeOptionId.ToString(),
                Text = a.Description
            }).ToList();
            return LutBathroomTypeOption;
        }
        public bool DeleteFloorPlantype(int floorPlanTypeId, string userName)
        {
            var floorPlanType = _floorPlanTypeRepository.GetFloorPlanTypeByID(floorPlanTypeId);
            floorPlanType.IsDeleted = true;
            floorPlanType.ModifiedBy = userName;
            var result = _floorPlanTypeRepository.DeleteFloorPlanType(floorPlanType);
            var Units = _floorPlanTypeRepository.GetUnitAttributesbyFloorPlanID(floorPlanTypeId);
            if (Units.Any())
            {
                foreach (var unit in Units)
                {
                    unit.FloorPlanTypeId = 0;
                    _floorPlanTypeRepository.UpdateUnitAttribute(unit);
                }
            }
            return true;
        }
        public bool DeleteFloorPlanFile(int docId)
        {
            bool data = _floorPlanTypeRepository.DeleteFloorPlanFile(docId);
            if (data)
            {
                return true;
            }
            return false;
        }

        public async Task<int> AddFloorPlanTypeComplianceMatrix(FloorPlanTypeModel floorPanTypeModel)
        {
            var floorPlans = new FloorPlanType
            {
                Name = floorPanTypeModel.Name,
                LutTotalBathroomId = floorPanTypeModel.LutTotalBathroomID,
                LutTotalBedroomId = floorPanTypeModel.LutTotalBedroomID,
                ProjectSiteId = (floorPanTypeModel.ProjectSiteID == 0 ? null : floorPanTypeModel.ProjectSiteID),
                ProjectId = floorPanTypeModel.ProjectID,
                StructureId = (floorPanTypeModel.StructureID == 0 ? null : floorPanTypeModel.StructureID),
                SquareFeet = floorPanTypeModel.SquareFeet,
                PropsnapShotId = _floorPlanTypeRepository.GetPropSnapShots(floorPanTypeModel.ProjectID),
                IsDeleted = false,
                CreatedBy = floorPanTypeModel.UserName
            };
            var FloorPlanTypeID = _floorPlanTypeRepository.SaveFloorPlanType(floorPlans);
            if (floorPanTypeModel.FloorPlanBathroomType.Count != 0)
            {
                foreach (var bathroomType in floorPanTypeModel.FloorPlanBathroomType)
                {
                    _floorPlanTypeRepository.AddFloorPlanBathroomTypeAsync(new FloorPlanBathroomType
                    {
                        LutBathroomTypeId = Convert.ToInt16(bathroomType.LutBathroomTypeID),
                        LutBathroomTypeOptionId = Convert.ToInt16(bathroomType.LutBathroomTypeOptionID),
                        FloorPlanTypeId = FloorPlanTypeID,
                        CreatedBy = floorPanTypeModel.UserName
                    });
                }
            }
            return FloorPlanTypeID;
        }
        public List<FloorPlanTypeModel> GetFloorPlanInformation(int ProjectID)
        {
            var floorPlanTypeModel = _floorPlanTypeRepository.GetFloorPlanInformation(ProjectID); // Assume this is populated

            foreach (var fpType in floorPlanTypeModel)
            {
                var floorPlanBathroomType = _floorPlanTypeRepository
                    .GetFloorPlanBathroomTypeByFloorPlanID(fpType.FloorPlanTypeID);

                foreach (var fpBathroomType in floorPlanBathroomType)
                {                   
                    var bathroomTypeDescription = _floorPlanTypeRepository.GetLutBathroomTypeEdit()
                        .Where(p => p.LutBathroomTypeId == fpBathroomType.LutBathroomTypeId)
                        .Select(c => c.Description)
                        .FirstOrDefault();

                    // Append to BathroomTypes
                    fpType.GroupBathroomTypes += bathroomTypeDescription + ",";

                    // Get Description for Bathroom Option
                    var bathroomOptionDescription = _floorPlanTypeRepository.GetLutBathroomTypeOptionEdit()
                        .Where(p => p.LutBathroomTypeOptionId == fpBathroomType.LutBathroomTypeOptionId)
                        .Select(c => c.Description)
                        .FirstOrDefault();
                    if (bathroomOptionDescription != null)
                        // Append to BathroomOption
                        fpType.GroupBathroomOption += bathroomOptionDescription + ",";
                }
                if (!string.IsNullOrEmpty(fpType.GroupBathroomTypes))
                {
                    fpType.GroupBathroomTypes = fpType.GroupBathroomTypes.Remove(fpType.GroupBathroomTypes.Length - 1);
                }
                if (!string.IsNullOrEmpty(fpType.GroupBathroomOption))
                {
                    fpType.GroupBathroomOption = fpType.GroupBathroomOption.Remove(fpType.GroupBathroomOption.Length - 1);
                    fpType.GroupBathroomOption = fpType.GroupBathroomOption?.TrimStart(',') ?? string.Empty;
                }
                if (string.IsNullOrEmpty(fpType.GroupBathroomTypes) || fpType.GroupBathroomTypes == "null")
                {
                    fpType.GroupBathroomTypes = "";
                }
                if (string.IsNullOrEmpty(fpType.GroupBathroomOption) || fpType.GroupBathroomOption == "null")
                {
                    fpType.GroupBathroomOption = "";
                }
            }


            return floorPlanTypeModel;
        }

        public async Task<FloorPlanTypeModel> FetchFloorPlanById(int floorplanId)
        {
            var floorPlan = _floorPlanTypeRepository.GetFloorPlanTypeByID(floorplanId);
            var floorPlanFiles = _floorPlanTypeRepository.GetFloorPlanFilesByID(Convert.ToString(floorplanId));

            var floorPlanType = new FloorPlanTypeModel()
            {
                Name = floorPlan.Name,
                LutTotalBathroomID = floorPlan.LutTotalBathroomId,
                LutTotalBedroomID = floorPlan.LutTotalBedroomId,
                SquareFeet = floorPlan.SquareFeet,
                ProjectID = floorPlan.ProjectId,
                ProjectSiteID = floorPlan.ProjectSiteId ?? 0,
                PropsnapShotID = floorPlan.PropsnapShotId,
                StructureID = floorPlan.StructureId ?? 0,
                FloorPlanTypeID = floorPlan.FloorPlanTypeId,
                File = floorPlanFiles.Select(x => new FloorPlanFileModel
                {
                    DocID=x.DocumentId,
                    Name = x.Name,
                    FileSize = x.FileSize,
                    URl=x.Link
                }).ToList()

            };
            
            
            floorPlanType.FloorPlanBathroomType = new List<FloorPlanBathroomTypeModel>();
            var bTypes = _floorPlanTypeRepository.GetFloorPlanBathroomTypeByFloorPlanID(floorplanId);
            foreach (var bType in bTypes)
            {
                floorPlanType.FloorPlanBathroomType.Add(new FloorPlanBathroomTypeModel
                {
                    LutBathroomTypeID = bType.LutBathroomTypeId,
                    LutBathroomTypeOptionID = bType.LutBathroomTypeOptionId,
                });
            }
            floorPlanType.LutTotalBedrooms = (await GetLutTotalBedrooms())
                                .Select(ut => new LutTotalBedrooms
                                {
                                    Value = ut.Value.ToString(),
                                    Text = ut.Text
                                })
                                .ToList();
            floorPlanType.LutTotalBathrooms = (await _floorPlanTypeRepository.GetLutTotalBathrooms()).Select(ut => new LutTotalBathrooms
            {
                Value = ut.LutTotalBathroomsId.ToString(),
                Text = ut.Description
            }).ToList();
            floorPlanType.LutFloorBathrommOptions = _floorPlanTypeRepository.GetLutBathroomTypeOptionbyFLoorPlanTypeID().Select(ut => new SelectListItem
            {
                Value = ut.LutBathroomTypeOptionId.ToString(),
                Text = ut.Description
            }).ToList();
            floorPlanType.LutBathroomType = (await _floorPlanTypeRepository.GetLutBathroomType()).Select(ut => new LutBathroomTypes
            {
                Value = ut.LutBathroomTypeId.ToString(),
                Text = ut.Description
            }).ToList();
            return floorPlanType;
        }
        public int? getLuDocumentCategoryId(string category, string subCategory)
        {
            return _floorPlanTypeRepository.getLuDocumentCategoryId(category, subCategory);
        }
        public void SaveFloorPlanFile(FloorPlanTypeModel floorPlan,List<UploadResponse> uploadResponses
            ,int LuDocumentCategoryId,string FloorPlanTypeID, string userName
            ) {
            List<Document> documents = new List<Document>();

            for (int i = 0; i < uploadResponses.Count; i++)
            {
                var response = uploadResponses[i];
                var file = floorPlan.Files[i];

                if (response != null && string.IsNullOrEmpty(response.ErrorMessages?.FirstOrDefault()))
                {
                    documents.Add(new Document
                    {

                        Link = response.UniqueId.ToString(),
                        FileSize = file.Length.ToString(),
                        Name = file.FileName,
                        Comment = "",
                        Attributes = "",
                        DocumentCategoryId = Convert.ToInt32(LuDocumentCategoryId),
                        CreatedOn = DateTime.Now,
                        CreatedBy = userName,
                        ModifiedBy = userName,
                        ModifiedOn = DateTime.Now,
                        IsDeleted = false,
                        AssnDocuments =
                                {
                                    new AssnDocument
                                    {
                                        ReferenceId = FloorPlanTypeID.ToString(),
                                        ReferenceType = "FloorPlan",
                                        CreatedBy =  userName,
                                        CreatedOn =  DateTime.Now,
                                        ModifiedBy =  userName,
                                        ModifiedOn =  DateTime.Now
                                    }
                                }


                    });
                }
                else
                {
                    Console.WriteLine($"Failed to upload {file.FileName}: {string.Join(", ", response?.ErrorMessages ?? new string[] { "Unknown error" })}");
                }
            }

            _floorPlanTypeRepository.SaveFloorPlanFile(documents, floorPlan);
            
        }
    }
}
