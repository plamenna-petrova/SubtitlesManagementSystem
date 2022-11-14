namespace SubtitlesManagementSystem.Models.Interfaces
{
    public interface IAuditInfo
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
