using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GymApp.Shared.Models.Exercises.Dtos;
using GymApp.Shared.Models.Exercises.Models;
using GymApp.Visual.Services;
using System.Collections.ObjectModel;

namespace GymApp.Visual.ViewModels;

public partial class AddExerciseViewModel : BaseViewModel
{
    private readonly GymAppService _service;
    [ObservableProperty]
    private string _name;
    [ObservableProperty]
    private Equipment _equipment;
    public ObservableCollection<FlagOption> FlagOptions { get; } = new();

    public AddExerciseViewModel(GymAppService service)
    {
        Title = "Add Exercise";
        _service = service;
        LoadFlags();
    }

    [RelayCommand]
    private async Task AddExerciseAsync(CancellationToken ct = default)
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;

            var dto = new CreateExerciseDto(Name, GetFinalResult(), Equipment);
            await _service.CreateExercise(dto, ct);
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

    private MuscleGroups GetFinalResult()
    {
        long result = 0;
        foreach (var flag in FlagOptions.Where(f => f.IsSelected))
        {
            result |= Convert.ToInt64(flag.Value);
        }
        return (MuscleGroups)result;
    }

    private void LoadFlags()
    {
        var allFlags = Enum.GetValues<MuscleGroups>();

        foreach (var flag in allFlags)
        {
            if (Convert.ToInt64(flag) == 0) continue;

            FlagOptions.Add(new FlagOption
            {
                Name = flag.ToString(),
                Value = flag,
                IsSelected = false
            });
        }
    }
}
