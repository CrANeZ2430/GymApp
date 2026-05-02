using CommunityToolkit.Maui.Views;
using GymApp.Visual.ViewModels.WorkoutLogs;

namespace GymApp.Visual.Views.WorkoutLogs;

public partial class AddWorkoutLogPopup : Popup
{
    public AddWorkoutLogPopup(AddWorkoutLogViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}