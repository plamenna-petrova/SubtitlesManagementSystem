using SubtitlesManagementSystem.Models.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace SubtitlesManagementSystem.Models.Entities
{
    public class Country : BaseEntity
    {
        public Country()
        {
            FilmProductions = new HashSet<FilmProduction>();
        }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<FilmProduction> FilmProductions { get; set; }
    }
}
