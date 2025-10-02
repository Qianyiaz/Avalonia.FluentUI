using System.Reflection;

namespace Avalonia.FluentUI.ViewModels.Windows;

public class MainWindowViewModel : ObservableObject
{
    public static string Title => Assembly.GetEntryAssembly()?.GetName().Name;
}