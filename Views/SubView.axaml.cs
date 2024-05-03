using Avalonia.Controls;

namespace AvTest.Views;

public partial class SubView : UserControl
{
    public SubView()
    {
        System.Console.WriteLine("CREATE SUBVIEW");

        InitializeComponent();
    }
}
