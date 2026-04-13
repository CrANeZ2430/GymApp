using GymApp.Visual.ViewModels;

namespace GymApp.Visual.View;

public partial class ExercisesPage : ContentPage
{
    public ExercisesPage(ExercisesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}