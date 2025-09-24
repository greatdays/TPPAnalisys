using DeveloperPortal.Application.ProjectDetail.Interface;
using DeveloperPortal.DataAccess.Repository.Implementation;
using DeveloperPortal.DataAccess.Repository.Interface;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.Domain.FundingSource;
using Microsoft.Extensions.Configuration;

namespace DeveloperPortal.Application.ProjectDetail.Implementation
{
    public class FundingSourceService : IFundingSourceService
    {
        private readonly IStoredProcedureExecutor _storedProcedureExecutor;
        private IConfiguration _config;
        private readonly IFundingSourceRepository _fundingSourceRepository;

        public FundingSourceService(IStoredProcedureExecutor storedProcedureExecutor, IConfiguration config, IFundingSourceRepository fundingSourceRepository)
        {
            _storedProcedureExecutor = storedProcedureExecutor;
            _config = config;
            _fundingSourceRepository = fundingSourceRepository;
        }





        public async Task<List<FundingSourceViewModel>> GetAllFundingSourceDoc(string caseId)
        {
            List<FundingSourceViewModel> lstFundingSourceViewModel = new List<FundingSourceViewModel>();
            try
            {
                lstFundingSourceViewModel = _fundingSourceRepository.GetFundingSource(caseId).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
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


        public async Task<bool> DeleteFundingSource(int id)
        {

            return await _fundingSourceRepository.DeleteFundingSource(id);
        }
    }
}


