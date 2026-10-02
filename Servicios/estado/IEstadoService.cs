using ExploreWayApp.DTOs.Estado;

namespace ExploreWayApp.Servicios.Estado;

public interface IEstadoService
{
    Task<List<EstadoSalida>> ListarAsync();
    Task<EstadoSalida?> BuscarPorIdAsync(int id);
    Task GuardarAsync(EstadoGuardar dto);
    Task ModificarAsync(int id, EstadoModificar dto);
    Task EliminarAsync(int id);
}
