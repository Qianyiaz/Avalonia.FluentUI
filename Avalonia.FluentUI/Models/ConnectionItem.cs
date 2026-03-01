using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.FluentUI.Models;

public partial class ConnectionItem : ObservableObject
{
    [ObservableProperty] private bool _isChecked;
    [ObservableProperty] private string _name = string.Empty;
}