using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.FluentUI.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    [ObservableProperty] private string _content = "Click Me.";

    private int _i;

    public void Count()
    {
        _i++;
        if (_i == 1)
        {
            Content = "Clicked 1 time.";
            return;
        }

        Content = $"Clicked {_i} times.";
    }
}