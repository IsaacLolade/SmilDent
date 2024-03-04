using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmileDent.ViewModel;


public class Mongo
{

    public IMongoClient client;
    public IMongoDatabase db ;

    public Mongo(string connecttion, string database)
    {
        client = new MongoClient(connecttion);
         db = client.GetDatabase(database);

    }

    public IMongoDatabase GetDatabase()
    {
        return db;
    }

    public IMongoCollection<Staff> GetStaffCollection()
    {
        return db.GetCollection<Staff>("Staff");
    }

    public IMongoCollection<Patient> GetPatientCollection()
    {
        return db.GetCollection<Patient>("Patient");
    }

    public IMongoCollection<Tariff> GetTariffCollection()
    {
        return db.GetCollection<Tariff>("Tariff");
    }
    
    public IMongoCollection<MedicalHistory> GetMedicalHistory()
    {
        return db.GetCollection<MedicalHistory>("MedicalHistory");
    }
    
    public IMongoCollection<Alerts> GetAlertsCollection()
    {
        return db.GetCollection<Alerts>("Alerts");
    }
    
    public IMongoCollection<Appointment> GetAppointmentCollection()
    {
        return db.GetCollection<Appointment>("Appointments");
    }
}

public class Staff
{
    public ObjectId Id { get; set; }
    public string username { get; set; }
    public string passwd { get; set; }
}

public class Patient
{
    
    public ObjectId Id { get; set; }
    
    public string dentistInCharge { get; set; }
    public string historyNumber { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public string documentType { get; set; }
    public string documentNumber { get; set; }
    public DateTime birthDate { get; set; }
    public int postCode { get; set; }
    public string direction { get; set; }
    public string city { get; set; }
    public string population { get; set; }
    public string country { get; set; }
    public int housePhone { get; set; }
    public int workNumber { get; set; }
    public int phoneNumber { get; set; }
    public string email { get; set; }
    public string sex { get; set; }
    public string bloddtype { get; set; }
    public string maritalStatus { get; set; }
}


public class Tariff
{
    public ObjectId Id { get; set; }
    
    public string user { get; set; }
    public string insuranceCompany { get; set; }
    public string tariff { get; set; }
    public int insuranceNumber { get; set; }
    public string defaultTariff { get; set; }
    public DateTime inactiveRecord { get; set; }
    public DateTime activeTariff { get; set; }
    public DateTime expiringTariff { get; set; }
}

public class MedicalHistory
{
    public ObjectId Id {get; set; }
    public string user { get; set; }
    public string medicalReport { get; set; }
}


public class Alerts
{
    public ObjectId Id {get; set; }
    public string user { get; set; }
    public string alert { get; set; }
}

public class Appointment
{

    public ObjectId Id { get; set; }

    public DateTime EventStart { get; set; }
    public DateTime EventEnd { get; set; }
    public string Name { get; set; }
    public string Dentist { get; set; }
    public int Seat { get; set; }
}
