using SubtitlesManagementSystem.Data.Repositories.Interfaces;
using SubtitlesManagementSystem.Models.Entities;

namespace SubtitlesManagementSystem.Data.Repositories.Implementation
{
    public class FilmProductionActorRepository: BaseRepository<FilmProductionActor>, IFilmProductionActorRepository
    {
        public FilmProductionActorRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
    }
}
