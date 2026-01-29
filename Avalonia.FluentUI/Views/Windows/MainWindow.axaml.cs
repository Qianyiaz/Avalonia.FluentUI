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

        /*var loginPage = new LoginPage();
        var result = await new ContentDialog
        {
            Title = "登录你的账号",
            Content = loginPage,
            PrimaryButtonText = "登录",
            SecondaryButtonText = "注册",
            CloseButtonText = "退出"
        }.ShowAsync();

        switch (result)
        {
            case ContentDialogResult.Primary when (bool)loginPage.TokenCheckBox.IsChecked!:
                await App.ChmlFrpClient.LoginByTokenAsync("", (bool)loginPage.SaveCheckBox.IsChecked!);
                break;
            case ContentDialogResult.Primary:
                await App.ChmlFrpClient.LoginAsync("", "", (bool)loginPage.SaveCheckBox.IsChecked!);
                break;
            case ContentDialogResult.Secondary:
                Process.Start(new ProcessStartInfo("https://panel.chmlfrp.net/sign") { UseShellExecute = true });
                break;
            default:
                Close();
                break;
        }*/

        RootNavigation.SelectedItem = RootNavigation.MenuItems[0];
    }

    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(HomePage))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(ListBoxPage))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(TextBoxPage))]
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
                "TextBox" => typeof(TextBoxPage),
                "Settings" => typeof(SettingsPage),
                _ => throw new NotImplementedException()
            }
        );
    }
}