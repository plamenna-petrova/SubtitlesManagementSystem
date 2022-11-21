using SubtitlesManagementSystem.Data.Repositories.Interfaces;
using SubtitlesManagementSystem.Models.Entities;
using System.Linq.Expressions;

namespace SubtitlesManagementSystem.Data.Repositories.Implementation
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        public ActorRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }

        public override bool Exists(IQueryable<Actor> actorEntities,
            Actor actorEntityToFind)
        {
            Expression<Func<Actor, bool>> existingActorPredicate = a =>
                a.FirstName.Trim().ToLower() ==
                    actorEntityToFind.FirstName.Trim().ToLower() &&
                a.LastName.Trim().ToLower() ==
                    actorEntityToFind.LastName.Trim().ToLower();

            bool actorExists = actorEntities.Any(existingActorPredicate);

            return actorExists;
        }
    }
}
