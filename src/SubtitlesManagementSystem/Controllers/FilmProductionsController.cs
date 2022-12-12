using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Host;
using Microsoft.EntityFrameworkCore;
using SubtitlesManagementSystem.Business.Services.Countries;
using SubtitlesManagementSystem.Business.Services.FilmProductions;
using SubtitlesManagementSystem.Business.Transactions.Interfaces;
using SubtitlesManagementSystem.Data;
using SubtitlesManagementSystem.Models.Entities;
using SubtitlesManagementSystem.WebModels.FilmProductions.BindingModels;
using SubtitlesManagementSystem.WebModels.FilmProductions.ViewModels;

namespace SubtitlesManagementSystem.Controllers
{
    public class FilmProductionsController : BaseController
    {
        private readonly IFilmProductionService _filmProductionService;

        private readonly ICountryService _countryService;

        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger _logger;

        private readonly ApplicationDbContext _context;

        public FilmProductionsController(
            IFilmProductionService filmProductionService,
            ICountryService countryService,
            IUnitOfWork unitOfWork,
            ILogger<FilmProductionsController> logger,
            ApplicationDbContext context
        )
        {
            _filmProductionService = filmProductionService;
            _countryService = countryService;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _context = context;
        }

        // GET: FilmProductions
        public IActionResult Index()
        {
            IEnumerable<AllFilmProductionsViewModel> allFilmProductionsViewModel = _filmProductionService
                .GetAllFilmProductions();

            return View(allFilmProductionsViewModel);
        }

        // GET: FilmProductions/Details/5
        public IActionResult Details(string id)
        {
            FilmProductionFullDetailsViewModel filmProductionFullDetailsViewModel = _filmProductionService
                    .GetFilmProductionDetails(id);

            if (filmProductionFullDetailsViewModel == null)
            {
                return NotFound();
            }

            return View(filmProductionFullDetailsViewModel);
        }

        // GET: FilmProductions/Create
        public IActionResult Create()
        {
            var allCountriesForSelectList = _countryService.GetAllCountries();

            ViewData["CountryByName"] = new SelectList(allCountriesForSelectList, "Id", "Name");

            return View();
        }

        // POST: FilmProductions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateFilmProductionBindingModel createFilmProductionBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createFilmProductionBindingModel);
            }

            _filmProductionService.CreateFilmProduction(createFilmProductionBindingModel);

            bool isNewFilmProductionSavedToDatabase = _unitOfWork.CommitSaveChanges();

            if (!isNewFilmProductionSavedToDatabase)
            {
                var allCountriesForSelectList = _countryService.GetAllCountries();

                ViewData["CountryByName"] = new SelectList(
                            allCountriesForSelectList, "Id", "Name",
                            createFilmProductionBindingModel.CountryId
                        );

                TempData["FilmProductionErrorMessage"] = $"Error, couldn't save the new film production" +
                    $"{createFilmProductionBindingModel.Title}!";

                return View(createFilmProductionBindingModel);
            }

            TempData["FilmProductionSuccessMessage"] = $"Film Production " +
                    $"{createFilmProductionBindingModel.Title} " +
                $"created successfully!";

            return RedirectToIndexActionInCurrentController();
        }

        // GET: FilmProductions/Edit/5
        public IActionResult Edit(string id)
        {
            EditFilmProductionBindingModel editFilmProductionBindingModel = _filmProductionService
                    .GetFilmProductionEditingDetails(id);

            if (editFilmProductionBindingModel == null)
            {
                return NotFound();
            }

            var allCountriesForSelectList = _countryService.GetAllCountries();

            ViewData["CountryByName"] = new SelectList(
                    allCountriesForSelectList, "Id", "Name",
                    editFilmProductionBindingModel.CountryId
                );

            return View(editFilmProductionBindingModel);
        }

        // POST: FilmProductions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditFilmProductionBindingModel editFilmProductionBindingModel)
        {
            var allCountriesForSelectList = _countryService.GetAllCountries();

            if (!ModelState.IsValid)
            {
                ViewData["CountryByName"] = new SelectList(
                        allCountriesForSelectList, "Id", "Name",
                        editFilmProductionBindingModel.CountryId
                    );

                return View(editFilmProductionBindingModel);
            }

            _filmProductionService.EditFilmProduction(editFilmProductionBindingModel);

            bool isCurrentFilmProductionSavedToDatabase = _unitOfWork.CommitSaveChanges();

            if (!isCurrentFilmProductionSavedToDatabase)
            {
                ViewData["CountryByName"] = new SelectList(
                        allCountriesForSelectList, "Id", "Name",
                        editFilmProductionBindingModel.CountryId
                    );

                TempData["FilmProductionErrorMessage"] = $"Error, couldn't save " +
                    $"the current film production update!";

                return View(editFilmProductionBindingModel);
            }

            TempData["FilmProductionSuccessMessage"] = $"Film Production " +
                $"{editFilmProductionBindingModel.Title} saved successfully!";

            return RedirectToIndexActionInCurrentController();
        }

        // GET: FilmProductions/Delete/5
        public IActionResult Delete(string id)
        {
            DeleteFilmProductionViewModel deleteFilmProductionViewModel = _filmProductionService
                    .GetFilmProductionDeletionDetails(id);

            if (deleteFilmProductionViewModel == null)
            {
                return NotFound();
            }

            return View(deleteFilmProductionViewModel);
        }

        // POST: FilmProductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDeletion(string id)
        {
            var filmProductionToConfirmDeletion = _filmProductionService.FindFilmProduction(id);

            _filmProductionService.DeleteFilmProduction(filmProductionToConfirmDeletion.Id);

            bool isFilmProductionDeleted = _unitOfWork.CommitSaveChanges();

            if (!isFilmProductionDeleted)
            {
                TempData["FilmProductionErrorMessage"] = $"Error, couldn't delete the film production " +
                     $"{filmProductionToConfirmDeletion.Title}! Check the " +
                         $"film production relationship status!";

                return RedirectToAction(nameof(Delete));
            }

            TempData["FilmProductionSuccessMessage"] = $"Film Production {filmProductionToConfirmDeletion.Title} " +
                $"deleted successfully!";

            return RedirectToAction(nameof(Index));
        }
    }
}
