using static ChmlFrp.SDK.Results.UserResult;

namespace Avalonia.FluentUI.ViewModels.Pages;

public partial class HomePageViewModel : ObservableObject
{
    [ObservableProperty] private string _content = "Click Me.";

    private int _i;

    public async Task Count()
    {
        _i++;
        var user = await AutoLogin();
        if (user.State)
            Content = _i == 1 ? $"Clicked 1 time {user.Data.Username}." : $"Clicked {_i} times {user.Data.Username}.";
    }
}