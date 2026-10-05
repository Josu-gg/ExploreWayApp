using ExploreWayApp.DTOs.Resena;

namespace ExploreWayApp.Servicios.Resena;

public sealed class ResenaService(HttpClient http) : IResenaService
{
    private const string Url = "resenas";

    public Task<List<ResenaSalida>> ListarPorGuiaAsync(int idGuia) =>
        http.LeerTodasLasPaginasAsync<ResenaSalida>($"{Url}/guia/{idGuia}");
}
