using CommunityToolkit.Mvvm.Input;

namespace Avalonia.FluentUI.ViewModels.Pages;

public partial class HomePageViewModel
{
    private int _i;

    [RelayCommand]
    private void Count(Button button)
    {
        _i++;
        button.Content = _i == 1 ? "Clicked 1 time." : $"Clicked {_i} times.";
    }
}