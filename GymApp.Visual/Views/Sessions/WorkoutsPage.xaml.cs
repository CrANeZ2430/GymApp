using GymApp.Visual.ViewModels.Sessions;

namespace GymApp.Visual.Views.Sessions;

public partial class WorkoutsPage : ContentPage
{
    public WorkoutsPage(WorkoutsViewModel viewmodel)
    {
        InitializeComponent();
        BindingContext = viewmodel;
    }
}