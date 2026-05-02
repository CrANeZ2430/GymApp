using GymApp.Visual.ViewModels.Exercises;

namespace GymApp.Visual.Views.Exercises;

public partial class ExercisesPage : ContentPage
{
    public ExercisesPage(ExercisesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}