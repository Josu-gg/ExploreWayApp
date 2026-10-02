using ExploreWayApp.DTOs.Estado;
using ExploreWayApp.DTOs.Destino;

namespace ExploreWayApp.Servicios.Destino;

public interface IDestinoService
{
    Task<List<DestinoSalidaDto>> ListarAsync();
    Task<DestinoSalidaDto?> BuscarPorIdAsync(int id);
    Task<List<DestinoSalidaDto>> ListarPorEstadoAsync(int idEstado);
    Task<List<EstadoSalida>> ListarEstadosAsync();
    Task GuardarAsync(DestinoGuardarDto dto);
    Task ModificarAsync(int id, DestinoModificarDto dto);
    Task EliminarAsync(int id);
}
