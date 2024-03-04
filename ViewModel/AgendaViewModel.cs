

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;
using SmileDent.View;

namespace SmileDent.ViewModel;
// esta clase se encarga de mostrar las citas en la agenda
public partial class AgendaViewModel : ObservableObject,INotifyPropertyChanged
{
    private DateTime _selectedDate;
    private TimeSpan _startTime;
    private TimeSpan _endTime;
    private string _patient;
    private string _dentist;
    private int _seat;
    
    public ObservableCollection<ControlModel> CustomEvents { get; set; }
    public AsyncRelayCommand AddAppointmentCommand { get;  set; }
    public DateTime SelectedDate
    {
        get { return _selectedDate; }
        set
        {
            if (_selectedDate != value)
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
            }
        }
    }

    public TimeSpan SelectedTime
    {
        get { return _startTime; }
        set
        {
            if (_startTime != value)
            {
                _startTime = value;
                OnPropertyChanged(nameof(SelectedTime));
            }
        }
    }
    
    public TimeSpan EndTime
    {
        get { return _endTime; }
        set
        {
            if (_endTime != value)
            {
                _endTime = value;
                OnPropertyChanged(nameof(EndTime));
            }
        }
    }

    public string Patient
    {
        get { return _patient; }
        set
        {
            if (_patient != value)
            {
                _patient = value;
                OnPropertyChanged(nameof(Patient));
            }
        }
    }

    public string Dentist
    {
        get { return _dentist; }
        set
        {
            if (_dentist != value)
            {
                _dentist = value;
                OnPropertyChanged(nameof(Dentist));
            }
        }
    }
    
    public int Seat
    {
        get { return _seat; }
        set
        {
            if (_seat != value)
            {
                _seat = value;
                OnPropertyChanged(nameof(Seat));
            }
        }
    }


    
    public AgendaViewModel()
    {
        CustomEvents = new ObservableCollection<ControlModel>();
        AddAppointmentCommand = new AsyncRelayCommand(AddAppointment);
        LoadAppointments();
    }
    

private async Task AddAppointment()
{
    try
    {
        // Utiliza SelectedDate, SelectedTime, EndTime, Patient, Dentist y Seat según sea necesario
        DateTime eventStart = SelectedDate.Add(SelectedTime);
        DateTime eventEnd = SelectedDate.Add(EndTime);

        // Crea un objeto de cita (Appointment)
        var nuevaCita = new Appointment
        {
            EventStart = eventStart,
            EventEnd = eventEnd,
            Name = Patient,
            Dentist = Dentist,
            Seat = Seat
        };

        // Almacena la cita en MongoDB
        await saveAppointment(nuevaCita);

        // Agrega la cita a tu ObservableCollection para mostrarla en la interfaz de usuario
        CustomEvents.Add(new ControlModel
        {
            EventStart = eventStart,
            EventEnd = eventEnd,
            Name = Patient,
            Color = Colors.Blue
        });

        // Restablece los campos del formulario después de agregar una cita
        SelectedDate = DateTime.Now.Date;
        SelectedTime = DateTime.Now.TimeOfDay;
        EndTime = DateTime.Now.TimeOfDay;
        Patient = string.Empty;
        Dentist = string.Empty;
        Seat = 0;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Excepción durante la creación de la cita: {ex}");
        // Maneja la excepción según sea necesario
    }
}

private async Task saveAppointment(Appointment cita)
{
    try
    {
        // Conéctate a MongoDB
        var cliente = new Mongo("mongodb://admin:12345678@34.155.217.86:27017/", "SmileDent");
       
        // Obtiene la colección MongoDB para las citas
        var appoinmentDb = cliente.GetAppointmentCollection();
        
        // Inserta el nuevo documento de cita
       
        appoinmentDb.InsertOne(cita);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Excepción durante la operación en MongoDB: {ex}");
        // Maneja la excepción según sea necesario
    }
}

private async Task LoadAppointments()
{
    var existingAppointments = await RetrieveAppointmentsFromMongo();
        foreach (var appointment in existingAppointments)
        {
            CustomEvents.Add(new ControlModel
            {
                EventStart = appointment.EventStart,
                EventEnd = appointment.EventEnd,
                Name = appointment.Name,
                Color = Colors.Chocolate
            });
        }
}

private async Task<List<Appointment>> RetrieveAppointmentsFromMongo()
{
    try
    {
        // Conectar a MongoDB
        var cliente = new Mongo("mongodb://admin:12345678@34.155.217.86:27017/", "SmileDent");

        // Obtener la colección de MongoDB para las citas
        var coleccion = cliente.GetAppointmentCollection();

        // Recuperar todas las citas de la colección
        var citas = await coleccion.Find(_ => true).ToListAsync();

        return citas;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception during patient creation: {ex}");
        MessagingCenter.Send(this, "DisplayAlert", "Error during creation");
        return new List<Appointment>();
    }
}


public event PropertyChangedEventHandler? PropertyChanged;

protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
{
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

}