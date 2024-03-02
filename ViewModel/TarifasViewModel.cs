using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MongoDB.Driver;
using SmileDent.View;

namespace SmileDent.ViewModel;

public class TarifasViewModel : ObservableObject, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    public virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    private string _tariffName;
    private int _tariffCode;
    private string _insurance;
    private int _insuranceNumber;
    private int _cardNumber;
    private DateTime _inactiveRecord;
    private DateTime _expirationDate;
    private DateTime _activeRecord;
    
    
    public string TariffName
    {
        get { return _tariffName; }
        set
        {
            _tariffName = value;
            OnPropertyChanged(nameof(TariffName));
        }
    }

    public int TariffCode
    {
        get { return _tariffCode; }
        set
        {
            _tariffCode = value;
            OnPropertyChanged(nameof(TariffCode));
        }
    }

    public string Insurance
    {
        get { return _insurance; }
        set
        {
            _insurance = value;
            OnPropertyChanged(nameof(Insurance));
        }
    }

    public int InsuranceNumber
    {
        get { return _insuranceNumber; }
        set
        {
            _insuranceNumber = value;
            OnPropertyChanged(nameof(InsuranceNumber));
        }
    }

    public int CardNumber
    {
        get { return _cardNumber; }
        set
        {
            _cardNumber = value;
            OnPropertyChanged(nameof(CardNumber));
        }
    }

    public DateTime InactiveRecord
    {
        get { return _inactiveRecord; }
        set
        {
            _inactiveRecord = value;
            OnPropertyChanged(nameof(InactiveRecord));
        }
    }

    public DateTime ExpirationDate
    {
        get { return _expirationDate; }
        set
        {
            _expirationDate = value;
            OnPropertyChanged(nameof(ExpirationDate));
        }
    }

    public DateTime ActiveRecord
    {
        get { return _activeRecord; }
        set
        {
            _activeRecord = value;
            OnPropertyChanged(nameof(ActiveRecord));
        }
    }

    public TarifasViewModel(Person paciente)
    {
        Tariffdata(paciente);
    }
    
     private async Task Tariffdata(Person paciente)
    {
        var connector = new Mongo("mongodb://admin:12345678@34.155.217.86:27017/", "SmileDent");
        var tariffCollection = connector.GetTariffCollection();

        var filter = Builders<Tariff>.Filter.Eq(u => u.user, paciente.Document_number);
        var user = await tariffCollection.Find(filter).FirstOrDefaultAsync();
        
        TariffName = user.tariff;
        TariffCode = user.GetHashCode();
        Insurance = user.insuranceCompany;
        InsuranceNumber = user.insuranceNumber;
        CardNumber = user.GetHashCode();
        InactiveRecord = user.inactiveRecord;
        ExpirationDate = user.expiringTariff;
        ActiveRecord = user.activeTariff;
    }
    
}