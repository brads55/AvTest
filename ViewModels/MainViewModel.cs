using System.Collections.ObjectModel;
using DynamicData;
using ReactiveUI;

namespace AvTest.ViewModels;

public class MainViewModel : ViewModelBase
{
    static int _nextId = 0;

    private int _id = _nextId++;

    private SubViewModel _selectedItem;
    public SubViewModel SelectedItem
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

    private SubViewModel _v1 = new SubViewModel();
    private SubViewModel _v2 = new SubViewModel();

    public MainViewModel()
    {
        _selectedItem = _v1;
    }

    public void DoSwap()
    {
        if (_selectedItem == _v1)
            SelectedItem = _v2;
        else
            SelectedItem = _v1;
    }
}
