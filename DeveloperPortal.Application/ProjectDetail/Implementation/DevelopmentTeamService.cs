using DeveloperPortal.Application.Common;
using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.Application.PropertySnapshot;
using DeveloperPortal.DataAccess.Entity.Models.StoredProcedureModels;
using DeveloperPortal.DataAccess.Repository.Implementation;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.ProjectDetail;
using DeveloperPortal.Models.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public async Task<ContactRenderModel> GetContactDetail(int contactId)
        {
            string apn = "";
            int caseId= 25662; 
            int projectId = 697; 
            int projectSiteId = 0;  
            ContactRenderModel contactRenderModel = new ContactRenderModel();

            contactRenderModel.ContactTypeList = new List<string>() { "Owner", "Property Manager", "CASP", "Developer", "Chief NAC", "NAC", "Contractor", "Project Manager", "Developer Architect" };
            //contactRenderModel.StreetPrefixes = new StreetPrefixService().GetStreetPrefix().Select(x => new StreetPrefixModel { PreDirCd = x.PreDirCd }).ToList();
            //contactRenderModel.StreetSuffixes = new StreetSuffixService().GetStreetSuffix().Select(x => new StreetSuffixModel { PostDirCd = x.PostDirCd }).ToList();
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
                //if (contactIdentifierId > 0)
                //{
                //    new _contactIdentifiersService.DeleteContact(contactIdentifierId, userName, refProjectId, refProjectSiteId);
                //}
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
            ServiceClient.ServiceClient serviceClient = new ServiceClient.ServiceClient(_config);
            BaseResponse baseResponse = serviceClient.CreateRequest<BaseResponse>(renderModel, _config["AreaMgmtAPIURL:PropertyApiURL"] + WebApiConstant.PostContact, Application.ServiceClient.ServiceClient.ActionType.POST);
            if (Convert.ToInt32(baseResponse.Response) > 0)
            {
                if (renderModel.ContactIdentifierID <= 0)
                {
                    var contactIdentifierId = await _contactIdentifiersService.SaveContact(new ContactIdentifierModel());
                }
                else if (renderModel.ContactIdentifierID > 0)
                {
                    //Update
                }
                return true;
            }
            return false;

        }


        #endregion
        #region Private Methods


        #endregion

    }
}
