using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GymApp.Shared.Models.Sessions.Dtos;
using GymApp.Visual.Services.Sessions;

namespace GymApp.Visual.ViewModels;

public partial class AddSessionViewModel : BaseViewModel
{
    private ISessionsService _service;
    private Guid _userId = new Guid("02d59402-af23-45a2-9939-516849a766cb");
    [ObservableProperty]
    private string _name;
    [ObservableProperty]
    private DateTime _date;
    [ObservableProperty]
    private string _note;
    [ObservableProperty]
    private bool _isDefault;

    public AddSessionViewModel(ISessionsService service)
    {
        Title = "Add Session";
        _service = service;
    }

    [RelayCommand]
    private async Task AddSessionAsync(CancellationToken ct = default)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            var dto = new CreateSessionDto(_userId, Name, Date.ToUniversalTime(), Note, IsDefault);
            await _service.CreateSessionAsync(dto, ct);

            await Shell.Current.DisplayAlertAsync("Success", "Session created successfully!", "OK");
            await Shell.Current.GoToAsync("..", true);
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
