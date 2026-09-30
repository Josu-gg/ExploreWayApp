using ExploreWayApp.DTOs.actividad;

namespace ExploreWayApp.Servicios.actividad
{
    public class EstadoService(HttpClient http) : IEstadoService
    {
        // El BaseUrl ya termina en "/api/". El endpoint devuelve un arreglo simple.
        public async Task<List<EstadoSalida>> ListarAsync() =>
            (await (await http.GetAsync("estados")).LeerAsync<List<EstadoSalida>>()) ?? [];
    }
}
