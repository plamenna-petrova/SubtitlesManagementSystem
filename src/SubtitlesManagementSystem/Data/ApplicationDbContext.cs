using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SubtitlesManagementSystem.Models.Entities;
using SubtitlesManagementSystem.Models.Interfaces;

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

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override int SaveChanges()
        {
            return SaveChanges(true);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyEntityChanges();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private void ApplyEntityChanges()
        {
            var changeTrackerEntries = this.ChangeTracker.Entries()
               .Where(
                    x => x.Entity is IAuditInfo &&
                    (x.State == EntityState.Added || x.State == EntityState.Modified)
                );

            foreach (var changeTrackerEntry in changeTrackerEntries)
            {
                var auditableEntity = (IAuditInfo)changeTrackerEntry.Entity;

                switch (changeTrackerEntry.State)
                {
                    case EntityState.Added:
                        auditableEntity.CreatedOn = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        auditableEntity.ModifiedOn = DateTime.UtcNow;
                        break;
                }
            }
        }
    }
}