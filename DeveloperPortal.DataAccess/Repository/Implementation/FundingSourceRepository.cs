using DeveloperPortal.DataAccess.Entity.Data;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.Domain.FundingSource;
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

            var fundingSources = await (from fs in _context.FundingSources
                                        where !(fs.IsDeleted ?? false)
                                        join d in _context.Documents
                                            on fs.DocumentId equals d.DocumentId into dGroup
                                        from d in dGroup.DefaultIfEmpty()
                                        join adFiltered in _context.AssnDocuments
                                            .Where(ad => ad.ReferenceId == referenceId) // ✅ filter here
                                            on d.DocumentId equals adFiltered.DocumentId into adGroup
                                        from ad in adGroup.DefaultIfEmpty()
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
                                            CreatedDate = fs.CreatedDate,
                                            FileSize = d.FileSize,
                                            CreatedBy = fs.CreatedBy
                                        })
                            .ToListAsync();
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
                                            CreatedDate = fs.CreatedDate,
                                            Notes = d.Comment,
                                            DocumentID = d.DocumentId,
                                            Link = d.Link,
                                            FileSize = d.FileSize,
                                            FileName = d.Name,
                                        })
                            .FirstOrDefaultAsync();
            return fundingSources;
        }

        public async Task<bool> SaveDocumentForFundingSource(DocumentModel documentModel, FundingSourceViewModel viewModel)
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
                        document.Name = documentModel.Name;
                        document.Link = documentModel.Link;
                        document.FileSize = documentModel.FileSize;
                        document.OtherDocumentType = documentModel.OtherDocumentType;
                        document.Comment = documentModel.Comment;
                        document.CreatedBy = documentModel.CreatedBy;
                        document.CreatedOn = DateTime.Now;
                        document.ModifiedBy = documentModel.CreatedBy;
                        document.ModifiedOn = DateTime.Now;
                        _context.Documents.Update(document);
                        _context.SaveChanges();
                        if (document.DocumentId != null)
                        {

                            fundingSource.FundingSourceId = viewModel.FundingSourceId;
                            fundingSource.MuUnit = viewModel.MU_Unit;
                            fundingSource.HvUnit = viewModel.HV_Unit;
                            fundingSource.FundingSourceName = viewModel.FundingSource;
                            fundingSource.DocumentId = document.DocumentId;
                            fundingSource.CreatedBy = documentModel.CreatedBy;
                            fundingSource.CreatedDate = DateTime.Now;
                            fundingSource.ModifiedBy = documentModel.CreatedBy;
                            fundingSource.ModifiedDate = DateTime.Now;
                            fundingSource.IsDeleted = false;

                        }
                        _context.FundingSources.Update(fundingSource);
                        _context.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    var document = new Document
                    {
                        Name = documentModel.Name,
                        Link = documentModel.Link,
                        FileSize = documentModel.FileSize,
                        Comment = documentModel.Comment,
                        Attributes = documentModel.Attributes,
                        OtherDocumentType = documentModel.OtherDocumentType,
                        CreatedBy = documentModel.CreatedBy,
                        CreatedOn = DateTime.Now,
                        ModifiedBy = documentModel.CreatedBy,
                        ModifiedOn = DateTime.Now,
                        IsDeleted = false,
                        AssnDocuments =
                    {
                        new AssnDocument
                        {
                            ReferenceId = documentModel.CaseId.ToString(),
                            ReferenceType = ReferenceType.Case.ToString(),
                            CreatedBy =  documentModel.CreatedBy,
                            CreatedOn =  DateTime.Now,
                            ModifiedBy =  documentModel.CreatedBy,
                            ModifiedOn =  DateTime.Now
                        }
                    }
                    };
                    _context.Documents.Add(document);
                    await _context.SaveChangesAsync();

                    if (document.DocumentId != null)
                    {
                        var fundingSource = new FundingSource
                        {
                            MuUnit = viewModel.MU_Unit,
                            HvUnit = viewModel.HV_Unit,
                            FundingSourceName = viewModel.FundingSource,
                            DocumentId = document.DocumentId,
                            CreatedBy = documentModel.CreatedBy,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = documentModel.CreatedBy,
                            ModifiedDate = DateTime.Now,
                            IsDeleted = false
                        };

                        _context.FundingSources.Add(fundingSource);
                        await _context.SaveChangesAsync();
                    }
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }

            return true;
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

    }
}
