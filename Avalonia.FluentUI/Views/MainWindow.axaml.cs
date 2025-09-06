using FluentAvalonia.UI.Controls;
using FluentAvalonia.UI.Windowing;

namespace Avalonia.FluentUI.Views;

public partial class MainWindow : AppWindow
{
    public MainWindow()
    {
        InitializeComponent();
        TitleBar.ExtendsContentIntoTitleBar = true;
        Loaded += (_, _) => { RootNavigation.SelectedItem = RootNavigation.MenuItems[0]; };
    }

    private void OnSelectionChanged(object sender, NavigationViewSelectionChangedEventArgs e)
    {
        if (e.SelectedItem is not NavigationViewItem item) return;
        switch (item.Tag)
        {
            case "home":
                Frame.Navigate(typeof(HomePage));
                break;
            case "settings":
                Frame.Navigate(typeof(SettingPages));
                break;
        }
    }
}