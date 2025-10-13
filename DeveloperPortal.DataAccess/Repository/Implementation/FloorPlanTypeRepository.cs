using System.Data;
//using System.Data.Entity;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.FundingSource;
using DeveloperPortal.Domain.ProjectDetail;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Index.HPRtree;
using static DeveloperPortal.DataAccess.Entity.Models.Generated.Case;

namespace DeveloperPortal.DataAccess.Repository.Implementation
{
    public class FloorPlanTypeRepository : IFloorPlanTypeRepository
    {
        private readonly AAHREntities _context;
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;

        public FloorPlanTypeRepository(AAHREntities contextFactory, IStoredProcedureExecutor storedProcedureExecutor)
        {
            _context = contextFactory;
            _storedProcedureExecutor = storedProcedureExecutor;
        }

        public async Task<List<LutTotalBedroom>> GetLutTotalBedrooms()
        {
            return await _context.LutTotalBedrooms.OrderBy(o => o.SortOrder).ToListAsync();
        }
        public async Task<List<LutTotalBathroom>> GetLutTotalBathrooms()
        {
            return await _context.LutTotalBathrooms.ToListAsync();
        }
        public async Task<List<LutBathroomType>> GetLutBathroomType()
        {
            return await _context.LutBathroomTypes.ToListAsync();
        }
        public async Task<List<LutBathroomTypeOption>> GetLutBathroomTypeOption()
        {
            return await _context.LutBathroomTypeOptions.ToListAsync();
        }
        public int GetPropSnapShots(int ProjectID)
        {
            try
            {
                return _context.PropSnapshots.Where(p => p.ProjectId == ProjectID).Select(p => p.PropSnapshotId).FirstOrDefault();
            }
            catch (Exception Ex)
            {
                var i = Ex.Message;
                return 1;
            }
        }
        public int SaveFloorPlanType(FloorPlanType floorPlans)
        {
            try
            {

                _context.FloorPlanTypes.Add(floorPlans);
                _context.SaveChanges();
                return floorPlans.FloorPlanTypeId;
            }
            catch (Exception Ex)
            {
                var i = Ex.Message;
                return 1;
            }
        }
        public int AddFloorPlanBathroomTypeAsync(FloorPlanBathroomType bathroomType)
        {
            _context.FloorPlanBathroomTypes.Add(bathroomType);
            return _context.SaveChanges();

        }
        public List<FloorPlanTypeModel> GetFloorPlanInformation(int ProjectID)
        {
            var floorPlanType = new List<FloorPlanTypeModel>();
            var sqlParameters = new List<SqlParameter>
                    {
                        new SqlParameter() { ParameterName = "@projectID", Value = ProjectID },
                    };

            using (var floorPlanTypeDetailDt = _storedProcedureExecutor.ExecuteStoreProcedure("[AAHPCC].[uspGetFloorPlansByProjectID]", sqlParameters))
            {
                if (floorPlanTypeDetailDt != null && floorPlanTypeDetailDt.Rows.Count > 0)
                {
                    foreach (DataRow row in floorPlanTypeDetailDt.Rows)
                    {
                        var plan = new FloorPlanTypeModel
                        {
                            FloorPlanTypeID = row["FloorPlanTypeID"] != DBNull.Value ? Convert.ToInt32(row["FloorPlanTypeID"]) : 0,
                            Name = row["Name"]?.ToString(),
                            SquareFeet = row["SquareFeet"] != DBNull.Value ? Convert.ToInt32(row["SquareFeet"]) : 0,
                            BathroomTypes = row["DescriptionBed"]?.ToString(),
                            BathroomOption = row["DescriptionBat"]?.ToString()
                        };
                        plan.isUsed = _context.UnitAttributes.Count(fu => fu.FloorPlanTypeId == plan.FloorPlanTypeID) > 0;
                        floorPlanType.Add(plan);
                    }
                }
            }

            return floorPlanType;
        }
        public List<LutBathroomTypeOption> GetLutBathroomTypeOptionbyFLoorPlanTypeID()
        {
            return _context.LutBathroomTypeOptions.ToList();
        }
        public FloorPlanType GetFloorPlanTypeByID(int floorPlanTypeID)
        {
            return _context.FloorPlanTypes.FirstOrDefault(f => f.FloorPlanTypeId == floorPlanTypeID);
        } 
        public List<Document> GetFloorPlanFilesByID(string floorPlanTypeID)
        {
           var list= _context.AssnDocuments.Where(x => x.ReferenceId == floorPlanTypeID).ToList();
            var docList=list.Select(x => x.DocumentId).ToList();
           var files= _context.Documents.Where(x=> docList.Contains(x.DocumentId)).ToList();
            return files;
        }
        public List<FloorPlanBathroomType> GetFloorPlanBathroomTypeByFloorPlanID(int floorPlanID)
        {
            return _context.FloorPlanBathroomTypes.Where(b => b.FloorPlanTypeId == floorPlanID).ToList();
        }
        public ProjectSite GetProjectSiteIDByFloorPlanID(int ProjectSiteID)
        {
            return _context.ProjectSites.Where(s => s.ProjectSiteId == ProjectSiteID).FirstOrDefault();
        }
        public int UpdateFloorPlanType(FloorPlanTypeModel floorPlanTypeModel)
        {
            return _context.SaveChanges(floorPlanTypeModel.UserName);
        }
        public int DeleteFloorPlanType(FloorPlanType floorPlanType)
        {
            return _context.SaveChanges(floorPlanType.ModifiedBy);
        }
        public bool DeleteFloorPlanFile(int docId)
        {
            var file = _context.Documents.FirstOrDefault(d => d.DocumentId == docId);
            if (file != null)
            {

               var data = _context.AssnDocuments.Where(x => x.DocumentId == docId);
                if (data.Any())
                {
                    _context.AssnDocuments.RemoveRange(data);
                }
                _context.Documents.Remove(file);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public int RemoveFloorPlanBathroomType(FloorPlanBathroomType floorPlanBathroomType)
        {
            _context.FloorPlanBathroomTypes.Remove(floorPlanBathroomType);
            return _context.SaveChanges();
        }
        public List<UnitAttribute> GetUnitAttributesbyFloorPlanID(int floorPlanTypeID)
        {
            return _context.UnitAttributes.Where(u => u.FloorPlanTypeId == floorPlanTypeID).ToList();
        }
        public List<UnitBathroomType> GetUnitBathroomTypebyUnitAttributeID(int unitAttributeId)
        {
            return _context.UnitBathroomTypes.Where(u => u.UnitAttributeId == unitAttributeId).ToList();
        }
        public int RemoveUnitPlanBathroomType(UnitBathroomType unitBathroomType)
        {
            _context.UnitBathroomTypes.Remove(unitBathroomType);
            return _context.SaveChanges();

        }
        public int AddUnitPlanBathroomTypeAsync(UnitBathroomType bathroomType)
        {
            _context.UnitBathroomTypes.Add(bathroomType);
            return _context.SaveChanges();

        }
        public List<LutBathroomType> GetLutBathroomTypeEdit()
        {
            return _context.LutBathroomTypes.ToList();
        }
        public List<LutBathroomTypeOption> GetLutBathroomTypeOptionEdit()
        {
            return _context.LutBathroomTypeOptions.ToList();
        }
        public int UpdateUnitAttribute(UnitAttribute unit)
        {
            return _context.SaveChanges(unit.FirstName);
        }
        public List<FloorPlanInformation> GetFloorPlanInformationCompliance(int caseId)
        {
            var floorPlanInformations = new List<FloorPlanInformation>();
            var sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter() { ParameterName = "@CaseId", Value = caseId }
                };
            using (var dataTableUnits = _storedProcedureExecutor.ExecuteStoreProcedure("AAHPCC.uspGetFloorPlansForComplianceMetrix", sqlParameters))
            {
                foreach (DataRow row in dataTableUnits.Rows)
                {
                    var info = new FloorPlanInformation
                    {
                        FloorPlanTypeID = row["FloorPlanTypeID"] != DBNull.Value ? Convert.ToInt32(row["FloorPlanTypeID"]) : 0,
                        Name = row["Name"]?.ToString(),
                        // map other columns as needed
                    };

                    floorPlanInformations.Add(info);
                }
            }

            return floorPlanInformations;
        }
        public int? getLuDocumentCategoryId(string category, string subCategory)
        {
            return _context.LutDocumentCategories.Where(x => x.Category == category && x.SubCategory == subCategory).FirstOrDefault()?.LutDocumentCategoryId;
        }

        public void SaveFloorPlanFile(List<Document> doclist,FloorPlanTypeModel floorPlan)
        {
            foreach(Document list in doclist)
            {
                _context.Documents.Add(list);
                _context.SaveChanges(list.CreatedBy);
            }
                
        }
    }
}
