using GymApp.Visual.View;

namespace GymApp.Visual;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AddExercisePage), typeof(AddExercisePage));
    }
}
