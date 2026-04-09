using GymApp.Visual.ViewModels;

namespace GymApp.Visual.View;

public partial class MainPage : ContentPage
{
    public MainPage(ExercisesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
