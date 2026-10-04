using ExploreWayApp.DTOs.guia;

namespace ExploreWayApp.Servicios.Guia;

// Un guía nace de un registro completo (persona + usuario + guía): POST guias/registro.
public sealed class GuiaService(HttpClient http) : IGuiaService
{
    private const string Url = "guias";

    public async Task<List<GuiaSalida>> ListarAsync() =>
        await http.LeerAsync<List<GuiaSalida>>(Url) ?? [];

    public Task<GuiaSalida?> BuscarPorIdAsync(int id) =>
        http.LeerAsync<GuiaSalida>($"{Url}/{id}");

    public Task<GuiaSalida?> RegistrarAsync(GuiaRegistroGuardar dto) =>
        http.EnviarAsync<GuiaSalida>(HttpMethod.Post, $"{Url}/registro", dto);

    public Task<GuiaSalida?> ModificarAsync(int id, GuiaModificar dto) =>
        http.EnviarAsync<GuiaSalida>(HttpMethod.Put, $"{Url}/{id}", dto);

    public Task EliminarAsync(int id) =>
        http.EnviarAsync(HttpMethod.Delete, $"{Url}/{id}");
}
