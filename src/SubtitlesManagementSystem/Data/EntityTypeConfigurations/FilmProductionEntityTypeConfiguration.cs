using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SubtitlesManagementSystem.Models.Entities;

namespace SubtitlesManagementSystem.Data.EntityTypeConfigurations
{
    public class FilmProductionEntityTypeConfiguration : IEntityTypeConfiguration<FilmProduction>
    {
        public void Configure(EntityTypeBuilder<FilmProduction> filmProductionEntityTypeBuilder)
        {
            filmProductionEntityTypeBuilder
                .HasOne(fp => fp.Subtitles)
                .WithOne(s => s.FilmProduction)
                .HasForeignKey<Subtitles>(s => s.FilmProductionId);
        }
    }
}
