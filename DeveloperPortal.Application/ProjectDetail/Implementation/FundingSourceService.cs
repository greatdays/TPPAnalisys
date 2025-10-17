using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.DataAccess.Repository.Implementation;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.Domain.FundingSource;
using DeveloperPortal.Models.IDM;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace DeveloperPortal.Application.ProjectDetail.Implementation
{
    public class FundingSourceService : IFundingSourceService
    {
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        private IConfiguration _config;
        private readonly IFundingSourceRepository _fundingSourceRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IAccountRepository _accountRepository;
        public FundingSourceService(IStoredProcedureExecutor storedProcedureExecutor, IConfiguration config, IFundingSourceRepository fundingSourceRepository, IAccountRepository accountRepository, IHttpContextAccessor httpContextAccessor)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
            _config = config;
            _fundingSourceRepository = fundingSourceRepository;
            _accountRepository = accountRepository;
            _httpContextAccessor = httpContextAccessor;
        }





        public async Task<List<FundingSourceViewModel>> GetAllFundingSourceDoc(string caseId, string projectId)
        {
            var userName = UserSession.GetUserSession(_httpContextAccessor.HttpContext).UserName;
            var contactIdentifierID = await _accountRepository.GetContactIdentifierByUserName(userName);
            bool verified=false;
            List<FundingSourceViewModel> lstFundingSourceViewModel = new List<FundingSourceViewModel>();

            if (contactIdentifierID != null)
            {
                 verified = _fundingSourceRepository.IsContactVerified(contactIdentifierID.ContactIdentifierId, int.Parse(projectId));

                try
                {
                    lstFundingSourceViewModel = _fundingSourceRepository.GetFundingSourceByUsers(caseId, userName, verified).Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
            return lstFundingSourceViewModel;
        }


        public async Task<FundingSourceViewModel> GetFundingSourceById(int funDingSourceId)
        {
            FundingSourceViewModel lstFundingSourceViewModel = new FundingSourceViewModel();
            try
            {
                lstFundingSourceViewModel = await _fundingSourceRepository.GetFundingSourceById(funDingSourceId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            return lstFundingSourceViewModel;
        }



        public async Task<bool> SaveDocumentForFundingSource( FundingSourceViewModel viewModel)
        {

            bool isSuccess = await _fundingSourceRepository.SaveDocumentForFundingSource(viewModel);
            if (isSuccess)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public int? getLuDocumentCategoryId(string category, string subCategory)
        {
            return _fundingSourceRepository.getLuDocumentCategoryId(category, subCategory);
        }


        public async Task<bool> DeleteFundingSource(int id, string modifiedBy)
        {
           

            return await _fundingSourceRepository.DeleteFundingSource(id, modifiedBy);
        }
        public Document getDocumentById(int? id)
        {
            return _fundingSourceRepository.getDocumentById(id);
        }
    }
}


