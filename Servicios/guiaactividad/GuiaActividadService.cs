using ExploreWayApp.DTOs.GuiaActividad;

namespace ExploreWayApp.Servicios.GuiaActividad;

public sealed class GuiaActividadService(HttpClient http) : IGuiaActividadService
{
    private const string Url = "guia-actividades";

    public Task<List<GuiaActividadSalida>> ListarAsync() =>
        http.LeerTodasLasPaginasAsync<GuiaActividadSalida>(Url);

    public Task<GuiaActividadSalida?> CrearAsync(GuiaActividadGuardar dto) =>
        http.EnviarAsync<GuiaActividadSalida>(HttpMethod.Post, Url, dto);

    public Task<GuiaActividadSalida?> ModificarAsync(int id, GuiaActividadModificar dto) =>
        http.EnviarAsync<GuiaActividadSalida>(HttpMethod.Put, $"{Url}/{id}", dto);

    public Task EliminarAsync(int id) =>
        http.EnviarAsync(HttpMethod.Delete, $"{Url}/{id}");
}
