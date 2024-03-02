
using SmileDent.ViewModel;

namespace SmileDent.View;

public partial class Historial : ContentPage
{
    public Historial()
    {
        InitializeComponent();
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
    public Person Persona { get; set; }
}