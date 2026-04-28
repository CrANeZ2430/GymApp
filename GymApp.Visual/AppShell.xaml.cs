using GymApp.Visual.View;

namespace GymApp.Visual;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(ExercisesPage), typeof(ExercisesPage));
        Routing.RegisterRoute(nameof(AddExercisePage), typeof(AddExercisePage));

        Routing.RegisterRoute(nameof(WorkoutsPage), typeof(WorkoutsPage));
        Routing.RegisterRoute(nameof(AddSessionPage), typeof(AddSessionPage));
    }
}
