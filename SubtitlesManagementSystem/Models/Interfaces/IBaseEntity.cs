using System.ComponentModel.DataAnnotations;

namespace SubtitlesManagementSystem.Models.Interfaces
{
    public interface IBaseEntity<TKey>
    {
        [Key]
        TKey Id { get; set; }
    }
}
