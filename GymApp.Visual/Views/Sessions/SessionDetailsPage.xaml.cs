using GymApp.Visual.ViewModels.Sessions;

namespace GymApp.Visual.Views.Sessions;

public partial class SessionDetailsPage : ContentPage
{
    public SessionDetailsPage(SessionDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}