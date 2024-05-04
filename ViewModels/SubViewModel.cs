using System.Collections.ObjectModel;
using DynamicData;
using ReactiveUI;

namespace AvTest.ViewModels;

public class SubViewModel : ViewModelBase
{
    private static int _nextId = 0;

    private readonly int _id = _nextId++;

    private int _selectedIndex;
    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            System.Console.WriteLine($"SELECT: {_id} -> {value}");
            if (value != -1)
            {
                this.RaiseAndSetIfChanged(ref _selectedIndex, value);
            }
        }
    }

    public ObservableCollection<TabItem> Items { get; } = new();

    public SubViewModel()
    {
        System.Console.WriteLine($"CONSTRUCT: {_id}");

        if (_id == 0)
        {
            Items.AddRange(new[] { new TabItem { Value = 0 }, new TabItem { Value = 1 }, new TabItem { Value = 2 } });
        }
        else
        {
            Items.AddRange(new[] { new TabItem { Value = 10 } });
        }

        _selectedIndex = 0;
    }
}
