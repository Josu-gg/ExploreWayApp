using ExploreWayApp.DTOs.DestinoActividad;

namespace ExploreWayApp.Servicios.DestinoActividad;

public interface IDestinoActividadService
{
    Task<List<DestinoActividadSalida>> ListarAsync();
    Task<DestinoActividadSalida?> ObtenerAsync(int id);
    Task<DestinoActividadSalida?> CrearAsync(DestinoActividadGuardar dto);
    Task<DestinoActividadSalida?> ModificarAsync(int id, DestinoActividadModificar dto);
}
