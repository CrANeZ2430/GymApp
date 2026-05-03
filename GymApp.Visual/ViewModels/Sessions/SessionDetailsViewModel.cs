using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GymApp.Shared.Dtos;
using GymApp.Visual.Services.Exercises;
using GymApp.Visual.ViewModels.Common;
using GymApp.Visual.ViewModels.WorkoutLogs;
using GymApp.Visual.Views.WorkoutLogs;
using Microsoft.Maui.Controls.Shapes;
using System.Collections.ObjectModel;

namespace GymApp.Visual.ViewModels.Sessions;

//"Session" should be the same as in the WorkoutsViewModel in GoToSessionDetailsPageAsync method
[QueryProperty(nameof(Session), "Session")]
public partial class SessionDetailsViewModel : BaseViewModel
{
    private IExercisesService _service;
    private AddWorkoutLogViewModel _popupViewModel;
    [ObservableProperty]
    private SessionDto? _session;
    public ObservableCollection<ExerciseDto> Exercises { get; private set; } = new();

    public SessionDetailsViewModel(IExercisesService service, AddWorkoutLogViewModel popupViewModel)
    {
        _service = service;
        _popupViewModel = popupViewModel;
    }

    [RelayCommand]
    private async Task GetExercisesAsync(CancellationToken ct = default)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var exercises = await _service.GetAsync(ct);

            foreach (var exercise in exercises)
            {
                if (!Exercises.Any(e => e.ExerciseId == exercise.ExerciseId))
                    Exercises.Add(exercise);
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
    private async Task ShowAddWorkoutLogPopupAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await Shell.Current.CurrentPage.ShowPopupAsync(
                new AddWorkoutLogPopup(_popupViewModel), new PopupOptions
                {
                    Shape = null
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
