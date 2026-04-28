using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GymApp.Shared.Models.Sessions.Dtos;
using GymApp.Visual.Services;

namespace GymApp.Visual.ViewModels;

public partial class AddSessionViewModel : BaseViewModel
{
    private GymAppService _service;
    private Guid _userId = new Guid("02d59402-af23-45a2-9939-516849a766cb");
    [ObservableProperty]
    private string _name;
    [ObservableProperty]
    private DateTime _date;
    [ObservableProperty]
    private string _note;
    [ObservableProperty]
    private bool _isDefault;

    public AddSessionViewModel(GymAppService service)
    {
        Title = "Add Session";
        _service = service;
    }

    [RelayCommand]
    private async Task AddSessionAsync(CancellationToken ct = default)
    {
        try
        {
            var dto = new CreateSessionDto(_userId, Name, Date, Note, IsDefault);
            await _service.CreateSessionAsync(dto, ct);
        }
        catch (Exception ex)
        {
            await DisplayAlert(ex);
        }
    }
}
