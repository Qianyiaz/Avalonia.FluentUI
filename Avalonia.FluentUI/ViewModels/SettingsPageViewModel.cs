using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;

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
}