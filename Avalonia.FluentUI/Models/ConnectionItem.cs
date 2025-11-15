namespace Avalonia.FluentUI.Models;

public partial class ConnectionItem : ObservableObject
{
    [ObservableProperty] private string _name;

    [ObservableProperty] private bool _isChecked;

    partial void OnIsCheckedChanged(bool value)
    {
        Name = value ? $"{Name} (Connected)" : Name.Replace(" (Connected)", string.Empty);
    }
}