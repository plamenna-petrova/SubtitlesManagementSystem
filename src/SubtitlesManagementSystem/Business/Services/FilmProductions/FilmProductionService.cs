using Microsoft.EntityFrameworkCore;
using SubtitlesManagementSystem.Data.Repositories.Interfaces;
using SubtitlesManagementSystem.Models.Entities;
using SubtitlesManagementSystem.WebModels.Countries.ViewModels;
using SubtitlesManagementSystem.WebModels.FilmProductions.BindingModels;
using SubtitlesManagementSystem.WebModels.FilmProductions.ViewModels;

namespace SubtitlesManagementSystem.Business.Services.FilmProductions
{
    public class FilmProductionService: IFilmProductionService
    {
        private readonly IFilmProductionRepository _filmProductionRepository;

        public FilmProductionService(IFilmProductionRepository filmProductionRepository)
        {
            _filmProductionRepository = filmProductionRepository;
        }

        public IEnumerable<AllFilmProductionsViewModel> GetAllFilmProductions()
        {
            List<AllFilmProductionsViewModel> allFilmProductions = _filmProductionRepository
                .GetAllAsNoTracking()
                    .Select(fp => new AllFilmProductionsViewModel
                    {
                        Id = fp.Id,
                        Title = fp.Title,
                        Duration = fp.Duration,
                        ReleaseDate = fp.ReleaseDate,
                        RelatedCountry = new CountryConciseInformationViewModel
                        {
                            Name = fp.Country.Name
                        }
                    })
                    .ToList();

            return allFilmProductions;
        }

        public FilmProductionFullDetailsViewModel GetFilmProductionDetails(string filmProductionId)
        {
            var singleFilmProduction = _filmProductionRepository
                    .GetAllByCondition(fp => fp.Id == filmProductionId)
                        .Include(fp => fp.Country)
                            .FirstOrDefault();

            if (singleFilmProduction is null)
            {
                return null;
            }

            var singleFilmProductionDetails = new FilmProductionFullDetailsViewModel
            {
                Id = singleFilmProduction.Id,
                Title = singleFilmProduction.Title,
                Duration = singleFilmProduction.Duration,
                ReleaseDate = singleFilmProduction.ReleaseDate,
                PlotSummary = singleFilmProduction.PlotSummary,
                CountryName = singleFilmProduction.Country.Name,
            };

            return singleFilmProductionDetails;
        }

        public void CreateFilmProduction(CreateFilmProductionBindingModel createFilmProductionBindingModel)
        {
            FilmProduction filmProductionToCreate = new FilmProduction
            {
                Title = createFilmProductionBindingModel.Title,
                Duration = createFilmProductionBindingModel.Duration,
                ReleaseDate = createFilmProductionBindingModel.ReleaseDate,
                PlotSummary = createFilmProductionBindingModel.PlotSummary,
                CountryId = createFilmProductionBindingModel.CountryId
            };

            _filmProductionRepository.Add(filmProductionToCreate);
        }

        public EditFilmProductionBindingModel GetFilmProductionEditingDetails(string filmProductionId)
        {
            var filmProductionToEdit = FindFilmProduction(filmProductionId);

            if (filmProductionToEdit is null)
            {
                return null;
            }

            var filmProductionToEditDetails = new EditFilmProductionBindingModel
            {
                Id = filmProductionToEdit.Id,
                Title = filmProductionToEdit.Title,
                Duration = filmProductionToEdit.Duration,
                ReleaseDate = filmProductionToEdit.ReleaseDate,
                PlotSummary = filmProductionToEdit.PlotSummary,
                CountryId = filmProductionToEdit.CountryId
            };

            return filmProductionToEditDetails;
        }

        public void EditFilmProduction(EditFilmProductionBindingModel editFilmProductionBindingModel)
        {
            var filmProductionToUpdate = FindFilmProduction(editFilmProductionBindingModel.Id);

            filmProductionToUpdate.Title = editFilmProductionBindingModel.Title;
            filmProductionToUpdate.Duration = editFilmProductionBindingModel.Duration;
            filmProductionToUpdate.Title = editFilmProductionBindingModel.Title;
            filmProductionToUpdate.Duration = editFilmProductionBindingModel.Duration;
            filmProductionToUpdate.ReleaseDate = editFilmProductionBindingModel.ReleaseDate;
            filmProductionToUpdate.PlotSummary = editFilmProductionBindingModel.PlotSummary;
            filmProductionToUpdate.CountryId = editFilmProductionBindingModel.CountryId;

            _filmProductionRepository.Update(filmProductionToUpdate);
        }

        public DeleteFilmProductionViewModel GetFilmProductionDeletionDetails(string filmProductionId)
        {
            var filmProductionToDelete = FindFilmProduction(filmProductionId);

            if (filmProductionToDelete is null)
            {
                return null;
            }

            var filmProductionToDeleteDetails = new DeleteFilmProductionViewModel
            {
                Title = filmProductionToDelete.Title,
                ReleaseDate = filmProductionToDelete.ReleaseDate
            };

            return filmProductionToDeleteDetails;
        }

        public void DeleteFilmProduction(string filmProductionId)
        {
            _filmProductionRepository.Delete(filmProductionId);
        }

        public FilmProduction FindFilmProduction(string filmProductionId)
        {
            return _filmProductionRepository.GetById(filmProductionId);
        }
    }
}
