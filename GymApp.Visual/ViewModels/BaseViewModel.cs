using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;

namespace GymApp.Visual.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private string title;

    protected async Task DisplayAlert(Exception ex)
    {
        Debug.WriteLine(ex);
        await Shell.Current.DisplayAlertAsync("Error!", $"{ex.Message}", "OK");
    }
}
