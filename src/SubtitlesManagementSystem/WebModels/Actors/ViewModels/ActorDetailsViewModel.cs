using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SubtitlesManagementSystem.WebModels.Actors.ViewModels
{
    public class ActorDetailsViewModel
    {
        public string Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Modified On")]
        [DisplayFormat(NullDisplayText = "Not yet modified")]
        public DateTime? ModifiedOn { get; set; }
    }
}
