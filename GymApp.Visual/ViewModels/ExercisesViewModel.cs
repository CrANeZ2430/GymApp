using CommunityToolkit.Mvvm.Input;
using GymApp.Shared.Dtos;
using GymApp.Visual.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace GymApp.Visual.ViewModels;

public partial class ExercisesViewModel : BaseViewModel
{
    GymAppService service;

    public ObservableCollection<ExerciseDto> Exercises { get; private set; } = new();

    public ExercisesViewModel(GymAppService service)
    {
        this.service = service;
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
            var exercises = await service.GetExercisesAsync(ct);

            if (Exercises.Any())
                Exercises.Clear();

            foreach (var exercise in exercises)
                Exercises.Add(exercise);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlertAsync("Error!", $"{ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
