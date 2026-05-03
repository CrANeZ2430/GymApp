using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GymApp.Shared.Models.WorkoutLogs.Dtos;
using GymApp.Visual.Services.WorkoutLogs;
using GymApp.Visual.ViewModels.Common;

namespace GymApp.Visual.ViewModels.WorkoutLogs;

public partial class AddWorkoutLogViewModel : BaseViewModel
{
    private IPopupService _popupService;
    private IWorkoutLogsService _workoutLogsService;

    [ObservableProperty]
    private float _weight;
    [ObservableProperty]
    private int _sets;
    [ObservableProperty]
    private int _reps;
    [ObservableProperty]
    private int _duration;
    [ObservableProperty]
    private int _restTime;

    public Guid SessionId { get; set; }
    public Guid ExerciseId { get; set; }

    public List<string> TrackingTypes { get; } = new() { "Reps", "Duration" };
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsRepsMode))]
    [NotifyPropertyChangedFor(nameof(IsDurationMode))]
    private string _selectedTrackingType = "Reps";

    public bool IsRepsMode => SelectedTrackingType == "Reps";
    public bool IsDurationMode => SelectedTrackingType == "Duration";


    public AddWorkoutLogViewModel(IPopupService popupService, IWorkoutLogsService workoutLogsService)
    {
        Title = "Log exercise";
        _popupService = popupService;
        _workoutLogsService = workoutLogsService;
    }

    [RelayCommand]
    private async Task SaveWorkoutLogAsync(CancellationToken ct = default)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            var dto = new CreateWorkoutLogDto(
                    SessionId, 
                    ExerciseId, 
                    Weight, 
                    Sets, 
                    (Reps == 0) ? null : Reps,
                    (Duration == 0) ? null : Duration,
                    RestTime);
            await _workoutLogsService.CreateAsync(dto, ct);
            await _popupService.ClosePopupAsync(Shell.Current.CurrentPage, ct);
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
    private async Task CloseAddWorkoutLogPopupAsync(CancellationToken ct = default)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await _popupService.ClosePopupAsync(Shell.Current.CurrentPage, ct);
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
