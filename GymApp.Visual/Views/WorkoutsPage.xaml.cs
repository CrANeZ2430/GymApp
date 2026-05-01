using GymApp.Visual.ViewModels;

namespace GymApp.Visual.Views;

public partial class WorkoutsPage : ContentPage
{
    public WorkoutsPage(WorkoutsViewModel viewmodel)
    {
        InitializeComponent();
        BindingContext = viewmodel;
    }
}