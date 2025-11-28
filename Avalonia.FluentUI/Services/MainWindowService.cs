using System.Diagnostics.CodeAnalysis;
using Avalonia.FluentUI.Views.Pages;
using Avalonia.FluentUI.Views.Windows;

namespace Avalonia.FluentUI.Services;

public interface IMainWindowService
{
    WindowTransparencyLevel CurrentTransparencyLevel { get; }
    void SetTransparencyLevel(string? level);

    void Navigate(Type t);
}

public class MainWindowService : IMainWindowService
{
    private MainWindow? _mainWindow;

    public WindowTransparencyLevel CurrentTransparencyLevel => _mainWindow?.ActualTransparencyLevel ?? WindowTransparencyLevel.None;

    public void SetTransparencyLevel(string? level)
    {
        _mainWindow?.TransparencyLevelHint =
        [
            level switch
            {
                "Mica" => WindowTransparencyLevel.Mica,
                "AcrylicBlur" => WindowTransparencyLevel.AcrylicBlur,
                _ => throw new NotImplementedException()
            }
        ];
    }

    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(HomePage))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(ListBoxPage))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(TextBoxsPage))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(SettingsPage))]
    public void Navigate(Type t)
    {
        _mainWindow?.Frame.Navigate(t);
    }

    public void SetMainWindow(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
    }
}