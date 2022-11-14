using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SubtitlesManagementSystem.Models.Entities;

namespace SubtitlesManagementSystem.Data.EntityTypeConfigurations
{
    public class FilmProductionActorEntityTypeConfiguration : IEntityTypeConfiguration<FilmProductionActor>
    {
        public void Configure(EntityTypeBuilder<FilmProductionActor> filmProductionActorEntityTypeBuilder)
        {
            filmProductionActorEntityTypeBuilder
                .HasKey(fpa => new { fpa.FilmProductionId, fpa.ActorId });
            filmProductionActorEntityTypeBuilder
                .HasOne(fpa => fpa.FilmProduction)
                .WithMany(fp => fp.FilmProductionActors)
                .HasForeignKey(fpa => fpa.FilmProductionId);
            filmProductionActorEntityTypeBuilder
                .HasOne(fpa => fpa.Actor)
                .WithMany(a => a.FilmProductionActors)
                .HasForeignKey(fpa => fpa.ActorId);
        }
    }
}
