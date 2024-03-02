using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;
using SmileDent.View;

namespace SmileDent.ViewModel;

public partial class AfiliacionViewModel : ObservableObject
{
    
    private int telephone;
    private int phoneNumber;
    private int workPhone;
    private string email;
    private string direction;
    private int postCode;
    private string population;
    private string province;
    private string country;
    private string document_number;
    private string sex;
    private DateTime birthDate;
    private string bloodType;
    private string maritalStatus;
    private string dentist_responsible;
    
    public DateTime BirthDate
    {
        get => birthDate;
        set => SetProperty(ref birthDate, value);
    }

    public string Sex
    {
        get => sex;
        set => SetProperty(ref sex, value);
    }
    public int Telephone
    {
        get => telephone;
        set
        {
            if (telephone != value)
            {
                telephone = value;
                OnPropertyChanged();
            }
        }
    }

    public int WorkNumber
    {
        get => workPhone;
        set
        {
            if (workPhone != value)
            {
                workPhone = value;
                OnPropertyChanged();
            }
        }
    }
    public int PhoneNumber
    {
        get => phoneNumber;
        set => SetProperty(ref phoneNumber, value);
    }
    
    public string Email
    {
        get => email;
        set
        {
            if (email != value)
            {
                email = value;
                OnPropertyChanged();
            }
        }
    }
    
    public string Direction
    {
        get => direction;
        set => SetProperty(ref direction, value);
    }
    
    public int PostCode
    {
        get => postCode;
        set => SetProperty(ref postCode, value);
    }
    
    public string Population
    {
        get => population;
        set => SetProperty(ref population, value);
    }
    
    public string Province
    {
        get => province;
        set => SetProperty(ref province, value);
    }
    
    public string Country
    {
        get => country;
        set => SetProperty(ref country, value);
    }
    
    public string Document_number
    {
        get => document_number;
        set => SetProperty(ref document_number, value);
    }
    
    public string MaritalStatus
    {
        get => maritalStatus;
        set => SetProperty(ref maritalStatus, value);
    }
    
    public string Blood
    {
        get => bloodType;
        set => SetProperty(ref bloodType, value);
    }

    public string Dentist
    {
        get => dentist_responsible;
        set
        {
            if (dentist_responsible != value)
            {
                dentist_responsible = value;
                OnPropertyChanged();
            }
        }
    }
    
    public AfiliacionViewModel(Person paciente)
    {
        Direction = paciente.Direction;
        
        PostCode = paciente.PostCode;
        
        Population = paciente.Population;
        
        Province = paciente.Province;
        
        Country = paciente.Country;
        
        Document_number = paciente.Document_number;
        
        Telephone = paciente.Telephone;
        
        PhoneNumber = paciente.PhoneNumber;
        
        Email = paciente.Email;

        Sex = paciente.Sex;
        
        BirthDate = paciente.BirthDate;
        
        MaritalStatus = paciente.MaritalStatus;
        
        Blood = paciente.BloodType;

        Dentist = paciente.DentistResponsible;

    }
    
    [RelayCommand]
    async Task UpdatePatient()
    {
        var connector = new Mongo("mongodb://admin:12345678@34.155.217.86:27017/", "SmileDent");
        
        var patientDb = connector.GetPatientCollection();

        var filter = Builders<Patient>.Filter.Eq(p => p.documentNumber, Document_number);

        var update = Builders<Patient>.Update.Set(p => p.workNumber, WorkNumber).Set(p =>p.postCode, PostCode)
            .Set(p => p.direction, Direction)
            .Set(p => p.city, Population)
            .Set(p => p.housePhone, Telephone)
            .Set(p => p.dentistInCharge, Dentist);

        var updateResult = await patientDb.UpdateOneAsync(filter, update);

    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    public virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}