using SubtitlesManagementSystem.Data.Repositories.Interfaces;
using SubtitlesManagementSystem.Models.Entities;

namespace SubtitlesManagementSystem.Data.Repositories.Implementation
{
    public class SubtitlesRepository: BaseRepository<Subtitles>, ISubtitlesRepository
    {
        public SubtitlesRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
    }
}
