using SubtitlesManagementSystem.Models.Abstraction;

namespace SubtitlesManagementSystem.Models.Entities
{
    public class Actor: BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
