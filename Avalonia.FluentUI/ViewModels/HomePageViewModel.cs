using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.FluentUI.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    [ObservableProperty] private string _content = "Click 1 time.";

    private int _i = 1;

    public void Count()
    {
        _i++;
        Content = $"Click {_i} times.";
    }
}