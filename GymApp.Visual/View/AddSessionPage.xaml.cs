using GymApp.Visual.ViewModels;

namespace GymApp.Visual.View;

public partial class AddSessionPage : ContentPage
{
	public AddSessionPage(AddSessionViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}