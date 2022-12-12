using SubtitlesManagementSystem.Models.Entities;
using SubtitlesManagementSystem.WebModels.Countries.BindingModels;
using SubtitlesManagementSystem.WebModels.Countries.ViewModels;

namespace SubtitlesManagementSystem.Business.Services.Countries
{
    public interface ICountryService
    {
        IEnumerable<AllCountriesViewModel> GetAllCountries();

        CountryDetailsViewModel GetCountryDetails(string countryId);

        bool CreateCountry(CreateCountryBindingModel createCountryBindingModel);

        EditCountryBindingModel GetCountryEditingDetails(string countryId);

        bool EditCountry(EditCountryBindingModel editCountryBindingModel);

        DeleteCountryViewModel GetCountryDeletionDetails(string countryId);

        void DeleteCountry(string countryId);

        Country FindCountry(string countryId);
    }
}
