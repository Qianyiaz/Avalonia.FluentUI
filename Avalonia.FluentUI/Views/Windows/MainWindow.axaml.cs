using System.Diagnostics.CodeAnalysis;
using Avalonia.FluentUI.Views.Pages;

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
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(ListBoxPage))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(TextBoxsPage))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(SettingsPage))]
    private void OnSelectionChanged(object sender, NavigationViewSelectionChangedEventArgs e)
    {
        if (e.SelectedItem is not NavigationViewItem item) return;
        
        Frame.Navigate
        (
            item.Content switch
            {
                "Home" => typeof(HomePage),
                "ListBox" => typeof(ListBoxPage),
                "TextBoxs" => typeof(TextBoxsPage),
                "Settings" => typeof(SettingsPage),
                _ => throw new NotImplementedException()
            }
        );
    }
}