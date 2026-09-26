using ExploreWayApp.DTOs.Auth;
namespace ExploreWayApp.Servicios
{
    public interface IAuthService
    {
        Task IniciarSesionAsync(LoginGuardar credenciales);
        Task RegistrarClienteAsync(RegistroClienteGuardar datos);
        void CerrarSesion();
    }
}
