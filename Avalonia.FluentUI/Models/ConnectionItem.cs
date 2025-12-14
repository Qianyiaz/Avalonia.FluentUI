namespace Avalonia.FluentUI.Models;

public partial class ConnectionItem : ObservableObject
{
    [ObservableProperty] private bool _isChecked;
    [ObservableProperty] private string _name = string.Empty;

    partial void OnIsCheckedChanged(bool value) =>
        Name = value ? $"{Name} (Connected)" : Name.Replace(" (Connected)", string.Empty);
}