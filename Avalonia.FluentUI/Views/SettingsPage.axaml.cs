using Avalonia.Controls;
using Avalonia.Styling;

namespace Avalonia.FluentUI.Views;

public partial class SettingPages : UserControl
{
    public SettingPages()
    {
        InitializeComponent();
    }

    private void SelectingItemsControl_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is not ComboBox box) return;
        if (box.SelectedItem is not ComboBoxItem content) return;

        Application.Current!.RequestedThemeVariant = content.Content switch
        {
            "System" => ThemeVariant.Default,
            "Light" => ThemeVariant.Light,
            "Dark" => ThemeVariant.Dark,
            _ => ThemeVariant.Default
        };
    }
}