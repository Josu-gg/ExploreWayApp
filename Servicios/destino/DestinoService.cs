using ExploreWayApp.DTOs.Destino;
using System.Net.Http.Json;

namespace ExploreWayApp.Servicios.Destino;

// El BaseUrl ya termina en "/api/", por eso las rutas son relativas sin el prefijo "api/".
public sealed class DestinoService(HttpClient http) : IDestinoService
{
    private const string Url = "destinos";
    private const string UrlEstados = "estados";

    public async Task<List<DestinoSalidaDto>> ListarAsync() =>
        await LeerAsync<List<DestinoSalidaDto>>(Url) ?? [];

    public Task<DestinoSalidaDto?> BuscarPorIdAsync(int id) =>
        LeerAsync<DestinoSalidaDto>($"{Url}/{id}");

    public async Task<List<DestinoSalidaDto>> ListarPorEstadoAsync(int idEstado) =>
        await LeerAsync<List<DestinoSalidaDto>>($"{Url}/estado/{idEstado}") ?? [];

    public async Task<List<EstadoSalidaDto>> ListarEstadosAsync() =>
        await LeerAsync<List<EstadoSalidaDto>>(UrlEstados) ?? [];

    public async Task GuardarAsync(DestinoGuardarDto dto) =>
        await RespuestaApi.ValidarAsync(await http.PostAsJsonAsync(Url, dto));

    public async Task ModificarAsync(int id, DestinoModificarDto dto) =>
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
