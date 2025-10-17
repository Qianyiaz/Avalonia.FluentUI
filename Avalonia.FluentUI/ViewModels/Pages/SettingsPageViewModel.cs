using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using Avalonia.Styling;
using FluentAvalonia.UI.Controls;

namespace Avalonia.FluentUI.ViewModels.Pages;

public partial class SettingsPageViewModel : ObservableObject
{
    [ObservableProperty] private FAComboBoxItem _selectedItem;

    public static string Version => Assembly.GetEntryAssembly()?.GetName().Version?.ToString();

    public ObservableCollection<FAComboBoxItem> ThemeItems { get; } =
    [
        new() { Content = "System" },
        new() { Content = "Light" },
        new() { Content = "Dark" }
    ];

    partial void OnSelectedItemChanged(FAComboBoxItem value)
    {
        Application.Current?.RequestedThemeVariant = value.Content switch
        {
            "System" => ThemeVariant.Default,
            "Light" => ThemeVariant.Light,
            "Dark" => ThemeVariant.Dark,
            _ => throw new NullReferenceException()
        };
    }

    public void OpenUrl()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "https://github.com/Qianyiaz/Avalonia.FluentUI",
            UseShellExecute = true
        });
    }
}