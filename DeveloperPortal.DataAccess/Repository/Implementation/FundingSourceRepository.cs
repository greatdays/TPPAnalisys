using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.Domain.FundingSource;
using DeveloperPortal.Models.IDM;
using Microsoft.EntityFrameworkCore;
using static DeveloperPortal.DataAccess.Entity.ViewModels.CommentModel;

namespace DeveloperPortal.DataAccess.Repository.Implementation
{
    public class FundingSourceRepository : IFundingSourceRepository
    {
        private readonly AAHREntities _context;

        public FundingSourceRepository(AAHREntities context)
        {
            _context = context;
        }

        public async Task<List<FundingSourceViewModel>> GetFundingSource(string referenceId)
        {

            var fundingSources = (from fs in _context.FundingSources
                                  where !(fs.IsDeleted ?? false)
                                  join d in _context.Documents
                                             on fs.DocumentId equals d.DocumentId
                                         join ad in _context.AssnDocuments
                                             on d.DocumentId equals ad.DocumentId
                                         where ad.ReferenceId == referenceId  
                                         orderby fs.FundingSourceId
                                         select new FundingSourceViewModel
                                         {
                                             FundingSourceId = fs.FundingSourceId,
                                             FundingSource = fs.FundingSourceName,
                                             FileName = d.Name,
                                             MU_Unit = fs.MuUnit,
                                             HV_Unit = fs.HvUnit,
                                             CaseId = ad.ReferenceId,
                                             Notes = d.Comment,
                                             DocumentID = d.DocumentId,
                                             Link = d.Link,
                                             CreatedDate = fs.CreatedOn,
                                             FileSize = d.FileSize,
                                             CreatedBy = fs.CreatedBy
                                         }).ToList();

           
            return fundingSources;
        }

        public async Task<FundingSourceViewModel> GetFundingSourceById(int funDingSourceId)
        {

            var fundingSources = await (from fs in _context.FundingSources
                                        where !(fs.IsDeleted ?? false) && fs.FundingSourceId == funDingSourceId
                                        join d in _context.Documents
                                            on fs.DocumentId equals d.DocumentId into dGroup
                                        from d in dGroup.DefaultIfEmpty()
                                        join adFiltered in _context.AssnDocuments
                                            on d.DocumentId equals adFiltered.DocumentId into adGroup
                                        from ad in adGroup.DefaultIfEmpty()
                                        orderby fs.FundingSourceId
                                        select new FundingSourceViewModel
                                        {
                                            FundingSourceId = fs.FundingSourceId,
                                            FundingSource = fs.FundingSourceName,
                                            CreatedBy = fs.CreatedBy,
                                            MU_Unit = fs.MuUnit,
                                            HV_Unit = fs.HvUnit,
                                            CaseId = ad.ReferenceId,
                                            CreatedDate = fs.CreatedOn,
                                            Notes = d.Comment,
                                            DocumentID = d.DocumentId,
                                            Link = d.Link,
                                            FileSize = d.FileSize,
                                             FileName = d.Name,
                                        })
                            .FirstOrDefaultAsync();
            return fundingSources;
        }

        public async Task<bool> SaveDocumentForFundingSource(FundingSourceViewModel viewModel)
        {
            try
            {

                if (viewModel.DocumentID != null)
                {
                    var fundingSource = new FundingSource();
                    var document = _context.Documents.FirstOrDefault(x => x.DocumentId == viewModel.DocumentID);
                    if (viewModel.DocumentID != null && viewModel.DocumentID > 0)
                    {
                        document.DocumentId = viewModel.DocumentID ?? 0;
                        document.Name = viewModel.FileName;
                      //  document.OtherDocumentType = "FundingSource";
                        document.Comment = viewModel.Notes;
                        document.DocumentCategoryId = viewModel.LuDocumentCategoryId;
                        _context.Documents.Update(document);
                        _context.SaveChanges();
                        if (document.DocumentId != null)
                        {

                            fundingSource.FundingSourceId = viewModel.FundingSourceId;
                            fundingSource.MuUnit = viewModel.MU_Unit;
                            fundingSource.HvUnit = viewModel.HV_Unit;
                            fundingSource.FundingSourceName = viewModel.FundingSource;
                            fundingSource.DocumentId = document.DocumentId;
                            fundingSource.ModifiedBy = viewModel.CreatedBy;
                            fundingSource.ModifiedOn = DateTime.Now;
                            fundingSource.IsDeleted = false;

                        }
                        _context.FundingSources.Update(fundingSource);
                        _context.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    var fundingSource = new FundingSource
                    {
                        MuUnit = viewModel.MU_Unit,
                        HvUnit = viewModel.HV_Unit,
                        FundingSourceName = viewModel.FundingSource,
                        CreatedBy = viewModel.CreatedBy,
                        CreatedOn = DateTime.Now,
                        ModifiedBy = viewModel.CreatedBy,
                        ModifiedOn = DateTime.Now,
                        IsDeleted = false,
                        Document = new Document
                        {
                            Name = viewModel.FileName,
                            Link = viewModel.Link,
                            FileSize = viewModel.FileSize,
                            Comment = viewModel.Notes,
                            Attributes = "",
                          //  OtherDocumentType = "FundingSource",
                            CreatedBy = viewModel.CreatedBy,
                            CreatedOn = DateTime.Now,
                            ModifiedBy = viewModel.CreatedBy,
                            ModifiedOn = DateTime.Now,
                            IsDeleted = false,
                            DocumentCategoryId=viewModel.LuDocumentCategoryId,
                            AssnDocuments =
                                {
                                    new AssnDocument
                                    {
                                        ReferenceId = viewModel.CaseId.ToString(),
                                        ReferenceType = "Case",
                                        CreatedBy =  viewModel.CreatedBy,
                                        CreatedOn =  DateTime.Now,
                                        ModifiedBy =  viewModel.CreatedBy,
                                        ModifiedOn =  DateTime.Now
                                    }
                                }
                        }
                    };
                    _context.FundingSources.Add(fundingSource);
                    _context.SaveChanges(viewModel.CreatedBy);
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }
        public int? getLuDocumentCategoryId(string category,string subCategory)
        {
            return _context.LutDocumentCategories.Where(x => x.Category == category && x.SubCategory == subCategory).FirstOrDefault()?.LutDocumentCategoryId;
        }
        public async Task<Document> GetDocument(FundingSourceViewModel viewModel)
        {
            using (var context = new AAHREntities()) // Creates and disposes of a context manually
            {
                return await context.Documents.FirstOrDefaultAsync(x => x.DocumentId == viewModel.DocumentID);
            }

        }

        public async Task<FundingSource> GetFundingSource(Document document)
        {
            using (var context = new AAHREntities()) // Creates and disposes of a context manually
            {
                return await _context.FundingSources.FirstOrDefaultAsync(fs => fs.DocumentId == document.DocumentId);
            }

        }


        public async Task<FundingSource> GetFundingSourcebyId(int id)
        {
            using (var context = new AAHREntities()) // Creates and disposes of a context manually
            {
                return await _context.FundingSources.FirstOrDefaultAsync(fs => fs.DocumentId == id);
            }

        }


        public async Task<bool> DeleteFundingSource(int id, string modifiedBy)
        {

            var fundingSource = _context.FundingSources.FirstOrDefault(fs => fs.FundingSourceId == id);

            if (fundingSource != null)
            {

               
                var document = _context.Documents.FirstOrDefault(x => x.DocumentId == fundingSource.DocumentId);
                if (document != null && document.DocumentId > 0)
                {
                    document.IsDeleted =    true;

                    document.ModifiedBy = modifiedBy;
                    document.ModifiedOn = DateTime.Now;
                    _context.Documents.Update(document);
                    _context.SaveChanges();
                    if (document.DocumentId != null)
                    {

                        fundingSource.IsDeleted = true;
                        fundingSource.ModifiedBy = modifiedBy;
                        fundingSource.ModifiedOn = DateTime.Now;    
                    }
                    _context.FundingSources.Update(fundingSource);
                    _context.SaveChanges();
                    return true;
                }
                return true;
            }
            else
            {
                return false;
            }
            // Mark as deleted
           
        }

    }
}
