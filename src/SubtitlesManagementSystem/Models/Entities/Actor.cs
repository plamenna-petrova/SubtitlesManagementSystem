using SubtitlesManagementSystem.Models.Abstraction;

namespace SubtitlesManagementSystem.Models.Entities
{
    public class Actor: BaseEntity
    {
        public Actor()
        {
            FilmProductionActors = new HashSet<FilmProductionActor>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<FilmProductionActor> FilmProductionActors { get; set; }
    }
}
