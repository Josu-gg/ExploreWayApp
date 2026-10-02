using System.Net.Http.Json;
using ExploreWayApp.DTOs.Estado;

namespace ExploreWayApp.Servicios.Estado;

// El BaseUrl ya termina en "/api/", por eso la ruta es relativa.
public sealed class EstadoService(HttpClient http) : IEstadoService
{
    private const string Url = "estados";

    public async Task<List<EstadoSalida>> ListarAsync() =>
        await LeerAsync<List<EstadoSalida>>(Url) ?? [];

    public Task<EstadoSalida?> BuscarPorIdAsync(int id) =>
        LeerAsync<EstadoSalida>($"{Url}/{id}");

    public async Task GuardarAsync(EstadoGuardar dto) =>
        await RespuestaApi.ValidarAsync(await http.PostAsJsonAsync(Url, dto));

    public async Task ModificarAsync(int id, EstadoModificar dto) =>
        await RespuestaApi.ValidarAsync(await http.PutAsJsonAsync($"{Url}/{id}", dto));

    public async Task EliminarAsync(int id) =>
        await RespuestaApi.ValidarAsync(await http.DeleteAsync($"{Url}/{id}"));

    private async Task<T?> LeerAsync<T>(string ruta)
    {
        var respuesta = await http.GetAsync(ruta);
        await RespuestaApi.ValidarAsync(respuesta);
        return await respuesta.Content.ReadFromJsonAsync<T>();
    }
}
