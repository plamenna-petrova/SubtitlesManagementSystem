using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SubtitlesManagementSystem.WebModels.FilmProductions.BindingModels
{
    public class EditFilmProductionBindingModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2,
            ErrorMessage = "The film production's title cannot be shorter than 2 symbols and longer than 30 symbols")]
        public string Title { get; set; }

        [Required]
        [Range(45, 240, ErrorMessage = "The film production's duration must be in the range of 45 to 240 minutes")]
        public int Duration { get; set; }

        [Required]
        [DisplayName("Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 2,
                ErrorMessage = "The film production's plot summary cannot be shorter than 2 symbols and longer than 500 symbols")]
        [DisplayName("Plot Summary")]
        public string PlotSummary { get; set; }

        public string CountryId { get; set; }
    }
}
