using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;

namespace SmileDent.ViewModel;

public partial class CreacionPacienteViewModel : ObservableObject, INotifyPropertyChanged
{
    private string _id;
    private string _name;
    private string _surname;
    private string _documentNumber;
    private string _documentType;
    private DateTime _birthDate;
    private int _postCode;
    private string _direction;
    private string _population;
    private string _city;
    private string _country;
    private int _housePhone;
    private int _workNumber;
    private int _phoneNumber;
    private string _email;
    private string _sex;
    private string _bloddtype;
    private string _maritalStatus;
    private string _insuranceCompany;
    private string _tariff;
    private int _insuranceNumber;
    private string _defaultTariff;
    private DateTime _record;
    private DateTime _activeTariff;
    private DateTime _expiringTariff;
    private bool _lopdCheckded;
   public CreacionPacienteViewModel()
    {
        // Autogenerate an unic Id for each patient
        Id = Guid.NewGuid().ToString("N");
        BirthDate = DateTime.Now;
        ActiveTariff = DateTime.Now;
        ExpiringTariff = DateTime.Now;
    }
    
public string Id
{
    get => _id;
    set
    {
        if (_id != value)
        {
            _id = value;
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


public string DocumentType
{
    get => _documentType;
    set
    {
        if (_documentType != value)
        {
            _documentType = value;
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


public int PostCode
{
    get => _postCode;
    set
    {
        if (_postCode != value)
        {
            _postCode = value;
            OnPropertyChanged();
        }
    }
}


public string Direction
{
    get => _direction;
    set
    {
        if (_direction != value)
        {
            _direction = value;
            OnPropertyChanged();
        }
    }
}

public string Population
{
    get => _population;
    set
    {
        if (_population != value)
        {
            _population = value;
            OnPropertyChanged();
        }
    }
}

public string City
{
    get => _city;
    set
    {
        if (_city != value)
        {
            _city = value;
            OnPropertyChanged();
        }
    }
}

public string Country
{
    get => _country;
    set
    {
        if (_country != value)
        {
            _country = value;
            OnPropertyChanged();
        }
    }
}

public int HousePhone
{
    get => _housePhone;
    set
    {
        if (_housePhone != value)
        {
            _housePhone = value;
            OnPropertyChanged();
        }
    }
}


public int WorkNumber
{
    get => _workNumber;
    set
    {
        if (_workNumber != value)
        {
            _workNumber = value;
            OnPropertyChanged();
        }
    }
}


public int PhoneNumber
{
    get => _phoneNumber;
    set
    {
        if (_phoneNumber != value)
        {
            _phoneNumber = value;
            OnPropertyChanged();
        }
    }
}


public string Email
{
    get => _email;
    set
    {
        if (_email != value)
        {
            _email = value;
            OnPropertyChanged();
        }
    }
}


public string Sex
{
    get => _sex;
    set
    {
        if (_sex != value)
        {
            _sex = value;
            OnPropertyChanged();
        }
    }
}


public string BloodType
{
    get => _bloddtype;
    set
    {
        if (_bloddtype != value)
        {
            _bloddtype = value;
            OnPropertyChanged();
        }
    }
}


public string MaritalStatus
{
    get => _maritalStatus;
    set
    {
        if (_maritalStatus != value)
        {
            _maritalStatus = value;
            OnPropertyChanged();
        }
    }
}


public string InsuranceCompany
{
    get => _insuranceCompany;
    set
    {
        if (_insuranceCompany != value)
        {
            _insuranceCompany = value;
            OnPropertyChanged();
        }
    }
}

public string Tariff
{
    get => _tariff;
    set
    {
        if (_tariff != value)
        {
            _tariff = value;
            OnPropertyChanged();
        }
    }
}

public int InsuranceNumber
{
    get => _insuranceNumber;
    set
    {
        if (_insuranceNumber != value)
        {
            _insuranceNumber = value;
            OnPropertyChanged();
        }
    }
}

public string DefaultTariff
{
    get => _defaultTariff;
    set
    {
        if (_defaultTariff != value)
        {
            _defaultTariff = value;
            OnPropertyChanged();
        }
    }
}

public DateTime ActiveTariff
{
    get => _activeTariff;
    set
    {
        if (_activeTariff != value)
        {
            _activeTariff = value;
            OnPropertyChanged();
        }
    }
}

public DateTime ExpiringTariff
{
    get => _expiringTariff;
    set
    {
        if (_expiringTariff != value)
        {
            _expiringTariff = value;
            OnPropertyChanged();
        }
    }
}
public DateTime Inactiv
{
    get => _record;
    set
    {
        if (_record != value)
        {
            _record = value;
            OnPropertyChanged();
        }
    }
}
public bool IsLOPDChecked
{
    get => _lopdCheckded;
    set
    {
        if (_lopdCheckded != value)
        {
            _lopdCheckded = value;
            OnPropertyChanged(nameof(IsLOPDChecked));
        }
    }
}

[RelayCommand]
async Task createPatient()
{
    try
    {
        if(!string.IsNullOrEmpty(Name) &&
         !string.IsNullOrEmpty(Surname) &&
         !string.IsNullOrEmpty(DocumentType) &&
         !string.IsNullOrEmpty(DocumentNumber) &&
         !string.IsNullOrEmpty(Direction) &&
         PostCode > 0 && 
         !string.IsNullOrEmpty(Population) &&
         !string.IsNullOrEmpty(City) &&
         !string.IsNullOrEmpty(Country) &&
         PhoneNumber > 0 && 
         !string.IsNullOrEmpty(Email) &&
         !string.IsNullOrEmpty(Sex) &&
         !string.IsNullOrEmpty(BloodType) &&
         !string.IsNullOrEmpty(MaritalStatus)&& 
         IsLOPDChecked)
        {
            // Conéctate a MongoDB
            var connector = new Mongo("mongodb://admin:12345678@34.155.217.86:27017/", "SmileDent");
           
            // Obtiene la colección MongoDB para los pacientes y tarifas
            var patientDb = connector.GetPatientCollection();
            var tarifDb = connector.GetTariffCollection();

            var paciente = new Patient()
            {
                historyNumber = Id,name = Name, surname = Surname, documentType = DocumentType,documentNumber = DocumentNumber,birthDate = BirthDate,
                postCode = PostCode, direction = Direction,city = City,population = Population, country = Country,housePhone = HousePhone, workNumber = WorkNumber,
                phoneNumber = PhoneNumber, email = Email, sex = Sex, bloddtype = BloodType,
                maritalStatus = MaritalStatus
            };
            
            var tariff = new Tariff()
            {
                user = DocumentNumber, insuranceCompany = InsuranceCompany, tariff = Tariff, insuranceNumber = InsuranceNumber,
                defaultTariff = DefaultTariff, inactiveRecord = Inactiv, activeTariff = ActiveTariff,
                expiringTariff = ExpiringTariff
            };
            
            // añadir a la base de datos
            await patientDb.InsertOneAsync(paciente);
            await tarifDb.InsertOneAsync(tariff);
            
        }else
        {
            MessagingCenter.Send(this, "DisplayAlert", "Error during creation");
        }
       
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception during patient creation: {ex}");
        MessagingCenter.Send(this, "DisplayAlert", "Error during creation");
    }
}


public event PropertyChangedEventHandler? PropertyChanged;
public virtual void OnPropertyChanged(string propertyName)
{
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
    
}

