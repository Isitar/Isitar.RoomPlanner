namespace Isitar.RoomPlanner.App.Components;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

public partial class Title : UserControl
{
    public static readonly DirectProperty<Title, string> TextProperty =
        AvaloniaProperty.RegisterDirect<Title, string>(
            nameof(Text),
            o => o.Text,
            (o, v) => o.Text = v);

    private string text = "Titel";

    public string Text
    {
        get => text;
        set => SetAndRaise(TextProperty, ref text, value);
    }
    public Title()
    {
        InitializeComponent();

        DataContext = this;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}