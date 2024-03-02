
using SmileDent.ViewModel;

namespace SmileDent.View;

public partial class InciarSesion : ContentPage
{

    public InciarSesion(IniciarViewModel vm)
    {
        InitializeComponent();
        
        BindingContext = vm;

        MessagingCenter.Subscribe<IniciarViewModel, string>(this, "DisplayAlert", (sender, message) =>
        {
            DisplayAlert("Alerta", message, "OK");
        });

    }
   
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        MessagingCenter.Unsubscribe<IniciarViewModel, string>(this, "DisplayAlert");
    }

    
}