using GymApp.Visual.ViewModels.Main;

namespace GymApp.Visual.Views.Main;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}