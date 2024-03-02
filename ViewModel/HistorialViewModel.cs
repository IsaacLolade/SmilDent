using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;

namespace SmileDent.ViewModel;

public partial class HistorialViewModel : ObservableObject
{
    private List<string> medicalHistory;
    private List<string> allergies;
    private string _name;
    private string _surname;
    private string _fullName;
    private string _documentNumber;
    private int _age;
    private DateTime _birthDate;
    private string _tariffType;
    public string _history;
    public string _allergie;
    
    public List<string> MedicalHistory
    {
        get => medicalHistory;
        set
        {
            if (medicalHistory != value)
            {
                medicalHistory = value;
                OnPropertyChanged();
            }
        }
    }
    
    public List<string> Allergies
    {
        get => allergies;
        set
        {
            if (allergies != value)
            {
                allergies = value;
                OnPropertyChanged();
            }
        }
    }
    
    public string Name
    {
        get => _name;
        set
        {
            if (_name != value)
            {
                _name = value;
                OnPropertyChanged();
            }
        }
    }
    
    public string Surname
    {
        get => _surname;
        set
        {
            if (_surname != value)
            {
                _surname = value;
                OnPropertyChanged();
            }
        }
    }
    
    public string FullName
    {
        get => _fullName;
        set
        {
            if (_fullName != value)
            {
                _fullName = value;
                OnPropertyChanged();
            }
        }
    }
    public string DocumentNumber
    {
        get => _documentNumber;
        set
        {
            if (_documentNumber != value)
            {
                _documentNumber = value;
                OnPropertyChanged();
            }
        }
    }
    public int Age
    {
        get => DateTime.Now.Year - BirthDate.Year;
        
    }
    
    public DateTime BirthDate
    {
        get => _birthDate;
        set
        {
            if (_birthDate != value)
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }
    }
    public string TariffType
    {
        get => _tariffType;
        set
        {
            if (_tariffType != value)
            {
                _tariffType = value;
                OnPropertyChanged();
            }
        }
    }

    public string History
    {
        get => _history;
        set
        {
            if (_history != value)
            {
                _history = value;
                OnPropertyChanged();
            }
        }
    }

    public string Allergie
    {
        get => _allergie;
        set
        {
            if (_allergie != value)
            {
                _allergie = value;
                OnPropertyChanged();
            }
        }
    }
    
    public HistorialViewModel(Person paciente)
    {
        InitializeAsync(paciente);
    }

    private async void InitializeAsync(Person paciente)
    {
        try
        {
            var connector = new Mongo("mongodb://admin:12345678@34.155.217.86:27017/", "SmileDent");

            // Retrieve medical history from the database
            var historyDb = connector.GetMedicalHistory();
            var filter = Builders<MedicalHistory>.Filter.Eq(u => u.user, paciente.Document_number);
            var medicalHistoryList = await historyDb.Find(filter).ToListAsync();
            MedicalHistory = medicalHistoryList.Select(history => history.medicalReport).ToList();

            // Retrieve alerts from the database
            var alertsDb = connector.GetAlertsCollection();
            var alertsFilter = Builders<Alerts>.Filter.Eq(u => u.user, paciente.Document_number);
            var alertsList = await alertsDb.Find(alertsFilter).ToListAsync();
            Allergies = alertsList.Select(alert => alert.alert).ToList();

            // Set other properties
            Name = paciente.Name;
            FullName = paciente.Name + " " + paciente.Surname;
            TariffType = paciente.Tariff;
            BirthDate = paciente.BirthDate;
            DocumentNumber = paciente.Document_number;
        }
        catch (Exception e)
        {
            MessagingCenter.Send(this, "DisplayAlert", e.Message);
        }
    }
  [RelayCommand]
    async Task AddMedicalHistory()
    {
        try
        {
            var connector = new Mongo("mongodb://admin:12345678@34.155.217.86:27017/", "SmileDent");
            var historyDb = connector.GetMedicalHistory();
            var historial = new MedicalHistory() { user = DocumentNumber, medicalReport = History };
            await historyDb.InsertOneAsync(historial);
        }
        catch (Exception e)
        {
            MessagingCenter.Send(this, "DisplayAlert", e.Message);
        }
        
    }
    
    [RelayCommand]
    async Task AddAlert()
    {
        try
        {
            var connector = new Mongo("mongodb://admin:12345678@34.155.217.86:27017/", "SmileDent");
            var historyDb = connector.GetAlertsCollection();
            var historial = new Alerts() { user = DocumentNumber, alert = Allergie };
            await historyDb.InsertOneAsync(historial);
        }
        catch (Exception e)
        {
            MessagingCenter.Send(this, "DisplayAlert", e.Message);
        }
    }
        
    
    public event PropertyChangedEventHandler? PropertyChanged;
    public virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}