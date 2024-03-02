using SmileDent.ViewModel;

namespace SmileDent.View;

public partial class Afiliacion : ContentPage
{
    public Afiliacion()
    {
        InitializeComponent();
        
    }
    
    //Obetener persona del que vamos a tratar
    public Person Persona { get; set; }
    
    private  async void Button_OnClicked(object? sender, EventArgs e)
    {
        try
        {
             
            // Abre el selector de archivos
            var foto = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Añada la foto del usuario",
                FileTypes = FilePickerFileType.Images
            
            });

            // Verifica si el archivo seleccionado es una imagen
            if (foto.FileName.EndsWith(".jpg") || foto.FileName.EndsWith(".png"))
            {
                var stream = await foto.OpenReadAsync();
                ImageUpload.Source = ImageSource.FromStream(()=>stream);
            }
            else
            {
                // Muestra un mensaje de alerta
                await DisplayAlert("Alerta", "El archivo seleccionado no es una imagen", "OK");
            }
            {
            
            }
        }catch(Exception ex)
        {
            // Muestra un mensaje de alerta
            await DisplayAlert("Alerta", "Error al cargar la imagen", "OK");
        }
    }
}