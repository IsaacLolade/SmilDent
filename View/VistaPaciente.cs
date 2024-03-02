﻿

using SmileDent.ViewModel;

namespace SmileDent.View;
public partial class VistaPacientes : ContentPage
{
    
    private CreacionPacientes openPage;
    private bool isCreacionPacientesOpen = false;
    
    private Paciente openPaciente;
    private bool isPacientesOpen = false;


    private List<Person> llistatpacients;
    public VistaPacientes()
    {
        InitializeComponent();
        BindingContext = new ListPacientesViewModel();

        llistatpacients  = llistat.ItemsSource as List<Person>;

    }

   async public void OnCreatePaciente(object sender, EventArgs eventArgs)
    {
        // Verifica si la página ya está abierta
        if (!isCreacionPacientesOpen)
        {
            // Abre una nueva ventana o realiza cualquier acción que necesites
            openPage = new CreacionPacientes();
            isCreacionPacientesOpen = true;

            // Suscríbir al evento PageClosed en CreacionPacientes
            openPage.PageClosed += OnCreacionPacientesClosed;

            Application.Current.OpenWindow(new Window
            {
                Page = openPage, 
                Width = 1280,
                Height = 720
            });
        }
        else
        {
            await DisplayAlert("Alerta", "La ventana ya se encuentra abierta", "OK");
        }
    }

    private void OnCreacionPacientesClosed(object sender, EventArgs e)
    {
        // Este método se llama cuando la ventana de CreacionPacientes se cierra
        isCreacionPacientesOpen = false; // Reinicia la bandera
        openPage = null;    // Limpia la referencia de la página
    }

   async private void onPacienteSelected(object sender, ItemTappedEventArgs e)
    {
        if (!isPacientesOpen)
        {
            isPacientesOpen = true;
            var paciente = e.Item as Person;
            
            openPaciente = new Paciente(paciente);
            openPaciente.PageClosed += OnPacienteClosed;
            Application.Current.OpenWindow(new Window
            {
                Page = openPaciente,
                Width = 1280,
                Height = 720
                
            });
        }
        else
        {
            await DisplayAlert("Alerta", "La ventana ya se encuentra abierta", "OK");
        }
        
    }
    
    private void OnPacienteClosed(object sender, EventArgs e)
    {
        isPacientesOpen = false;
        openPaciente = null;
    }
    
    private void SearchCommand(object sender, TextChangedEventArgs e)
    {
        string buscador = e.NewTextValue;

        if (llistat != null)
        {
            // Filtra los clientes que contienen el texto buscado
            
            var result = llistatpacients.Where(c => c.Name.ToLower().Contains(buscador.ToLower()) 
                                                    || c.Document_number.ToLower().Contains(buscador.ToLower()) 
                                                    || c.Surname.ToLower().Contains(buscador.ToLower()) 
                                                    || c.Sex.ToLower().Contains(buscador.ToLower()) 
                                                    || c.Population.ToLower().Contains(buscador.ToLower())
                                                    || c.Province.ToLower().Contains(buscador.ToLower())
                                                    || c.Email.ToLower().Contains(buscador.ToLower()) 
                                                    || c.PhoneNumber.ToString().Contains(buscador) 
                                                    || c.Telephone.ToString().Contains(buscador)).ToList();
            llistat.ItemsSource = result;
        }
    }
}