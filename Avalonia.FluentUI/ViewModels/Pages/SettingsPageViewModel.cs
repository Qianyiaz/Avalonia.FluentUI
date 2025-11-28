using System.Diagnostics;
using System.Reflection;
using Avalonia.FluentUI.Views;
using Avalonia.Styling;

namespace Avalonia.FluentUI.ViewModels.Pages;

public partial class SettingsPageViewModel : ObservableObject
{
    private readonly IMainWindowService? _mainWindowService;

    [ObservableProperty] private string _themeVariantValue;

    [ObservableProperty] private string? _transparencyValue;

    public SettingsPageViewModel()
    {
        _mainWindowService = App.Services?.GetService<IMainWindowService>();
        TransparencyValue = _mainWindowService?.CurrentTransparencyLevel.ToString();
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

    partial void OnTransparencyValueChanged(string? value)
    {
        _mainWindowService?.SetTransparencyLevel(value);
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