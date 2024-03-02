using SmileDent.ViewModel;

namespace SmileDent.View;

public partial class CreacionPacientes : ContentPage
{
    // Evento que notifica cuando la página se cierra
    public event EventHandler PageClosed;

    public CreacionPacientes()
    {
        InitializeComponent();

        BindingContext = new CreacionPacienteViewModel();
        // Acoplar a este evento el método OnPageDisappearing
        this.Disappearing += OnPageDisappearing;
        
        MessagingCenter.Subscribe<CreacionPacienteViewModel, string>(this, "DisplayAlert", (sender, message) =>
        {
            DisplayAlert("Alerta", message, "OK");
        });
        
    }

    // Llama a este método cuando la página está a punto de desaparecer
    private void OnPageDisappearing(object sender, EventArgs e)
    {
        // Dispara el evento PageClosed
        PageClosed?.Invoke(this, EventArgs.Empty);
    }
    
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        MessagingCenter.Unsubscribe<IniciarViewModel, string>(this, "DisplayAlert");
    }
}