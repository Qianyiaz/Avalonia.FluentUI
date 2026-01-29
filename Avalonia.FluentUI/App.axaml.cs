using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.FluentUI.Views.Windows;
using Avalonia.Markup.Xaml;

namespace Avalonia.FluentUI;

public class App : Application
{
    // public static readonly ChmlFrpClient ChmlFrpClient = new();
    
    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.MainWindow = new MainWindow();
    }
}