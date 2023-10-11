using Microsoft.AspNetCore.Http;

namespace DeveloperPortal.Models.PlanReview
{
    public class UploadFileModel
    {
        public DateTime? ReceivedDate { get; set; }
        public string? Category { get; set; }
        public string? Status { get; set; }
        public string? FolderName { get; set; }
        public string? FileName { get; set; }
        public IFormFile? Files { get; set; }
    }
}
