using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.Domain.FundingSource;
using Microsoft.AspNetCore.Http;

namespace DeveloperPortal.Application.ProjectDetail.Interface
{
    public interface IFundingSourceService
    {
        Task<List<FundingSourceViewModel>> GetAllFundingSourceDoc(string caseId, string projectId);
        Task<FundingSourceViewModel> GetFundingSourceById(int funDingSourceId);
        Task<bool> SaveDocumentForFundingSource(FundingSourceViewModel viewModel);
        Task<bool> DeleteFundingSource(int id, string modifiedBy);
        int? getLuDocumentCategoryId(string category, string subCategory);
       Document getDocumentById(int? id);
    }
}
