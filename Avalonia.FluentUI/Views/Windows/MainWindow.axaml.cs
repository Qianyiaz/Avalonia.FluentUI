using System.Diagnostics.CodeAnalysis;
using Avalonia.FluentUI.Views.Pages;
using FluentAvalonia.UI.Controls;

namespace Avalonia.FluentUI.Views.Windows;

public partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();

    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        RootNavigation.SelectedItem = RootNavigation.MenuItems[0];
    }

    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(HomePage))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(LoginPage))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(ListBoxPage))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(TextBoxPage))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(SettingsPage))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(RadioButtonPage))]
    private void OnSelectionChanged(object sender, NavigationViewSelectionChangedEventArgs e)
    {
        if (e.SelectedItem is not NavigationViewItem item) return;

        Frame.Navigate
        (
            item.Content switch
            {
                "Home" => typeof(HomePage),
                "Login" => typeof(LoginPage),
                "ListBox" => typeof(ListBoxPage),
                "TextBox" => typeof(TextBoxPage),
                "Settings" => typeof(SettingsPage),
                "RadioButton" => typeof(RadioButtonPage),
                _ => throw new NotImplementedException()
            }
        );
    }
}