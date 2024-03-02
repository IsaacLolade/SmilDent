using SmileDent.View;

namespace SmileDent.View;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(InciarSesion),typeof(InciarSesion));
        Routing.RegisterRoute(nameof(Main),typeof(Main));
        Routing.RegisterRoute(nameof(VistaPacientes),typeof(VistaPacientes));
        Routing.RegisterRoute(nameof(Agenda),typeof(Agenda));
        Routing.RegisterRoute(nameof(CreacionPacientes),typeof(CreacionPacientes));
        Routing.RegisterRoute(nameof(Tarifas),typeof(Tarifas));
        Routing.RegisterRoute(nameof(Afiliacion),typeof(Afiliacion));
      
    }
}