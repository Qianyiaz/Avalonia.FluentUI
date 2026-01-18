using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.FluentUI.ViewModels.Pages;

public partial class HomePageViewModel : ObservableObject
{
    [ObservableProperty] private string _countButtonText = "Count";
    private int _i;

    [RelayCommand]
    private void Count()
    {
        _i++;
        CountButtonText = _i == 1 ? "Clicked 1 time." : $"Clicked {_i} times.";
    }
}