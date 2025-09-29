using DeveloperPortal.Application.Common;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Application.PropertySnapshot;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.ProjectDetail;
using DeveloperPortal.Models.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Web.Helpers;

namespace DeveloperPortal.Application.ProjectDetail.Implementation
{
    public class DevelopmentTeamService : IDevelopmentTeamService
    {
        #region Constructor
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        private readonly ILutRepository _lutRepository;
        private readonly IContactIdentifiersService _contactIdentifiersService;
        private IConfiguration _config;
        /// <summary>
        /// ProjectParticipantService
        /// </summary>
        /// <param name="storedProcedureExecutor"></param>
        /// <param name="lutRepository"></param>
        public DevelopmentTeamService(IStoredProcedureExecutor storedProcedureExecutor,
            ILutRepository lutRepository, IConfiguration config, IContactIdentifiersService contactIdentifiersService)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
            _lutRepository = lutRepository;
            _config = config;
            _contactIdentifiersService = contactIdentifiersService;
        }
        #endregion
        #region Public Methods
        /// <summary>
        /// Project Participants
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="caseId"></param>
        /// <param name="apn"></param>
        /// <returns></returns>
        public async Task<List<DevelopmentTeamModel>> DevelopmentTeamList(int projectId, int caseId, string apn)
        {
            var developmentTeamList = new List<Domain.ProjectDetail.DevelopmentTeamModel>();
            try
            {
                var sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter() { ParameterName = "@projectID", Value = projectId },
                    new SqlParameter() { ParameterName = "@caseID", Value = caseId },
                    new SqlParameter() { ParameterName = "@apn", Value = apn },
                };
                using (var dt = await _storedProcedureExecutor.ExecuteStoredProcedureWithDataTableAsync(StoredProcedureNames.SP_uspRoGetAllProjectParticipantsForTPP, sqlParameters))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        developmentTeamList = dt.AsEnumerable()
                        .Select(row => new Domain.ProjectDetail.DevelopmentTeamModel
                        {
                            ContactId = row.Field<int>("ContactID"),
                            ContactIdentifierId = row.Field<int?>("ContactIdentifierID"),
                            ContactName = row.Field<string>("ContactName"),
                            Email = row.Field<string>("Email"),
                            Phone = row.Field<string>("Phone"),
                            FullAddress = row.Field<string>("FullAddress"),
                            ContactType = row.Field<string>("ContactType"),
                            Source = row.Field<string>("Source"),
                            Status = row.Field<string>("Status"),
                            CompanyName = row.Field<string>("CompanyName"),
                        })
                        .ToList();
                    }
                }
                return developmentTeamList;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// GetContactDetail
        /// </summary>
        /// <param name="apn"></param>
        /// <param name="caseId"></param>
        /// <param name="projectId"></param>
        /// <param name="projectSiteId"></param>
        /// <returns></returns>
        public async Task<ContactRenderModel> GetContactDetail(int contactIdentifierId, string apn, int caseId, int projectId = 0, int projectSiteId = 0)
        {
            ContactRenderModel contactRenderModel = new ContactRenderModel();

            if (contactIdentifierId > 0)
            {
                contactRenderModel = await _contactIdentifiersService.ContactIdentifier(contactIdentifierId);
            }
            contactRenderModel.ContactTypeList = new List<string>() { "Owner", "Property Manager", "CASP", "Developer", "Chief NAC", "NAC", "Contractor", "Project Manager", "Developer Architect" };
            contactRenderModel.CaseID = caseId;
            contactRenderModel.APN = apn;
            contactRenderModel.ProjectId = projectId;
            contactRenderModel.ProjectSiteId = projectSiteId;
            contactRenderModel.AddContactType = "Simple";
            contactRenderModel.Source = "TPP";
            var LutStateCDList = await _lutRepository.LutStates();
            foreach (var item in LutStateCDList)
            {
                contactRenderModel.LutStateCDList.Add(new SelectListItem
                {
                    Text = item.Description,
                    Value = item.LutStateCd
                });
            }
            return contactRenderModel;
        }
        /// <summary>
        /// Delete Contact
        /// </summary>
        /// <param name="contactId"></param>
        /// <returns></returns>

        public async Task<bool> DeleteContact(int contactId, int contactIdentifierId, string userName, int refProjectId = 0, int refProjectSiteId = 0)
        {
            ServiceClient.ServiceClient serviceClient = new ServiceClient.ServiceClient(_config);
            BaseResponse baseResponse = serviceClient.CreateRequest<BaseResponse>(null, _config["AreaMgmtAPIURL:PropertyApiURL"] + string.Format(WebApiConstant.DeleteContact, contactId, userName, refProjectId, refProjectSiteId), Application.ServiceClient.ServiceClient.ActionType.DELETE);
            if (Convert.ToInt32(baseResponse.Response) > 0)
            {
                if (contactIdentifierId > 0)
                {
                    await _contactIdentifiersService.DeleteContact(contactIdentifierId, userName, refProjectId, refProjectSiteId);
                }
                return true;
            }
            return false;

        }

        /// <summary>
        /// SaveContact
        /// </summary>
        /// <param name="renderModel"></param>
        /// <returns></returns>
        public async Task<bool> SaveContact(ContactRenderModel renderModel)
        {
            renderModel.Type = renderModel.AssociationTypes != null ? string.Join(",", renderModel.AssociationTypes) : "";
            renderModel.PrimaryTypes = renderModel.PrimaryAssociationTypes != null ? string.Join(",", renderModel.PrimaryAssociationTypes) : "";
            ServiceClient.ServiceClient serviceClient = new ServiceClient.ServiceClient(_config);
            BaseResponse baseResponse = serviceClient.CreateRequest<BaseResponse>(renderModel, _config["AreaMgmtAPIURL:PropertyApiURL"] + WebApiConstant.PostContact, Application.ServiceClient.ServiceClient.ActionType.POST);
            if (Convert.ToInt32(baseResponse.Response) > 0)
            {
                var sr = await _contactIdentifiersService.GetServiceRequestByCaseId(renderModel.CaseID);
                var contactIdentifierModel = new ContactIdentifierModel
                {
                    ContactIdentifierID = renderModel.ContactIdentifierID,
                    ContactID = Convert.ToInt32(baseResponse.Response),
                    FirstName = renderModel.FirstName,
                    LastName = renderModel.LastName,
                    MiddleName = renderModel.MiddleName,
                    Email = renderModel.Email,
                    HouseNum = renderModel.HouseNum,
                    HouseFracNum = renderModel.HouseFracNum,
                    PreDirCd = renderModel.PreDirection,
                    StreetName = renderModel.StreetName ?? renderModel.AddressLine1,
                    PostDirCd = renderModel.PostDirection,
                    City = renderModel.City,
                    State = renderModel.State,
                    Zip = renderModel.Zip,
                    Unit = renderModel.Unit ?? renderModel.AddressLine2,
                    APN = renderModel.APN,
                    ServiceRequestID = sr.ServiceRequestId,
                    ContactTypeName = renderModel.Type,
                    UserName = renderModel.UserName,
                    ContractorType = renderModel.ContractorType,
                    Source = renderModel.Source,
                    IsPrimary = renderModel.IsPrimary,
                    ProjectId = renderModel.ProjectId,
                    ProjectSiteID = renderModel.ProjectSiteId,
                    IdentifierValue = renderModel.IdentifierValue,
                    IdentifierType = renderModel.IdentifierType,
                    Company = renderModel.Company,
                    PrimaryTypes = renderModel.PrimaryTypes,
                    HomePhoneNumber = renderModel.PhoneHome,
                    BusinessPhoneNumber = renderModel.PhoneBusiness,
                    PhoneExtension = renderModel.PhoneExtension,
                    MobilePhoneNumber = renderModel.PhoneCell,
                    IsMarkedForMailing = renderModel.IsMarkedForMailing,
                    CASpNumber = renderModel.CASpNumber,
                    IsContactPublic = renderModel.IsContactPublic
                };
                var contactIdentifierId = await _contactIdentifiersService.SaveContact(contactIdentifierModel);
                return true;
            }
            return false;

        }


        #endregion
        #region Private Methods


        #endregion

    }
}
