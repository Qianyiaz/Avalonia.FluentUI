namespace Avalonia.FluentUI.ViewModels.Pages;

public partial class HomePageViewModel : ObservableObject
{
    [ObservableProperty] private string _content = "Click Me.";

    private int _i;

    public void Count()
    {
        _i++;
        Content = _i == 1 ? "Clicked 1 time." : $"Clicked {_i} times.";
    }
}