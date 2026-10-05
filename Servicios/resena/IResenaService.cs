using ExploreWayApp.DTOs.Resena;

namespace ExploreWayApp.Servicios.Resena;

public interface IResenaService
{
    Task<List<ResenaSalida>> ListarPorGuiaAsync(int idGuia);
}
