using ExploreWayApp.DTOs.DisponibilidadGuia;

namespace ExploreWayApp.Servicios.DisponibilidadGuia;

public sealed class DisponibilidadGuiaService(HttpClient http) : IDisponibilidadGuiaService
{
    private const string Url = "guia-disponibilidades";

    public Task<List<DisponibilidadGuiaSalida>> ListarPorGuiaAsync(int idGuia) =>
        http.LeerTodasLasPaginasAsync<DisponibilidadGuiaSalida>($"{Url}/guia/{idGuia}");

    public Task<DisponibilidadGuiaSalida?> CrearAsync(DisponibilidadGuiaGuardar dto) =>
        http.EnviarAsync<DisponibilidadGuiaSalida>(HttpMethod.Post, Url, dto);

    public Task<DisponibilidadGuiaSalida?> ModificarAsync(int id, DisponibilidadGuiaModificar dto) =>
        http.EnviarAsync<DisponibilidadGuiaSalida>(HttpMethod.Put, $"{Url}/{id}", dto);

    public Task EliminarAsync(int id) =>
        http.EnviarAsync(HttpMethod.Delete, $"{Url}/{id}");
}
