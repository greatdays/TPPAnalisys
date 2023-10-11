namespace DeveloperPortal.Models.PlanReview
{
    /// <summary>
    /// Plan Review File
    /// </summary>
    public class PlanReviewFile
    {
        /// <summary>
        /// FolderId
        /// </summary>
        public int FolderId { get; set; }
        /// <summary>
        /// Folder Name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// FileId
        /// </summary>
        public int FileId { get; set; }
        /// <summary>
        /// UploadedDate
        /// </summary>
        public DateTime UploadedDate { get; set; }
        /// <summary>
        /// ShareWithNAC
        /// </summary>
        public bool ShareWithNAC { get; set; }

        /// <summary>
        /// UploadedBy
        /// </summary>
        public string UploadedBy { get; set; } = string.Empty;
        /// <summary>
        /// FilePath
        /// </summary>
        public string FilePath { get; set; } = string.Empty;

        /// <summary>
        /// Category
        /// </summary>
        public string Category { get; set; } = string.Empty;
    }
}
