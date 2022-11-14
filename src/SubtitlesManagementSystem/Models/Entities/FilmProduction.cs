using SubtitlesManagementSystem.Models.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace SubtitlesManagementSystem.Models.Entities
{

    public class FilmProduction : BaseEntity
    {
        public FilmProduction()
        {
            FilmProductionActors = new HashSet<FilmProductionActor>();
        }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [Range(45, 240)]
        public int Duration { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(500)]
        public string PlotSummary { get; set; }

        public virtual Subtitles Subtitles { get; set; }

        public string CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<FilmProductionActor> FilmProductionActors { get; set; }
    }

}
