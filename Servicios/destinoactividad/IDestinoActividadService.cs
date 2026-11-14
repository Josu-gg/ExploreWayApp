using ExploreWayApp.DTOs.DestinoActividad;

namespace ExploreWayApp.Servicios.DestinoActividad;

public interface IDestinoActividadService
{
    Task<List<DestinoActividadSalida>> ListarAsync();
    // Ofertas activas de un destino. Es público (no requiere sesión), a diferencia de ListarAsync.
    Task<List<DestinoActividadSalida>> ListarPorDestinoAsync(int idDestino);
    Task<DestinoActividadSalida?> ObtenerAsync(int id);
    Task<DestinoActividadSalida?> CrearAsync(DestinoActividadGuardar dto);
    Task<DestinoActividadSalida?> ModificarAsync(int id, DestinoActividadModificar dto);
}
