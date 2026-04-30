using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GymApp.Shared.Dtos;
using GymApp.Visual.Services.Exercises;
using System.Collections.ObjectModel;

namespace GymApp.Visual.ViewModels;

//"Session" should be the same as in the WorkoutsViewModel in GoToSessionDetailsPageAsync method
[QueryProperty(nameof(Session), "Session")]
public partial class SessionDetailsViewModel : BaseViewModel
{
    private IExercisesService _service;
    [ObservableProperty]
    private SessionDto? _session;
    public ObservableCollection<ExerciseDto> Exercises { get; private set; } = new();

    public SessionDetailsViewModel(IExercisesService service)
    {
        _service = service;
    }

    [RelayCommand]
    private async Task GetExercisesAsync(CancellationToken ct = default)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var exercises = await _service.GetExercisesAsync(ct);

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
}
