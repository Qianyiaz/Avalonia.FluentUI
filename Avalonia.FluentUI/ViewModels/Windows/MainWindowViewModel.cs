using System.Reflection;

namespace Avalonia.FluentUI.ViewModels.Windows;

public static class MainWindowViewModel
{
    public static string Title =>
        Assembly.GetEntryAssembly()!.GetName().Name!;
    
    public static string Version =>
        Assembly.GetEntryAssembly()!.GetName().Version!.Major + "." + Assembly.GetEntryAssembly()!.GetName().Version!.Minor;
}