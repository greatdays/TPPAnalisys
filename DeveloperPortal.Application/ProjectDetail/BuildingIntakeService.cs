using DeveloperPortal.Application.ProjectDetail.Implementation;
using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.ProjectDetail;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
namespace DeveloperPortal.Application.ProjectDetail
{
    public class BuildingIntakeService : IBuildingIntakeService
    {
        #region Constructor

        private IConfiguration _config;
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        private readonly IProjectDetailRepository _projectDetailRepository;
        private readonly AAHREntities _context;

        public BuildingIntakeService(IConfiguration configuration, IStoredProcedureExecutor storedProcedureExecutor,
            AAHREntities context, IProjectDetailRepository projectDetailRepository)
        {
            _config = configuration;
            _storedProcedureExecutor = storedProcedureExecutor;
            _projectDetailRepository = projectDetailRepository;
            _context = context;
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

                ServiceRequest serviceRequest = await _context.ServiceRequests.FirstOrDefaultAsync(f => f.CaseId == model.CaseId);
                if (null != serviceRequest)
                {
                    PropSnapshot caseProjectSite = serviceRequest.PropSnapshots.Where(w => w.IdentifierType == "ProjectSite").OrderByDescending(o => o.ProjectSiteId).FirstOrDefault();
                    // building or structure.
                    Structure structure = new Structure();
                    structure.StructureNo = model.BuildingName;
                    structure.Apnid = model.APNId;
                    structure.LutStructureTypeId = 1;
                    structure.TotalUnits = model.NumberofUnits;
                    structure.Source = "Construction";
                    structure.Attributes = "{\"Status\":\"V\"}";
                    structure.Status = "X";
                    structure.Description = model.BuildingDescription;
                    //structure.BuildingFileNumber = generatedFileNumber;
                    structure.CreatedBy = model.Username;
                    structure.CreatedOn = DateTime.Now;
                    structure.ModifiedBy = model.Username;
                    structure.ModifiedOn = DateTime.Now;
                    _context.Structures.Add(structure);

                    // site address
                    int? siteAddressId = 0;
                    if (model.IsAddAddress)
                    {
                        SiteAddress siteAddress = new SiteAddress();

                        siteAddress.HouseNum = model.HouseNum.ToString();
                        siteAddress.HouseFracNum = model.HouseFracNum;
                        siteAddress.PreDirCd = model.LutPreDirCd;
                        siteAddress.StreetName = model.StreetName;
                        siteAddress.StreetTypeCd = model.LutStreetTypeCD;
                        siteAddress.City = model.City;
                        siteAddress.State = model.LutStateCD;
                        siteAddress.Zip = model.Zip;
                        siteAddress.Source = "Construction";
                        siteAddress.Status = "X";
                        siteAddress.IsDeleted = false;
                        siteAddress.CreatedBy = model.Username;
                        siteAddress.CreatedOn = DateTime.Now;
                        siteAddress.ModifiedBy = model.Username;
                        siteAddress.ModifiedOn = DateTime.Now;
                        _context.SiteAddresses.Add(siteAddress);
                        siteAddressId = siteAddress.SiteAddressId;
                    }
                    else
                    {
                        siteAddressId = model.BuildingAddressID;
                    }

                    // structure attribute.
                    StructureAttribute structureAttribute = new StructureAttribute();
                    structureAttribute.NonResidental = model.IsNonResidential;
                    structureAttribute.BuildingDescription = model.BuildingDescription;
                    structureAttribute.CreatedBy = model.Username;
                    structureAttribute.CreatedOn = DateTime.Now;
                    structureAttribute.ModifiedBy = model.Username;
                    structureAttribute.ModifiedOn = DateTime.Now;

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
                    await _context.SaveChangesAsync();
                    structureAttribute.StructureId = structure.StructureId;
                    await _context.SaveChangesAsync();
                    isSaved = true;
                }

                return isSaved; // returns
            }
            catch (Exception)
            {

                throw;
                return false;
            }
        }
    }
}
