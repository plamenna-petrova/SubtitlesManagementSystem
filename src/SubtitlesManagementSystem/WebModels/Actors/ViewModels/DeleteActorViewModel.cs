using System.ComponentModel;

namespace SubtitlesManagementSystem.WebModels.Actors.ViewModels
{
    public class DeleteActorViewModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
    }
}
