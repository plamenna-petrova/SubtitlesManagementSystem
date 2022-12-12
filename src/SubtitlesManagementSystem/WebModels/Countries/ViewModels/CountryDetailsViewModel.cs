using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SubtitlesManagementSystem.WebModels.Countries.ViewModels
{
    public class CountryDetailsViewModel
    {
        public string Name { get; set; }

        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Modified On")]
        [DisplayFormat(NullDisplayText = "Not yet modified")]
        public DateTime? ModifiedOn { get; set; }
    }
}
