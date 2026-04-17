using System.Diagnostics.CodeAnalysis;
using Avalonia.Controls;
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
    private static readonly Dictionary<string, Type> PageMap = new()
    {
        ["Home"] = typeof(HomePage),
        ["Login"] = typeof(LoginPage),
        ["ListBox"] = typeof(ListBoxPage),
        ["TextBox"] = typeof(TextBoxPage),
        ["Settings"] = typeof(SettingsPage),
        ["RadioButton"] = typeof(RadioButtonPage)
    };
    
    private void OnSelectionChanged(object sender, FANavigationViewSelectionChangedEventArgs e)
    {
        if (e.SelectedItem is not FANavigationViewItem item) return;

        if (item.Content is string key && PageMap.TryGetValue(key, out var type))
            Frame.Navigate(type);
        else
            throw new NotImplementedException();
    }
}