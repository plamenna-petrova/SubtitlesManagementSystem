using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SubtitlesManagementSystem.WebModels.Actors.BindingModels
{
    public class CreateActorBindingModel
    {
        [Required]
        [StringLength(25, MinimumLength = 2,
            ErrorMessage = "The first name cannot be less than 2 symbols and more 25 in length")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2,
            ErrorMessage = "The last name cannot be less than 2 symbols and more 25 in length")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
    }
}
