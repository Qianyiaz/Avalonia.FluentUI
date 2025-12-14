using Avalonia.Collections;
using Avalonia.FluentUI.Models;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.FluentUI.ViewModels.Pages;

public partial class ListBoxPageViewModel : ObservableObject
{
    [ObservableProperty] private bool _isEnabled = true;
    [ObservableProperty] private bool _isMultiple;

    [ObservableProperty] private SelectionMode _selectionMode = SelectionMode.Toggle;

    public AvaloniaList<ConnectionItem> SelectionItems { get; } = [];

    public AvaloniaList<ConnectionItem> Items { get; } =
    [
        new() { Name = "QWHJVWw" },
        new() { Name = "HGGJVWw" },
        new() { Name = "HwdWJBH" },
        new() { Name = "wddwaWw" },
        new() { Name = "JBLGhww" }
    ];

    [RelayCommand]
    private void Multiple()
    {
        SelectionMode = SelectionMode.Toggle;
        SelectionMode |= IsMultiple ? SelectionMode.Multiple : SelectionMode.Single;
    }

    [RelayCommand]
    private void Reset()
    {
        Items.Clear();
        Items.AddRange(
        [
            new() { Name = "QWHJVWw" },
            new() { Name = "HGGJVWw" },
            new() { Name = "HwdWJBH" },
            new() { Name = "wddwaWw" },
            new() { Name = "JBLGhww" }
        ]);
        IsEnabled = true;
    }

    [RelayCommand]
    private async Task Add()
    {
        var textBox = new TextBox
        {
            Watermark = "Enter SSID",
            Width = 300
        };

        if (await new ContentDialog
            {
                Title = "Add New Connection",
                Content = textBox,
                PrimaryButtonText = "Add",
                CloseButtonText = "Cancel"
            }.ShowAsync() != ContentDialogResult.Primary) return;

        Items.Add(new() { Name = textBox.Text! });
        IsEnabled = true;
    }

    [RelayCommand]
    private async Task Rename()
    {
        if (SelectionItems.Count == 0)
            return;

        var textBox = new TextBox
        {
            Watermark = "Enter new SSID for selected connections",
            Width = 300
        };

        if (await new ContentDialog
            {
                Title = "Rename connection(s)",
                Content = textBox,
                PrimaryButtonText = "Rename",
                CloseButtonText = "Cancel"
            }.ShowAsync() != ContentDialogResult.Primary) return;

        foreach (var item in SelectionItems)
            item.Name = textBox.Text!;
    }

    [RelayCommand]
    private void Remove()
    {
        Items.RemoveAll(SelectionItems);
        IsEnabled = Items.Count != 0;
    }
}