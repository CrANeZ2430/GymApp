using GymApp.Visual.ViewModels;

namespace GymApp.Visual.Views;

public partial class AddSessionPage : ContentPage
{
    public AddSessionPage(AddSessionViewModel viewmodel)
    {
        InitializeComponent();
        BindingContext = viewmodel;
    }
}