using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using AvTest.ViewModels;

namespace AvTest.Views;

public class MainWindow : Window
{
    private readonly SubView _v1 = new();
    private readonly SubView _v2 = new();
    private readonly SubViewModel _v1m = new();
    private readonly SubViewModel _v2m = new();

    public MainWindow()
    {
        _v1.DataContext = _v1m;
        _v2.DataContext = _v2m;

        var content = new ContentControl { Content = _v1 };

        var swapButton = new Button { Content = "Swap" };
        var recycleCombo = new ComboBox();
        recycleCombo.Items.Add("Two Fixed Subviews");
        recycleCombo.Items.Add("Single Recycled Subview");
        recycleCombo.Items.Add("Create Fresh Subview");
        recycleCombo.SelectedIndex = 1;

        var stackPanel = new StackPanel { Orientation = Orientation.Horizontal, Spacing = 50 };
        stackPanel.Children.Add(swapButton);
        stackPanel.Children.Add(recycleCombo);

        recycleCombo.SelectionChanged += (_, _) =>
        {
            switch (recycleCombo.SelectedIndex)
            {
                case 0:
                    _v1.DataContext = _v1m;
                    _v2.DataContext = _v2m;
                    break;
                case 1:
                    content.Content = _v1;
                    break;
            }
        };

        swapButton.Click += (_, _) =>
        {
            switch (recycleCombo.SelectedIndex)
            {
                case 0:
                    content.Content = ReferenceEquals(content.Content, _v1) ? _v2 : _v1;
                    break;
                case 1:
                    _v1.DataContext = ReferenceEquals(_v1.DataContext, _v1m) ? _v2m : _v1m;
                    break;
                case 2:
                    content.Content = ReferenceEquals((content.Content as StyledElement)!.DataContext, _v1m)
                        ? new SubView { DataContext = _v2m }
                        : new SubView { DataContext = _v1m };
                    break;
            }
        };

        var grid = new Grid
        {
            RowDefinitions = new RowDefinitions("Auto,*")
        };

        Grid.SetRow(content, 1);
        Grid.SetRow(stackPanel, 0);
        grid.Children.Add(stackPanel);
        grid.Children.Add(content);

        Content = grid;
    }
}