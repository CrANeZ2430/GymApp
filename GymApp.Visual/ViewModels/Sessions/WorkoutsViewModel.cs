using CommunityToolkit.Mvvm.Input;
using GymApp.Shared.Dtos;
using GymApp.Visual.Services.Sessions;
using GymApp.Visual.Services.WorkoutLogs;
using GymApp.Visual.ViewModels.Common;
using GymApp.Visual.Views.Sessions;
using System.Collections.ObjectModel;

namespace GymApp.Visual.ViewModels.Sessions;

public partial class WorkoutsViewModel : BaseViewModel
{
    private ISessionsService _sessionsService;
    private IWorkoutLogsService _workoutLogsService;
    public ObservableCollection<SessionDto> Sessions { get; private set; } = new();

    public WorkoutsViewModel(ISessionsService SessionsService, IWorkoutLogsService workoutLogsService)
    {
        Title = "Workouts";
        _sessionsService = SessionsService;
        _workoutLogsService = workoutLogsService;
    }

    [RelayCommand]
    private async Task GetSessionsAsync(CancellationToken ct = default)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var sessions = await _sessionsService.GetAsync(ct);

            foreach (var session in sessions)
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
            var workoutLogs = await _workoutLogsService.GetFromSessionByIdAsync(session.SessionId);
            await Shell.Current.GoToAsync(nameof(SessionDetailsPage), true,
                new Dictionary<string, object?>
                {
                    { "Session", session },
                    { "WorkoutLogs",  new ObservableCollection<WorkoutLogDto>(workoutLogs)}
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
