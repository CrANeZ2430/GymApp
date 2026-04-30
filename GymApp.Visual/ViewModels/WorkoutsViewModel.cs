using CommunityToolkit.Mvvm.Input;
using GymApp.Shared.Dtos;
using GymApp.Visual.Services.Sessions;
using GymApp.Visual.View;
using System.Collections.ObjectModel;

namespace GymApp.Visual.ViewModels;

public partial class WorkoutsViewModel : BaseViewModel
{
    private ISessionsService _service;
    public ObservableCollection<SessionDto> Sessions { get; private set; } = new();

    public WorkoutsViewModel(ISessionsService service)
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
            await DisplayAlertAsync(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task GoToAddSessionPageAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await Shell.Current.GoToAsync(nameof(AddSessionPage), true);
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task GoToSessionDetailsPageAsync(SessionDto session)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await Shell.Current.GoToAsync(nameof(SessionDetailsPage), true,
                new Dictionary<string, object>
                {
                    { "Session", session }
                });
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
