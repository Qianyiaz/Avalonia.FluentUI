using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.FluentUI.Views.Windows;
using Avalonia.Markup.Xaml;

namespace Avalonia.FluentUI.Views;

public class App : Application
{
    public static IServiceProvider? Services { get; private set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IMainWindowService, MainWindowService>();
            Services = services.BuildServiceProvider();
            
            var mainWindow = new MainWindow();
            desktop.MainWindow = mainWindow;
            
            var mainWindowService = Services.GetRequiredService<IMainWindowService>();
            if (mainWindowService is MainWindowService concreteService)
                concreteService.SetMainWindow(mainWindow);
        }

        base.OnFrameworkInitializationCompleted();
    }
}