using System.ComponentModel.DataAnnotations;

namespace SubtitlesManagementSystem.WebModels.Countries.BindingModels
{
    public class CreateCountryBindingModel
    {
        [Required]
        [StringLength(20, MinimumLength = 2,
            ErrorMessage = "The country name cannot be shorter than 2 symbols and longer than 20 symbols")]
        public string Name { get; set; }
    }
}
