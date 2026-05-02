using GymApp.Visual.ViewModels.Exercises;

namespace GymApp.Visual.Views;

public partial class AddExercisePage : ContentPage
{
    public AddExercisePage(AddExerciseViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}