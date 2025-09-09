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
                lstFundingSourceViewModel = _fundingSourceRepository.GetFundingSourceById(funDingSourceId).Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            return lstFundingSourceViewModel;
        }



        public async Task<DocumentModel> SaveDocumentForFundingSource(DocumentModel documentModel, FundingSourceViewModel viewModel)
        {

            bool isSuccess = await _fundingSourceRepository.SaveDocumentForFundingSource(documentModel, viewModel);
            if (isSuccess)
            {
                return documentModel;
            }
            else
            {
                return new DocumentModel();
            }

        }
    }
}


