using SubtitlesManagementSystem.Models.Abstraction;

namespace SubtitlesManagementSystem.Models.Entities
{
    public class Subtitles : BaseEntity
    {
        public string Name { get; set; }

        public string FilmProductionId { get; set; }

        public virtual FilmProduction FilmProduction { get; set; }
    }
}
