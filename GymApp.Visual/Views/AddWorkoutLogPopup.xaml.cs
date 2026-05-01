using CommunityToolkit.Maui.Views;
using GymApp.Visual.ViewModels;

namespace GymApp.Visual.Views;

public partial class AddWorkoutLogPopup : Popup
{
    public AddWorkoutLogPopup(AddWorkoutLogViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}