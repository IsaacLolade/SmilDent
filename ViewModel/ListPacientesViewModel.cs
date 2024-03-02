using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;
using SmileDent.View;

namespace SmileDent.ViewModel;

public partial class ListPacientesViewModel :  ObservableObject, INotifyPropertyChanged
{
    private ObservableCollection<List<Person>> _list;
    
    private List<Person> _patients;

    public List<Person> Patients
    {
        get { return _patients; }
        set
        {
            _patients = value;
            OnPropertyChanged(nameof(Patients));
        }
    }
    

    // Creacion de la lista de pacientes
    public ListPacientesViewModel()
    {
        
        var connector = new Mongo("mongodb://admin:12345678@34.155.217.86:27017/", "SmileDent");

        var patientDb = connector.GetPatientCollection();
        
        List<Patient> lst = patientDb.Find(d => true) .ToList();
        Patients = lst.Select(patient => new Person
        {
            Name = patient.name,
            Surname = patient.surname,
            Document_number = patient.documentNumber,
            PostCode = patient.postCode,
            Sex = patient.sex,
            BloodType = patient.bloddtype,
            Telephone = patient.housePhone,
            PhoneNumber = patient.phoneNumber,
            Email = patient.email,
            Direction = patient.direction,
            BirthDate = patient.birthDate,
            Population = patient.city,
            Province = patient.population,
            Country = patient.country,
            MaritalStatus = patient.maritalStatus,
            DentistResponsible = patient.dentistInCharge
            
        }).ToList();
        
    }
    
}