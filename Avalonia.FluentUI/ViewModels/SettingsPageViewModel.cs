using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using Avalonia.Controls;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.FluentUI.ViewModels;

public partial class SettingsPageViewModel : ObservableObject
{
    [ObservableProperty] private ComboBoxItem _selectedItem;

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

    public string Version => Assembly.GetEntryAssembly()?.GetName().Version?.ToString();

    public ObservableCollection<ComboBoxItem> ThemeItems { get; } =
    [
        new() { Content = "System" },
        new() { Content = "Light" },
        new() { Content = "Dark" }
    ];

    partial void OnSelectedItemChanged(ComboBoxItem value)
    {
        Application.Current?.RequestedThemeVariant = value?.Content switch
        {
            "System" => ThemeVariant.Default,
            "Light" => ThemeVariant.Light,
            "Dark" => ThemeVariant.Dark,
            _ => ThemeVariant.Default
        };
    }

    [RelayCommand]
    private void OpenUrl()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "https://github.com/Qianyiaz/Avalonia.FluentUI",
            UseShellExecute = true
        });
    }
}