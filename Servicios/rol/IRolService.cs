using ExploreWayApp.DTOs.Rol;

namespace ExploreWayApp.Servicios.Rol;

public interface IRolService
{
    Task<List<RolSalida>> ListarAsync();
    Task<RolSalida?> BuscarPorIdAsync(int id);
    Task GuardarAsync(RolGuardar dto);
    Task ModificarAsync(int id, RolModificar dto);
    Task EliminarAsync(int id);
}
