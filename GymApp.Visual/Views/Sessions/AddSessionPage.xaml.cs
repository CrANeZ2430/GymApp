using GymApp.Visual.ViewModels.Sessions;

namespace GymApp.Visual.Views.Sessions;

public partial class AddSessionPage : ContentPage
{
    public AddSessionPage(AddSessionViewModel viewmodel)
    {
        InitializeComponent();
        BindingContext = viewmodel;
    }
}