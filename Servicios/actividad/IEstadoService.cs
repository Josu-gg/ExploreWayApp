using ExploreWayApp.DTOs;
using ExploreWayApp.DTOs.actividad;
namespace ExploreWayApp.Servicios.actividad
{
    public interface IEstadoService
    {
        Task<List<EstadoSalida>> ListarAsync();
    }
}
