using System.Diagnostics;
using System.Reflection;
using Avalonia.Styling;

namespace Avalonia.FluentUI.ViewModels.Pages;

public partial class SettingsPageViewModel : ObservableObject
{
    [ObservableProperty] private string _themeVariantValue;

    public SettingsPageViewModel()
    {
        ThemeVariantValue = Application.Current?.RequestedThemeVariant?.Key.ToString() ?? "Default";
    }

    public static string? Version =>
        Assembly.GetEntryAssembly()?.GetName().Version?.ToString();

    partial void OnThemeVariantValueChanged(string value)
    {
        Application.Current?.RequestedThemeVariant = value switch
        {
            "Light" => ThemeVariant.Light,
            "Dark" => ThemeVariant.Dark,
            _ => ThemeVariant.Default
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