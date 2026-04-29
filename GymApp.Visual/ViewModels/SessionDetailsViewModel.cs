using CommunityToolkit.Mvvm.ComponentModel;
using GymApp.Shared.Dtos;
using GymApp.Visual.Services;

namespace GymApp.Visual.ViewModels;

//"Session" should be the same as in the WorkoutsViewModel in GoToSessionDetailsPageAsync method
[QueryProperty(nameof(Session), "Session")]
public partial class SessionDetailsViewModel : BaseViewModel
{
    private GymAppService _service;
    [ObservableProperty]
    private SessionDto _session;

    public SessionDetailsViewModel(GymAppService service)
    {
        _service = service;
    }
}
