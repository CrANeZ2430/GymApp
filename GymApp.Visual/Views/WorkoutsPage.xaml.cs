using GymApp.Visual.ViewModels.Sessions;

namespace GymApp.Visual.Views;

public partial class WorkoutsPage : ContentPage
{
    public WorkoutsPage(WorkoutsViewModel viewmodel)
    {
        InitializeComponent();
        BindingContext = viewmodel;
    }
}