using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SubtitlesManagementSystem.WebModels.Countries.ViewModels
{
    public class AllCountriesViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Modified On")]
        [DisplayFormat(NullDisplayText = "Not Yet Modified")]
        public DateTime? ModifiedOn { get; set; }
    }
}
