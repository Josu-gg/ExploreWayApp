using ExploreWayApp.DTOs.Comun;
using ExploreWayApp.DTOs.GuiaDestino;

namespace ExploreWayApp.Servicios.GuiaDestino;

public interface IGuiaDestinoService
{
    Task<List<GuiaDestinoSalida>> ListarAsync();
    Task<List<GuiaDestinoSalida>> ListarPorGuiaAsync(int idGuia);
    // Guías activos y disponibles de un destino. Es público (no requiere sesión), a diferencia de ListarAsync.
    Task<List<GuiaDestinoSalida>> ListarPorDestinoAsync(int idDestino);
    Task<GuiaDestinoSalida?> CrearAsync(GuiaDestinoGuardar dto);
    Task<GuiaDestinoSalida?> ModificarAsync(int id, CambioEstadoModificar dto);
    Task EliminarAsync(int id);
}
