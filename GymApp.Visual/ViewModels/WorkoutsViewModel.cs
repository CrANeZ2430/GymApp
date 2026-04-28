using CommunityToolkit.Mvvm.Input;
using GymApp.Shared.Dtos;
using GymApp.Visual.Services;
using GymApp.Visual.View;
using System.Collections.ObjectModel;

namespace GymApp.Visual.ViewModels;

public partial class WorkoutsViewModel : BaseViewModel
{
    private GymAppService _service;
    public ObservableCollection<SessionDto> Sessions { get; private set; } = new();

    public WorkoutsViewModel(GymAppService service)
    {
        Title = "Workouts";
        _service = service;
    }

    [RelayCommand]
    private async Task GetSessionsAsync(CancellationToken ct = default)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var sessions = await _service.GetSessionsAsync(ct);

            foreach(var session in sessions)
            {
                if (!Sessions.Any(s => s.SessionId == session.SessionId))
                    Sessions.Add(session);
            }
            
        }
        catch (Exception ex)
        {
            await DisplayAlert(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task GoToAddSessionPageAsync()
    {
        try
        {
            await Shell.Current.GoToAsync(nameof(AddSessionPage), true);
        }
        catch (Exception ex)
        {
            await DisplayAlert(ex);
        }
    }
}
