using CommunityToolkit.Mvvm.Input;
using GymApp.Shared.Dtos;
using GymApp.Visual.Services.Exercises;
using GymApp.Visual.View;
using System.Collections.ObjectModel;

namespace GymApp.Visual.ViewModels;

public partial class ExercisesViewModel : BaseViewModel
{
    private IExercisesService _service;
    public ObservableCollection<ExerciseDto> Exercises { get; private set; } = new();

    public ExercisesViewModel(IExercisesService service)
    {
        _service = service;
        Title = "Exercises";
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

    [RelayCommand]
    private async Task GoToAddExercisePageAsync()
    {
        if (IsBusy)
            return;

        try 
        {
            IsBusy = true;
            await Shell.Current.GoToAsync(nameof(AddExercisePage), true); 
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
