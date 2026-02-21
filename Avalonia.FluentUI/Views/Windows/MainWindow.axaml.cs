using System.Diagnostics.CodeAnalysis;
using Avalonia.FluentUI.Views.Pages;
using FluentAvalonia.UI.Controls;

namespace Avalonia.FluentUI.Views.Windows;

[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]
public partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();

    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        RootNavigation.SelectedItem = RootNavigation.MenuItems[0];
    }

    private void OnSelectionChanged(object sender, NavigationViewSelectionChangedEventArgs e)
    {
        if (e.SelectedItem is not NavigationViewItem item) return;

        Frame.Navigate
        (
            item.Content switch
            {
                "Home" => typeof(HomePage),
                "TabView" => typeof(TabViewPage),
                "ListBox" => typeof(ListBoxPage),
                "TextBox" => typeof(TextBoxPage),
                "Settings" => typeof(SettingsPage),
                _ => throw new NotImplementedException()
            }
        );
    }
}