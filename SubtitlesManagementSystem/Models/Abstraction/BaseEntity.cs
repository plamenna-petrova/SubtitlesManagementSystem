using SubtitlesManagementSystem.Models.Interfaces;

namespace SubtitlesManagementSystem.Models.Abstraction
{
    public abstract class BaseEntity : IBaseEntity<string>, IAuditInfo
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString().Substring(0, 7);
        }

        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
