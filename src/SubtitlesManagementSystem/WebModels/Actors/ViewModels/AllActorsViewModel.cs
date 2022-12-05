using System.ComponentModel;

namespace SubtitlesManagementSystem.WebModels.Actors.ViewModels
{
    public class AllActorsViewModel
    {
        public string Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
    }
}
