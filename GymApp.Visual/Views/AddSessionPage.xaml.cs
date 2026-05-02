using GymApp.Visual.ViewModels.Sessions;

namespace GymApp.Visual.Views;

public partial class AddSessionPage : ContentPage
{
    public AddSessionPage(AddSessionViewModel viewmodel)
    {
        InitializeComponent();
        BindingContext = viewmodel;
    }
}