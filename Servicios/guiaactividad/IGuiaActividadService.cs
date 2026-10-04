using ExploreWayApp.DTOs.GuiaActividad;

namespace ExploreWayApp.Servicios.GuiaActividad;

public interface IGuiaActividadService
{
    Task<List<GuiaActividadSalida>> ListarAsync();
    Task<GuiaActividadSalida?> CrearAsync(GuiaActividadGuardar dto);
    Task<GuiaActividadSalida?> ModificarAsync(int id, GuiaActividadModificar dto);
    Task EliminarAsync(int id);
}
