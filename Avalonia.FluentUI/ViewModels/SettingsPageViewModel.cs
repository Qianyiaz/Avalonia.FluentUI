using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using FluentAvalonia.UI.Controls;

namespace Avalonia.FluentUI.ViewModels;

public partial class SettingsPageViewModel : ObservableObject
{
    [ObservableProperty] private FAComboBoxItem _selectedItem;

    public SettingsPageViewModel()
    {
        SelectedItem = (string)Application.Current?.RequestedThemeVariant?.Key switch
        {
            "Default" => ThemeItems[0],
            "Light" => ThemeItems[1],
            "Dark" => ThemeItems[2],
            _ => ThemeItems[0]
        };
    }

    public static string Version => Assembly.GetEntryAssembly()?.GetName().Version?.ToString();

    public ObservableCollection<FAComboBoxItem> ThemeItems { get; } =
    [
        new() { Content = "System" },
        new() { Content = "Light" },
        new() { Content = "Dark" }
    ];

    partial void OnSelectedItemChanged(FAComboBoxItem value)
    {
        Application.Current?.RequestedThemeVariant = value?.Content switch
        {
            "System" => ThemeVariant.Default,
            "Light" => ThemeVariant.Light,
            "Dark" => ThemeVariant.Dark,
            _ => ThemeVariant.Default
        };
    }

    public async Task OpenUrl()
    {
        if (await new ContentDialog
        {
            Title = "Let's go ...",
            Content = """
                          This is a demo app for Avalonia.FluentUI.
                          You can find the source code on GitHub.
                          Feel free to star the repo if you like it!
                          Thank you for using Avalonia.FluentUI! :-)
                          """,
            PrimaryButtonText = "Go! :-)",
            CloseButtonText = "Leave me alone!"
        }.ShowAsync() == ContentDialogResult.Primary)
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/Qianyiaz/Avalonia.FluentUI",
                UseShellExecute = true
            });
    }
}