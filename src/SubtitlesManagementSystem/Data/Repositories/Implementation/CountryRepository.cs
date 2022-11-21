using SubtitlesManagementSystem.Data.Repositories.Interfaces;
using SubtitlesManagementSystem.Models.Entities;
using System.Linq.Expressions;

namespace SubtitlesManagementSystem.Data.Repositories.Implementation
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }

        public override bool Exists(IQueryable<Country> countries, Country countryToFind)
        {
            Expression<Func<Country, bool>> countryExistsPredicate = c =>
                c.Name.Trim().ToLower() == countryToFind.Name;

            bool countryExists = countries.Any(countryExistsPredicate);

            return countryExists;
        }
    }
}
