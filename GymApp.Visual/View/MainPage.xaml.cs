using GymApp.Visual.ViewModels;

namespace GymApp.Visual.View;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}