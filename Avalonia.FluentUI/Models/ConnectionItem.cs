namespace Avalonia.FluentUI.Models;

public partial class ConnectionItem : ObservableObject
{
    public string Name { get; set; }

    [ObservableProperty] private bool _isChecked;

    /*
    partial void OnIsCheckedChanged(bool value)
    {
        if (value)
        {
        }
    }
    */
}