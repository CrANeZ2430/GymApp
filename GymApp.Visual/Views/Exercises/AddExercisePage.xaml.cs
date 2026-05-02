using GymApp.Visual.ViewModels.Exercises;

namespace GymApp.Visual.Views.Exercises;

public partial class AddExercisePage : ContentPage
{
    public AddExercisePage(AddExerciseViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}