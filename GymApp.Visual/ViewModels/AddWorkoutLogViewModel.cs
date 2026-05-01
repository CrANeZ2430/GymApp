using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.Input;

namespace GymApp.Visual.ViewModels;

public partial class AddWorkoutLogViewModel(IPopupService popupService) : BaseViewModel
{
    [RelayCommand]
    private async Task CloseAddWorkoutLogPopup(CancellationToken ct = default)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            await popupService.ClosePopupAsync(Shell.Current.CurrentPage, ct);
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
