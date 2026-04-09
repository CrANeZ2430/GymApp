using CommunityToolkit.Mvvm.ComponentModel;

namespace GymApp.Visual.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    string title;
}
