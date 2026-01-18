using System.Diagnostics;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.FluentUI.ViewModels.Pages;

public partial class SettingsPageViewModel : ObservableObject
{
    [ObservableProperty] private string _themeVariantValue =
        Application.Current!.RequestedThemeVariant!.Key.ToString()!;
    
    partial void OnThemeVariantValueChanged(string value) =>
        Application.Current!.RequestedThemeVariant = value switch
        {
            "Light" => ThemeVariant.Light,
            "Dark" => ThemeVariant.Dark,
            _ => ThemeVariant.Default
        };
    
    [RelayCommand]
    private void OpenUrl() =>
        Process.Start(new ProcessStartInfo
        {
            FileName = "https://github.com/Qianyiaz/Avalonia.FluentUI",
            UseShellExecute = true
        });
}