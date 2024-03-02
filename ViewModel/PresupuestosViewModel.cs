using CommunityToolkit.Mvvm.ComponentModel;

namespace SmileDent.ViewModel;

public partial class PresupuestosViewModel : ObservableObject
{
    private string _currentViewName;
    public string CurrentViewName
    {
        get { return _currentViewName; }
        set
        {
            if (_currentViewName != value)
            {
                _currentViewName = value;
                OnPropertyChanged(nameof(CurrentViewName));
            }
        }
    }
}