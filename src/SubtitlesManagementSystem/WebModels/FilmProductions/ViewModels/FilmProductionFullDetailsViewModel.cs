namespace SubtitlesManagementSystem.WebModels.FilmProductions.ViewModels
{
    public class FilmProductionFullDetailsViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public int Duration { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string PlotSummary { get; set; }

        public string CountryName { get; set; }
    }
}
