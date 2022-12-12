using SubtitlesManagementSystem.WebModels.Countries.ViewModels;

namespace SubtitlesManagementSystem.WebModels.FilmProductions.ViewModels
{
    public class AllFilmProductionsViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public int Duration { get; set; }

        public DateTime ReleaseDate { get; set; }

        public CountryConciseInformationViewModel RelatedCountry { get; set; }
    }
}
