using SubtitlesManagementSystem.Models.Entities;
using SubtitlesManagementSystem.WebModels.FilmProductions.BindingModels;
using SubtitlesManagementSystem.WebModels.FilmProductions.ViewModels;

namespace SubtitlesManagementSystem.Business.Services.FilmProductions
{
    public interface IFilmProductionService
    {
        IEnumerable<AllFilmProductionsViewModel> GetAllFilmProductions();

        FilmProductionFullDetailsViewModel GetFilmProductionDetails(string filmProductionId);

        void CreateFilmProduction(CreateFilmProductionBindingModel createFilmProductionBindingModel);

        EditFilmProductionBindingModel GetFilmProductionEditingDetails(string filmProductionId);

        void EditFilmProduction(EditFilmProductionBindingModel editFilmProductionBindingModel);

        DeleteFilmProductionViewModel GetFilmProductionDeletionDetails(string filmProductionId);

        void DeleteFilmProduction(string filmProductionId);

        FilmProduction FindFilmProduction(string filmProductionId);
    }
}
