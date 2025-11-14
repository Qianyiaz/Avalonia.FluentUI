using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.FluentUI.Views.Windows;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using FluentAvalonia.UI.Windowing;

namespace Avalonia.FluentUI.Views;

public class App : Application
{
    public override void Initialize() => AvaloniaXamlLoader.Load(this);
    
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            desktop.MainWindow = new MainWindow
            {
                SplashScreen = new SplashScreen
                {
                    MinimumShowTime = 800,
                    AppIcon = new Bitmap(AssetLoader.Open(new("avares://Avalonia.FluentUI/app.ico")))
                }
            };
        
        base.OnFrameworkInitializationCompleted();
    }
}

internal class SplashScreen : IApplicationSplashScreen
{
    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public string AppName { get; }
    
    public IImage AppIcon { get; init; }

    // ReSharper disable once UnassignedGetOnlyAutoProperty
    public object SplashScreenContent { get; }
    
    // To avoid too quickly transitioning away from the splash screen, you can set a minimum
    // time to hold before loading the content, value is in Milliseconds
    public int MinimumShowTime { get; init; }

    // Place your loading tasks here. NOTE, this is already called on a background thread, so
    // if any UI thread work needs to be done, use Dispatcher.UIThread.Post or .InvokeAsync
    public Task RunTasks(CancellationToken _) => Task.CompletedTask;
}
