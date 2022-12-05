using SubtitlesManagementSystem.Data.Repositories.Interfaces;
using SubtitlesManagementSystem.Models.Entities;

namespace SubtitlesManagementSystem.Data.Repositories.Implementation
{
    public class FilmProductionRepository: BaseRepository<FilmProduction>, IFilmProductionRepository
    {
        public FilmProductionRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
    }
}
