using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.FluentUI.Views.Windows;
using Avalonia.Markup.Xaml;

namespace Avalonia.FluentUI.Views;

public class App : Application
{
    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.MainWindow = new MainWindow();
    }
}