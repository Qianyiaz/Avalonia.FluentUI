using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls.Selection;
using FluentAvalonia.UI.Controls;

namespace Avalonia.FluentUI.ViewModels.Pages;

[SuppressMessage("ReSharper", "StringLiteralTypo")]
public partial class WifiPageViewModel : ObservableObject
{
    [ObservableProperty] private bool _isEnabled = true;
    [ObservableProperty] private bool _isMultiple;

    public ObservableCollection<ConnectionItem> Items { get; } =
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
        Items.Clear();
        Items.Add(new ConnectionItem { Name = "QWHJVWw" });
        Items.Add(new ConnectionItem { Name = "HGGJVWw" });
        Items.Add(new ConnectionItem { Name = "HwdWJBH" });
        Items.Add(new ConnectionItem { Name = "wddwaWw" });
        Items.Add(new ConnectionItem { Name = "JBLGhww" });
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

    public async Task Change(ISelectionModel selectionModel)
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
        foreach (var item in items)
            item.Name = textBox.Text;
    }

    public void Remove(ISelectionModel selectionModel)
    {
        foreach (var item in selectionModel.SelectedItems.OfType<ConnectionItem>().ToList())
            Items.Remove(item);
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