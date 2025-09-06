using System.Diagnostics.CodeAnalysis;
using Avalonia.Controls;
using Avalonia.Interactivity;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Windowing;

#pragma warning disable CS8509

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

        Frame.Navigate
        (
            item.Content switch
            {
                "Home" => typeof(HomePage),
                "Settings" => typeof(SettingsPage)
            },
            item.Content switch
            {
                "Home" => _homePage,
                "Settings" => _settingsPage
            }
        );
    }
}