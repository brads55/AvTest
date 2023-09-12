using System.Collections.ObjectModel;
using DynamicData;
using ReactiveUI;

namespace AvTest.ViewModels;

public class SubViewModel : ViewModelBase
{
    static int _id = 0;

    private TabItem _selectedItem;
    public TabItem SelectedItem
    {
        get => _selectedItem;
        set
        {
            if (value != null)
            {
                this.RaiseAndSetIfChanged(ref _selectedItem, value);
            }
        }
    }

    public ObservableCollection<TabItem> Items { get; } = new();

    public SubViewModel()
    {
        if (_id++ == 0)
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
