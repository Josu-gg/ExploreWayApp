using System.Net.Http.Json;
using ExploreWayApp.DTOs.Rol;

namespace ExploreWayApp.Servicios.Rol;

// El BaseUrl ya termina en "/api/", por eso la ruta es relativa.
public sealed class RolService(HttpClient http) : IRolService
{
    private const string Url = "roles";

    public async Task<List<RolSalida>> ListarAsync() =>
        await LeerAsync<List<RolSalida>>(Url) ?? [];

    public Task<RolSalida?> BuscarPorIdAsync(int id) =>
        LeerAsync<RolSalida>($"{Url}/{id}");

    public async Task GuardarAsync(RolGuardar dto) =>
        await RespuestaApi.ValidarAsync(await http.PostAsJsonAsync(Url, dto));

    public async Task ModificarAsync(int id, RolModificar dto) =>
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
