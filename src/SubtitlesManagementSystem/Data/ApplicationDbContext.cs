using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SubtitlesManagementSystem.Models.Entities;

namespace SubtitlesManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Actor> Actors { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<FilmProduction> FilmProductions { get; set; }

        public virtual DbSet<FilmProductionActor> FilmProductionActors { get; set; }

        public virtual DbSet<Subtitles> Subtitles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureEntityRelations(modelBuilder);
        }

        private void ConfigureEntityRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}