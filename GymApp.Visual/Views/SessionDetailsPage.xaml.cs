using GymApp.Visual.ViewModels;

namespace GymApp.Visual.Views;

public partial class SessionDetailsPage : ContentPage
{
    public SessionDetailsPage(SessionDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    //private void ShowWLPopup(object sender, EventArgs e)
    //{
    //    this.ShowPopup(new AddWorkoutLogPopup());
    //}
}