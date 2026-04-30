using CommunityToolkit.Mvvm.ComponentModel;
using GymApp.Shared.Dtos;
using GymApp.Visual.Services.Exercises;

namespace GymApp.Visual.ViewModels;

//"Session" should be the same as in the WorkoutsViewModel in GoToSessionDetailsPageAsync method
[QueryProperty(nameof(Session), "Session")]
public partial class SessionDetailsViewModel : BaseViewModel
{
    private IExercisesService _service;
    [ObservableProperty]
    private SessionDto _session;

    public SessionDetailsViewModel(IExercisesService service)
    {
        _service = service;
    }
}
