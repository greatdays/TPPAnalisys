namespace DeveloperPortal.Domain.ProjectDetail
{
    public class ProjectParticipantsModel
    {
        public int ProjectId { get; set; }
        public int ContactId { get; set; }
        public int? ContactIdentifierId { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ContactType { get; set; }
        public string Source { get; set; }
        public string FullAddress { get; set; }
        public string Status { get; set; }
    }
}
