namespace DeveloperPortal.Domain.PropertySnapshot
{
    public class InspectionModel
    {
        public int InspectionId { get; set; }

        public int PropSnapshotId { get; set; }

        public long ServiceRequestId { get; set; }

        public int InspectionTypeId { get; set; }

        public string InspectionType { get; set; }

        public DateTime? InspectionStartOn { get; set; }

        public DateTime? InspectionEndOn { get; set; }

        public string InspectionResult { get; set; }

        public bool IsMain { get; set; }

        public int EventId { get; set; }

        public string UserName { get; set; }

        public int MainInspectionID { get; set; }

        public string LocationType { get; set; }

        public int LocationID { get; set; }
    }
}