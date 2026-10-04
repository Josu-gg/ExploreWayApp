using ExploreWayApp.DTOs.DestinoActividad;

namespace ExploreWayApp.Servicios.DestinoActividad;

// No hay DELETE en la API: la baja es lógica, cambiando el estado con PUT.
public sealed class DestinoActividadService(HttpClient http) : IDestinoActividadService
{
    private const string Url = "destino-actividades";

    public Task<List<DestinoActividadSalida>> ListarAsync() =>
        http.LeerTodasLasPaginasAsync<DestinoActividadSalida>(Url);

    public Task<DestinoActividadSalida?> ObtenerAsync(int id) =>
        http.LeerAsync<DestinoActividadSalida>($"{Url}/{id}");

    public Task<DestinoActividadSalida?> CrearAsync(DestinoActividadGuardar dto) =>
        http.EnviarAsync<DestinoActividadSalida>(HttpMethod.Post, Url, dto);

    public Task<DestinoActividadSalida?> ModificarAsync(int id, DestinoActividadModificar dto) =>
        http.EnviarAsync<DestinoActividadSalida>(HttpMethod.Put, $"{Url}/{id}", dto);
}
