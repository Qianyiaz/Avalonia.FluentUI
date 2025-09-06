using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.FluentUI.Views.Windows;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using FluentAvalonia.UI.Windowing;

namespace Avalonia.FluentUI.Views;

public class App : Application
{
    public override void Initialize() =>
        AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted()
    {
        // If you use CommunityToolkit, line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.Clear();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            using var stream = AssetLoader.Open(new ("avares://Avalonia.FluentUI/app.ico"));
            var bmp = new Bitmap(stream);
            
            desktop.MainWindow = new MainWindow
            {
                SplashScreen = new SplashScreen
                {
                    AppIcon = bmp,
                    MinimumShowTime = 1200
                }
            };
        }
        
        base.OnFrameworkInitializationCompleted();
    }
}

internal class SplashScreen : IApplicationSplashScreen
{
    public string AppName { get; }
    public IImage AppIcon { get; init; }
    public object SplashScreenContent { get; }

    // To avoid too quickly transitioning away from the splash screen, you can set a minimum
    // time to hold before loading the content, value is in Milliseconds
    public int MinimumShowTime { get; init; }

    // Place your loading tasks here. NOTE, this is already called on a background thread, so
    // if any UI thread work needs to be done, use Dispatcher.UIThread.Post or .InvokeAsync
    public Task RunTasks(CancellationToken _)
    {
        return Task.CompletedTask;
    }
}
