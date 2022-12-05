using SubtitlesManagementSystem.Models.Entities;
using SubtitlesManagementSystem.WebModels.Actors.BindingModels;
using SubtitlesManagementSystem.WebModels.Actors.ViewModels;

namespace SubtitlesManagementSystem.Business.Services.Actors
{
    public interface IActorService
    {
        IEnumerable<AllActorsViewModel> GetAllActors();

        ActorDetailsViewModel GetActorDetails(string actorId);

        bool CreateActor(CreateActorBindingModel createActorBindingModel);

        EditActorBindingModel GetActorEditingDetails(string actorId);

        bool EditActor(EditActorBindingModel editActorBindingModel);

        DeleteActorViewModel GetActorDeletionDetails(string actorId);

        void DeleteActor(string actorId);

        Actor FindActor(string actorId);
    }
}
