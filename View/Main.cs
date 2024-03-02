using SmileDent.ViewModel;

namespace SmileDent.View;

public partial class Main : TabbedPage
{
    public Main()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }
    
}