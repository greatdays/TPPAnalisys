//using ComCon.DataAccess.Models.Helpers;
//using ComCon.DataAccess.ViewModel;
using DeveloperPortal.Models.Common;
using DeveloperPortal.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Specialized;
//using ComCon.DataAccess.ViewModel;
using DeveloperPortal.DataAccess.Entity.Models.Helper.ComCon;
using DeveloperPortal.DataAccess.Entity.ViewModels.ComCon;
using DeveloperPortal.Models.Helper;
using DeveloperPortal.DataAccess.Entity.Models.Generated;
using DeveloperPortal.Application.PropertySnapshot;
using DeveloperPortal.Domain.PropertySnapshot;
using DeveloperPortal.Constants;
using DeveloperPortal.Application.ServiceClient;
using DeveloperPortal.Application;
using DeveloperPortal.Areas.Document.Models;
using DeveloperPortal.Domain.ProjectDetail;
using DeveloperPortal.Extensions;
using Microsoft.EntityFrameworkCore;
using DeveloperPortal.Domain.FundingSource;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using DeveloperPortal.ServiceClient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using ComCon.DataAccess.ViewModel;
using HCIDLA.ServiceClient.DMS;
using static NuGet.Packaging.PackagingConstants;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.Application.DMS.Interface;

namespace DeveloperPortal.Controllers
{





    public class FundingSourceController : Controller
    {

        private IConfiguration _config;
        private readonly IDocumentService _documentService;
        public FundingSourceController(IConfiguration configuration, IDocumentService documentService)
        {
            _config = configuration;
            _documentService = documentService;
        }



        private static List<FundingSourceViewModel> fundingSourceData = new List<FundingSourceViewModel>
    {
        new FundingSourceViewModel
        {
            FundingSourceId = 1,
            FundingSource = "TCAC",
            FileName = "tcac.xlsx",
            Notes = "Scoring sheet",
            MU_Unit = 10,
            HV_Unit = 4,
            DocumentID = 101
        },
        new FundingSourceViewModel
        {
            FundingSourceId = 2,
            FundingSource = "LALDA",
            FileName = "lalda2.pdf",
            Notes = "Architecture recruitment",
            MU_Unit = 15,
            HV_Unit = 10,
            DocumentID = 102
        },
        new FundingSourceViewModel
        {
            FundingSourceId = 3,
            FundingSource = "TCAC",
            FileName = "tcacfile.xlsx",
            Notes = "Second Scoring sheet",
            MU_Unit = 10,
            HV_Unit = 4,
            DocumentID = 103
        }
    };

        // GET: /Document/FundingSource
        public ActionResult FundingSource(int caseId, int controlViewModelId)
        {

            var model = new FundingSourcePageViewModel
            {
                CaseId = caseId,
                ControlViewModelId = controlViewModelId,
                FundingSources = fundingSourceData
            };
            fundingSourceData[0].CaseId = caseId;
            fundingSourceData[1].CaseId = caseId;
            fundingSourceData[2].CaseId = caseId;
            
            return PartialView("~/Pages/FundingSource/FundingSource.cshtml", model);

            // D:\Trinus\DEV\Third Party Portal\UI\DeveloperPortal\Pages\FundingSource\FundingSource.cshtml
        }

        // GET: /Document/FundingSource/Edit/5
        public ActionResult Edit(int id)
        {
            var fundingSource = fundingSourceData.FirstOrDefault(fs => fs.FundingSourceId == 1);
            //FundingSourceViewModel fundingSource = new();
            //fundingSource.FundingSourceId = 1;
            //fundingSource.FundingSource = "TCAC";
            // fundingSource.FileName = "tcac.xlsx";
            // fundingSource.Notes = "Scoring sheet";
            // fundingSource.MU_Unit = 10;
            // fundingSource.HV_Unit = 4;
            //fundingSource.DocumentID = 101;
            if (fundingSource == null)
            {
                return HttpNotFound();
            }
            return PartialView("~/Pages/FundingSource/FundingSourcePopUp.cshtml", fundingSource);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        // POST: /Document/FundingSource/Update
        //[HttpPost]
        //public JsonResult Update(FundingSourceViewModel model)
        //{
        //    var fundingSourceToUpdate = fundingSourceData.FirstOrDefault(fs => fs.FundingSourceId == model.FundingSourceId);
        //    if (fundingSourceToUpdate != null)
        //    {
        //        fundingSourceToUpdate.Notes = model.Notes;
        //        fundingSourceToUpdate.MU_Unit = model.MU_Unit;
        //        fundingSourceToUpdate.HV_Unit = model.HV_Unit;
        //        // You can add logic for file replacement here
        //        return Json(new { success = true });
        //    }
        //    return Json(new { success = false });
        //}


        [HttpPost]
        [ValidateAntiForgeryToken] // Recommended for form submissions
        public async Task<IActionResult> Update([FromForm] FundingSourceViewModel viewModel)
        {
            string fileCategory = "Project", fileSubCategory = "FundingSource";
            if (!ModelState.IsValid)
            {
                return PartialView("~/Pages/FundingSource/FundingSourcePopUp.cshtml", viewModel);
            }
            IFormFile file = HttpContext.Request.Form.Files[0];
            var caseId= Convert.ToInt32(HttpContext.Request.Form["CaseId"]);
            var emailId = "testQ@yopmail.com";
            // Your logic to find and update the funding source
            var fundingSourceToUpdate = fundingSourceData.FirstOrDefault(fs => fs.FundingSourceId == viewModel.FundingSourceId);
            if (fundingSourceToUpdate != null)
            {
                fundingSourceToUpdate.Notes = viewModel.Notes;
                fundingSourceToUpdate.MU_Unit = viewModel.MU_Unit;
                fundingSourceToUpdate.HV_Unit = viewModel.HV_Unit;
                fundingSourceToUpdate.Description = viewModel.Description;
             

                // Handle the file upload
                if (viewModel.File != null)
                {
                    // Save the file to your desired location (e.g., file system or cloud storage)
                    // Example:
                    // var filePath = Path.Combine("your-upload-path", viewModel.File.FileName);
                    // using (var stream = new FileStream(filePath, FileMode.Create))
                    // {
                    //     await viewModel.File.CopyToAsync(stream);
                    // }
                    // Update the FileName property
                    var uploadResponse = new DMSService(_config).SubmitUploadedDocument(file, emailId, caseId, fileCategory, fileSubCategory);
                   
                    var response = uploadResponse.Value as UploadResponse;

                    if (response == null || (response.ErrorMessages != null && response.ErrorMessages.Length > 0))
                    {
                        return new JsonResult(new
                        {
                            Success = false,
                            Message = "Failed to upload document.\n" +
                                      (response?.ErrorMessages != null
                                          ? string.Join("; ", response.ErrorMessages)
                                          : "Unknown error")
                        });
                    }

                    var documentModel = new DocumentModel()
                    {
                        Name = file.FileName,
                        Link = response.UniqueId.ToString(),
                        Attributes = "",
                        FileSize = file.Length.ToString(),
                        CaseId = caseId,
                        //FolderId = 0,
                        Comment = fundingSourceToUpdate.Description,
                        OtherDocumentType = null,
                        CreatedBy = "testQ",
                        CreatedOn = DateTime.Now,
                        IsDeleted = false

                    };

                    var document = _documentService.SaveDocument(documentModel).Result;
                    fundingSourceToUpdate.FileName = viewModel.File.FileName;
                }

                return Json(new { success = true });
            }
            return Json(new { success = false });
        }



        // POST: /Document/FundingSource/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var fundingSourceToRemove = fundingSourceData.FirstOrDefault(fs => fs.FundingSourceId == id);
            if (fundingSourceToRemove != null)
            {
                fundingSourceData.Remove(fundingSourceToRemove);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        // This method would handle the 'Add' functionality (e.g., from the "Upload Funding Source" button)
        // POST: /Document/FundingSource/Create
        [HttpPost]
        public JsonResult Create(FundingSourceViewModel newFundingSource)
        {
            if (ModelState.IsValid)
            {
                // Assign a new unique ID
                newFundingSource.FundingSourceId = fundingSourceData.Any() ? fundingSourceData.Max(fs => fs.FundingSourceId) + 1 : 1;
                fundingSourceData.Add(newFundingSource);
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        //[HttpGet]
        ////[Route("Document/DMS/GetFilesById")]
        //public async Task<IActionResult> GetFilesById(int caseId, int controlViewModelId)
        //{
        //    var fundingSources = _context.FundingSource
        //         .Select(fs => new FundingSourceViewModel
        //         {
        //             FundingSourceId = fs.FundingSourceId,
        //             Notes = fs.Notes,
        //             MU_Unit = fs.MU_Unit,
        //             HV_Unit = fs.HV_Unit,
        //             // Assuming you have a way to get FundingSource and FileName, e.g., by joining with a Document table
        //             FundingSource = "Your Source", // Placeholder
        //             FileName = "Your File Name" // Placeholder
        //         }).ToList();


        //    return PartialView("~/Areas/Document/Views/FundingSource/FundingSource.cshtml", fundingSources);

        //    return View("~/Areas/Document/Views/DMS/DMSView.cshtml", null);
        //}


        //// In your FundingSourceController.cs

        //public ActionResult FundingSource(int caseId, int controlViewModelId)
        //{
        //    // Fetch data from the database and pass it to the view
        //    var fundingSources = _context.FundingSource
        //        .Select(fs => new FundingSourceViewModel
        //        {
        //            FundingSourceId = fs.FundingSourceId,
        //            Notes = fs.Notes,
        //            MU_Unit = fs.MU_Unit,
        //            HV_Unit = fs.HV_Unit,
        //            // Assuming you have a way to get FundingSource and FileName, e.g., by joining with a Document table
        //            FundingSource = "Your Source", // Placeholder
        //            FileName = "Your File Name" // Placeholder
        //        }).ToList();

        //    return PartialView("~/Areas/Document/Views/FundingSource/FundingSource.cshtml", fundingSources);
        //}

        //// Action to handle the Edit popup
        //public ActionResult Edit(int id)
        //{
        //    var fundingSource = _context.FundingSource.Find(id);

        //    var viewModel = new FundingSourceViewModel
        //    {
        //        FundingSourceId = fundingSource.FundingSourceId,
        //        Notes = fundingSource.Notes,
        //        MU_Unit = fundingSource.MU_Unit,
        //        HV_Unit = fundingSource.HV_Unit,
        //        DocumentId = fundingSource.DocumentID
        //    };
        //    return PartialView("EditFundingSource", viewModel);
        //}

        //// Action to handle the form submission for updates
        //[HttpPost]
        //public JsonResult Update(FundingSourceViewModel model)
        //{
        //    var fundingSource = _context.FundingSource.Find(model.FundingSourceId);
        //    if (fundingSource != null)
        //    {
        //        fundingSource.Notes = model.Notes;
        //        fundingSource.MU_Unit = model.MU_Unit;
        //        fundingSource.HV_Unit = model.HV_Unit;
        //        fundingSource.ModifiedDate = DateTime.Now;
        //        fundingSource.ModifiedBy = User.Identity.Name;

        //        _context.SaveChanges();
        //        return Json(new { success = true });
        //    }
        //    return Json(new { success = false });
        //}

        //// Action to handle the delete operation
        //[HttpPost]
        //public JsonResult Delete(int id)
        //{
        //    var fundingSource = _context.FundingSource.Find(id);
        //    if (fundingSource != null)
        //    {
        //        _context.FundingSource.Remove(fundingSource);
        //        _context.SaveChanges();
        //        return Json(new { success = true });
        //    }
        //    return Json(new { success = false });
        //}


    }

}

