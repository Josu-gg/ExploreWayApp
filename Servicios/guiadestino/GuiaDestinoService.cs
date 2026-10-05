using ExploreWayApp.DTOs.Comun;
using ExploreWayApp.DTOs.GuiaDestino;

namespace ExploreWayApp.Servicios.GuiaDestino;

public sealed class GuiaDestinoService(HttpClient http) : IGuiaDestinoService
{
    private const string Url = "guia-destinos";

    public Task<List<GuiaDestinoSalida>> ListarAsync() =>
        http.LeerTodasLasPaginasAsync<GuiaDestinoSalida>(Url);

    public async Task<List<GuiaDestinoSalida>> ListarPorGuiaAsync(int idGuia) =>
        await http.LeerAsync<List<GuiaDestinoSalida>>($"{Url}/guia/{idGuia}") ?? [];

    public Task<GuiaDestinoSalida?> CrearAsync(GuiaDestinoGuardar dto) =>
        http.EnviarAsync<GuiaDestinoSalida>(HttpMethod.Post, Url, dto);

    public Task<GuiaDestinoSalida?> ModificarAsync(int id, CambioEstadoModificar dto) =>
        http.EnviarAsync<GuiaDestinoSalida>(HttpMethod.Put, $"{Url}/{id}", dto);

    public Task EliminarAsync(int id) =>
        http.EnviarAsync(HttpMethod.Delete, $"{Url}/{id}");
}
