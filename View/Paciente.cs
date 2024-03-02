using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmileDent.ViewModel;

namespace SmileDent.View;

public partial class Paciente : TabbedPage
{
    public event EventHandler PageClosed;
    
    public Paciente(Person paciente) 
    {
        var tarifas = new Tarifas(); 
        var afiliacion = new Afiliacion();
        var historial = new Historial();

        // Establece el BindingContext para las páginas que lo requieran
        afiliacion.BindingContext = new AfiliacionViewModel(paciente);
        tarifas.BindingContext = new TarifasViewModel(paciente);
        historial.BindingContext = new HistorialViewModel(paciente);

        // Agrega las páginas a TabbedPage
        
        Children.Add(afiliacion);
        Children.Add(tarifas);
        Children.Add(historial);
        // Asigna el paciente a la página
        Disappearing += OnPageDisappearing;
    }

    // Llama a este método cuando la página está a punto de desaparecer
    private void OnPageDisappearing(object sender, EventArgs e)
    {
        // Dispara el evento PageClosed
        PageClosed?.Invoke(this, EventArgs.Empty);
    }
}