using System;
using System.Diagnostics.CodeAnalysis;
using Avalonia.FluentUI.Views.Pages;
using Avalonia.Interactivity;
using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Windowing;

namespace Avalonia.FluentUI.Views.Windows;

public partial class MainWindow : AppWindow
{
    public MainWindow() =>
        InitializeComponent();

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        RootNavigation.SelectedItem = RootNavigation.MenuItems[0];
    }

    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(HomePage))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(WifiPage))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(SettingsPage))]
    private void OnSelectionChanged(object sender, NavigationViewSelectionChangedEventArgs e)
    {
        if (e.SelectedItem is not NavigationViewItem item) return;

        Frame.Navigate
        (
            item.Content switch
            {
                "Home" => typeof(HomePage),
                "Wifi" => typeof(WifiPage),
                "Settings" => typeof(SettingsPage),
                _ => throw new NotImplementedException()
            }
        );
    }
}