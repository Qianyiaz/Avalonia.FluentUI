using Avalonia.Collections;
using Avalonia.Controls.Selection;
using Avalonia.FluentUI.Models;
using CommunityToolkit.Mvvm.Input;

namespace Avalonia.FluentUI.ViewModels.Pages;

public partial class WifiPageViewModel : ObservableObject
{
    [ObservableProperty] private bool _isMultiple;

    [ObservableProperty] private bool _isEnabled = true;

    [ObservableProperty] private SelectionMode _listBoxSelectionMode = SelectionMode.Toggle;

    [ObservableProperty] private ISelectionModel? _selectionModel;

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
        ListBoxSelectionMode = SelectionMode.Toggle;
        ListBoxSelectionMode |= IsMultiple ? SelectionMode.Multiple : SelectionMode.Single;
    }

    [RelayCommand]
    private void Reset()
    {
        Items.Clear();
        Items.AddRange(
        [
            new (){ Name = "QWHJVWw" },
            new () { Name = "HGGJVWw" },
            new () { Name = "HwdWJBH" },
            new () { Name = "wddwaWw" },
            new () { Name = "JBLGhww" }
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
        if (string.IsNullOrWhiteSpace(textBox.Text)) return;

        Items.Add(new()
        {
            Name = textBox.Text
        });
        IsEnabled = true;
    }

    [RelayCommand]
    private async Task Rename()
    {
        var items = SelectionModel!.SelectedItems.OfType<ConnectionItem>().ToList();

        if (items.Count == 0)
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
        if (string.IsNullOrWhiteSpace(textBox.Text)) return;
        
        items.ForEach(item => item.Name = textBox.Text);
    }

    [RelayCommand]
    private void Remove()
    {
        Items.RemoveAll(SelectionModel!.SelectedItems.OfType<ConnectionItem>());
        IsEnabled = Items.Count != 0;
    }
}