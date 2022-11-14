using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SubtitlesManagementSystem.Models.Entities;

namespace SubtitlesManagementSystem.Data.EntityTypeConfigurations
{
    public class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> countryEntityTypeBuilder)
        {
            countryEntityTypeBuilder
               .HasMany(c => c.FilmProductions)
               .WithOne(fp => fp.Country)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
