using Avalonia.FluentUI.Views.Pages;
using FluentAvalonia.UI.Windowing;

namespace Avalonia.FluentUI.Views.Windows;

public partial class MainWindow : AppWindow
{
    private readonly IMainWindowService? _mainWindowService;

    public MainWindow()
    {
        InitializeComponent();
        _mainWindowService = App.Services?.GetService<IMainWindowService>();
    }

    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        RootNavigation.SelectedItem = RootNavigation.MenuItems[0];
    }

    private void OnSelectionChanged(object sender, NavigationViewSelectionChangedEventArgs e)
    {
        if (e.SelectedItem is not NavigationViewItem item) return;

        _mainWindowService?.Navigate
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