using GymApp.Visual.ViewModels;

namespace GymApp.Visual.View;

public partial class SessionDetailsPage : ContentPage
{
	public SessionDetailsPage(SessionDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}