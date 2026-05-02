using GymApp.Visual.ViewModels.Exercises;

namespace GymApp.Visual.Views;

public partial class ExercisesPage : ContentPage
{
    public ExercisesPage(ExercisesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}