using System.Diagnostics;
using System.Reflection;
using Avalonia.Styling;

namespace Avalonia.FluentUI.ViewModels.Pages;

public partial class SettingsPageViewModel : ObservableObject
{
    public static string Version =>
        Assembly.GetEntryAssembly()?.GetName().Version?.ToString();

    [ObservableProperty] private string _themeVariantValue = "System";
    
    partial void OnThemeVariantValueChanged(string value)
    {
        Application.Current?.RequestedThemeVariant = value switch
        {
            "System" => ThemeVariant.Default,
            "Light" => ThemeVariant.Light,
            "Dark" => ThemeVariant.Dark,
            _ => throw new NotImplementedException()
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