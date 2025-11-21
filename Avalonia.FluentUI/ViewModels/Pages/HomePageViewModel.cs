using CommunityToolkit.Mvvm.Input;

namespace Avalonia.FluentUI.ViewModels.Pages;

public partial class HomePageViewModel : ObservableObject
{
    private int _i;

    [ObservableProperty] private string _countButtonText = "Count";

    [RelayCommand]
    private void Count()
    {
        _i++;
        CountButtonText = _i == 1 ? "Clicked 1 time." : $"Clicked {_i} times.";
    }
}