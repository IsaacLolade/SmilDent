using Microsoft.Extensions.Logging;
using SmileDent.View;
using SmileDent.ViewModel;
using Syncfusion.Maui.Core.Hosting;

namespace SmileDent;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.ConfigureSyncfusionCore();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });


        builder.Services.AddSingleton<InciarSesion>();
        builder.Services.AddSingleton<IniciarViewModel>();

        builder.Services.AddSingleton<Main>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddSingleton<VistaPacientes>();
        builder.Services.AddSingleton<ListPacientesViewModel>();

        builder.Services.AddSingleton<Agenda>();
        builder.Services.AddSingleton<AgendaViewModel>();

        builder.Services.AddSingleton<CreacionPacientes>();
        
        builder.Services.AddSingleton<Afiliacion>();
        builder.Services.AddSingleton<AfiliacionViewModel>();

        builder.Services.AddSingleton<Tarifas>();
        builder.Services.AddSingleton<TarifasViewModel>();
        
        return builder.Build();
    }
}