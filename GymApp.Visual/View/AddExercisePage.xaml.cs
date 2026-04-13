using GymApp.Visual.ViewModels;

namespace GymApp.Visual.View;

public partial class AddExercisePage : ContentPage
{
	public AddExercisePage(AddExerciseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}