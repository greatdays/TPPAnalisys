using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using DeveloperPortal.Areas.Document.Models;
using DeveloperPortal.Application.DMS.Interface;
using DeveloperPortal.Domain.Dashboard;
using DeveloperPortal.Domain.DMS;
using DeveloperPortal.Application.DMS.Implementation;


namespace DeveloperPortal.Areas.Document.Controllers
{
    [Area("Document")]
    public class DMSController : Controller
    {
        private readonly IDocumentService _documentService;

        public DMSController(IDocumentService documentService)
        {
            this._documentService= documentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFilesByIdNew(int projectId)
        {
            var list = await _documentService.GetAllDocumentsBasedOnProjectId(projectId);
            return View("~/Areas/Document/Views/DMS/DMSView.cshtml", list); // Or Json(list) if it's an API
        }
        /*public ActionResult GetFilesByIdNew(int controlViewModelId)
        {
            // Normally you'd call a real method here
            var controlViewModel = new ControlViewModel
            {
                ControlId = "mock-id",
                CaseId = 0,
                ProjectSiteId = 0
            };

            return GetFiles(controlViewModel, "DMSViewNew");
        }

        public ActionResult GetFiles(ControlViewModel controlView, string returnView)
        {
            var model = new DMSModel
            {
                ControlId = controlView.ControlId,
                ControlViewModel = controlView,
                SearchResults = new List<DMSResult>()
            };

            // Mock DataTable with headers only
            var dataTable = new DataTable();
            var columns = new[] { "Date", "Filename", "Category", "Uploader", "Shared", "Actions" };
            foreach (var columnName in columns)
            {
                var col = dataTable.Columns.Add(columnName);
                col.ExtendedProperties["Visible"] = true; // Required by your view
            }

            var newRow = dataTable.NewRow();
            newRow["Date"] = DateTime.Now.ToShortDateString();
            newRow["Filename"] = "ExampleFile.pdf";
            newRow["Category"] = "Category";
            newRow["Uploader"] = "UploaderName";
            newRow["Shared"] = "NAC";
            newRow["Actions"] = "Download";
            dataTable.Rows.Add(newRow);

            model.SearchResults.Add(new DMSResult
            {
                Data = dataTable,
                ColumnOrder = new List<int> { 0, 1, 2, 3, 4, 5 },
                TabName = "Default"
            });

            return PartialView("~/Areas/Document/Views/DMS/DMSViewNew.cshtml", model);
        }*/

    }
}
