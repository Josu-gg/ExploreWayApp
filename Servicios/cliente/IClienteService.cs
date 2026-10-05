using ExploreWayApp.DTOs.Cliente;

namespace ExploreWayApp.Servicios.Cliente;

public interface IClienteService
{
    // Cliente del usuario autenticado (GET clientes/mi-perfil).
    Task<ClienteSalida?> ObtenerMiPerfilAsync();
    Task<ClienteSalida?> ModificarAsync(int id, ClienteModificar dto);
}
