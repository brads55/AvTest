using System.Collections.ObjectModel;
using DynamicData;
using ReactiveUI;

namespace AvTest.ViewModels;

public class SubViewModel : ViewModelBase
{
    static int _nextId = 0;

    private int _id = _nextId++;

    private TabItem _selectedItem;
    public TabItem SelectedItem
    {
        get => _selectedItem;
        set
        {
            System.Console.WriteLine($"SELECT: {_id} -> {value?.Value}");
            if (value != null)
            {
                this.RaiseAndSetIfChanged(ref _selectedItem, value);
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

        _selectedItem = Items[0];
    }
}
