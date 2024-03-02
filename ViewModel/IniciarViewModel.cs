using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Driver;
using SmileDent.View;

namespace SmileDent.ViewModel;

public partial class IniciarViewModel : ObservableObject
{
    
    private string _username;
    private string _passwd;
    

    public string Username
    {
        get => _username;
        set
        {
            if (_username != value)
            {
                _username = value;
                OnPropertyChanged();
            }
        }
    }
    

    public string Passwd
    {
        get => _passwd;
        set
        {
            if (_passwd != value)
            {
                _passwd = value;
                OnPropertyChanged();
            }
            
        }
    }
    [RelayCommand]
    async Task Navigate()
    {
        try
        {
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Passwd))
            {
                var connector = new Mongo("mongodb://admin:12345678@34.155.217.86:27017/", "SmileDent");
                var staffCollection = connector.GetStaffCollection();

                var filter = Builders<Staff>.Filter.Eq(u => u.username, Username) &
                             Builders<Staff>.Filter.Eq(u => u.passwd, Passwd);
                var user = await staffCollection.Find(filter).FirstOrDefaultAsync();

                if (user != null)
                {
                    await Shell.Current.GoToAsync(nameof(Main));
                }
                else
                {
                    MessagingCenter.Send(this, "DisplayAlert", "El usuario introducido no existe");
                }
            }
            else
            {
                MessagingCenter.Send(this, "DisplayAlert", "Debes rellenar los campos vacios");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception during navigation: {ex}");
            MessagingCenter.Send(this, "DisplayAlert", "Error during navigation");
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}