using CommunityToolkit.Mvvm.ComponentModel;

namespace GymApp.Visual.Common;

public partial class FlagOption : ObservableObject
{
    [ObservableProperty]
    private bool _isSelected;
    public string Name { get; set; }
    public Enum Value { get; set; }
}
