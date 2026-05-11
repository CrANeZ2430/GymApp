using GymApp.Visual.ViewModels.Exercises;
using GymApp.Visual.ViewModels.Main;
using GymApp.Visual.ViewModels.Sessions;
using GymApp.Visual.ViewModels.WorkoutLogs;

namespace GymApp.Visual.ViewModels;

public static class ViewModelsRegistration
{
    public static void RegisterViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<ExercisesViewModel>();
        services.AddSingleton<WorkoutsViewModel>();

        services.AddTransient<AddExerciseViewModel>();
        services.AddTransient<AddSessionViewModel>();
        services.AddTransient<SessionDetailsViewModel>();
        services.AddTransient<AddWorkoutLogViewModel>();
    }
}
