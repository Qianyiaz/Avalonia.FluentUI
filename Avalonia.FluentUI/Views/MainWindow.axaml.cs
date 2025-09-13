using System.Diagnostics.CodeAnalysis;
using Avalonia.Controls;
using Avalonia.Interactivity;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Windowing;

namespace Avalonia.FluentUI.Views;

public partial class MainWindow : AppWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        if (IsWindows11)
        {
            TransparencyLevelHint = [WindowTransparencyLevel.Mica];
        }
        else if (IsWindows)
        {
            TransparencyLevelHint = [WindowTransparencyLevel.AcrylicBlur];
        }
        RootNavigation.SelectedItem = RootNavigation.MenuItems[0];
    }

    private readonly HomePage _homePage = new();
    private readonly SettingsPage _settingsPage = new();

    [DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(HomePage))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.All, typeof(SettingsPage))]
    private void OnSelectionChanged(object sender, NavigationViewSelectionChangedEventArgs e)
    {
        if (e.SelectedItem is not NavigationViewItem item) return;
        switch (item.Tag)
        {
            case "home":
                Frame.Navigate(typeof(HomePage), _homePage);
                break;
            case "settings":
                Frame.Navigate(typeof(SettingsPage), _settingsPage);
                break;
        }
    }
}