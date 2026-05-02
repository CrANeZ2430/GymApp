using CommunityToolkit.Maui.Views;
using GymApp.Visual.ViewModels.WorkoutLogs;

namespace GymApp.Visual.Views;

public partial class AddWorkoutLogPopup : Popup
{
    public AddWorkoutLogPopup(AddWorkoutLogViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}