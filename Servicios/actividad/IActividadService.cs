using ExploreWayApp.DTOs;
using ExploreWayApp.DTOs.actividad;

namespace ExploreWayApp.Servicios.actividad
{
    public interface IActividadService
    {
        Task<PaginaResultado<ActividadSalida>> ListarAsync(int pagina, int tamano);
        Task<ActividadSalida> ObtenerAsync(int id);
        Task<ActividadSalida> CrearAsync(ActividadGuardar actividad);
        Task<ActividadSalida> ModificarAsync(int id, ActividadGuardar actividad);
        Task EliminarAsync(int id);
    }
}
