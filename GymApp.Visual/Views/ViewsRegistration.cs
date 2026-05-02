using GymApp.Visual.Views.Main;
using GymApp.Visual.Views.Exercises;
using GymApp.Visual.Views.Sessions;
using GymApp.Visual.Views.WorkoutLogs;

namespace GymApp.Visual.Views;

public static class ViewsRegistration
{
    public static void RegisterViews(this IServiceCollection services)
    {
        services.AddSingleton<MainPage>();
        services.AddTransient<ExercisesPage>();
        services.AddTransient<AddExercisePage>();
        services.AddTransient<WorkoutsPage>();
        services.AddTransient<AddSessionPage>();
        services.AddTransient<SessionDetailsPage>();
        services.AddTransient<AddWorkoutLogPopup>();
    }
}
