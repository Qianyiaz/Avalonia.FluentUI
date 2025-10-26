using Avalonia.Collections;
using Avalonia.Controls.Selection;
using FluentAvalonia.UI.Controls;

namespace Avalonia.FluentUI.ViewModels.Pages;

public partial class WifiPageViewModel : ObservableObject
{
    [ObservableProperty] private bool _isEnabled = true;
    [ObservableProperty] private bool _isMultiple;

    public AvaloniaList<ConnectionItem> Items { get; } =
    [
        new() { Name = "QWHJVWw" },
        new() { Name = "HGGJVWw" },
        new() { Name = "HwdWJBH" },
        new() { Name = "wddwaWw" },
        new() { Name = "JBLGhww" }
    ];

    public void Multiple(ListBox listBox)
    {
        listBox.SelectionMode = SelectionMode.Toggle;
        listBox.SelectionMode |= IsMultiple ? SelectionMode.Multiple : SelectionMode.Single;
    }

    public void Reset()
    {
        Items.RemoveRange(0,Items.Count);
        Items.AddRange([
            new (){ Name = "QWHJVWw" },
            new () { Name = "HGGJVWw" },
            new () { Name = "HwdWJBH" },
            new () { Name = "wddwaWw" },
            new () { Name = "JBLGhww" }
        ]);
        IsEnabled = true;
    }

    public async Task Add()
    {
        var textBox = new TextBox
        {
            Watermark = "Enter SSID",
            Width = 300
        };
        if (await new ContentDialog
            {
                Title = "Add new connection",
                Content = textBox,
                PrimaryButtonText = "Add",
                CloseButtonText = "Cancel"
            }.ShowAsync() != ContentDialogResult.Primary) return;
        if (string.IsNullOrWhiteSpace(textBox.Text)) return;
        Items.Add(new ConnectionItem { Name = textBox.Text });
        IsEnabled = true;
    }

    public async Task Rename(ISelectionModel selectionModel)
    {
        var items = selectionModel.SelectedItems.OfType<ConnectionItem>().ToList();
        if (items.Count == 0) return;
        var textBox = new TextBox
        {
            Watermark = "Enter SSID",
            Width = 300
        };
        if (await new ContentDialog
            {
                Title = "Rename the connection",
                Content = textBox,
                PrimaryButtonText = "Rename",
                CloseButtonText = "Cancel"
            }.ShowAsync() != ContentDialogResult.Primary) return;
        if (string.IsNullOrWhiteSpace(textBox.Text)) return;
        items.ForEach(item => item.Name = textBox.Text);
    }

    public void Remove(ISelectionModel selectionModel)
    {
        Items.RemoveAll(selectionModel.SelectedItems.OfType<ConnectionItem>().ToList());
        if (Items.Count == 0)
            IsEnabled = false;
    }
}

public partial class ConnectionItem : ObservableObject
{
    [ObservableProperty] private bool _isChecked;
    [ObservableProperty] private object _name;

    /*
    partial void OnIsCheckedChanged(bool value)
    {
        if (value)
        {
        }
    }
    */
}