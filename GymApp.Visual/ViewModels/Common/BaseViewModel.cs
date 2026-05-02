using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;

namespace GymApp.Visual.ViewModels.Common;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isBusy;
    [ObservableProperty]
    private string _title;

    protected async Task DisplayAlertAsync(Exception ex)
    {
        Debug.WriteLine(ex);
        await Shell.Current.DisplayAlertAsync("Error!", $"{ex.Message}", "OK");
    }
}
