using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GymApp.Shared.Models.Exercises.Models;

namespace GymApp.Visual.ViewModels;

public partial class AddExerciseViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _exTitle;
    [ObservableProperty]
    private Equipment _equipment;
    [ObservableProperty]
    private MuscleGroups _muscleGroups;

    public AddExerciseViewModel()
    {
        Title = "Add Exercise";
    }

    [RelayCommand]
    private async Task AddExerciseAsync()
    {
        var d = ExTitle;
        var a = Equipment;
    }
}
