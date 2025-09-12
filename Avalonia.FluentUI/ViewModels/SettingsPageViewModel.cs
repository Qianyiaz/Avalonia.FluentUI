using Avalonia.Controls;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.FluentUI.ViewModels;

public partial class SettingsPageViewModel : ObservableObject
{
    [ObservableProperty]
    private ComboBoxItem _selectedItem;

    partial void OnSelectedItemChanged(ComboBoxItem value)
    {
        Application.Current!.RequestedThemeVariant = value.Content switch
        {
            "System" => ThemeVariant.Default,
            "Light" => ThemeVariant.Light,
            "Dark" => ThemeVariant.Dark,
            _ => ThemeVariant.Default
        };
    }
}