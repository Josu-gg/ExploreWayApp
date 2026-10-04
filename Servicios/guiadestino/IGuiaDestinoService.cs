using ExploreWayApp.DTOs.Comun;
using ExploreWayApp.DTOs.GuiaDestino;

namespace ExploreWayApp.Servicios.GuiaDestino;

public interface IGuiaDestinoService
{
    Task<List<GuiaDestinoSalida>> ListarAsync();
    Task<GuiaDestinoSalida?> CrearAsync(GuiaDestinoGuardar dto);
    Task<GuiaDestinoSalida?> ModificarAsync(int id, CambioEstadoModificar dto);
    Task EliminarAsync(int id);
}
