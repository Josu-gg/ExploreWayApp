using ExploreWayApp.DTOs.Comun;
using ExploreWayApp.DTOs.reserva;

namespace ExploreWayApp.Servicios.Reserva;

public sealed class ReservaService(HttpClient http) : IReservaService
{
    private const string Url = "reservas";

    public Task<List<ReservaSalida>> ListarAsync() =>
        http.LeerTodasLasPaginasAsync<ReservaSalida>(Url);

    public Task<List<ReservaSalida>> ListarPorGuiaAsync(int idGuia) =>
        http.LeerTodasLasPaginasAsync<ReservaSalida>($"{Url}/guia/{idGuia}");

    public Task<ReservaSalida?> CrearAsync(ReservaGuardar dto) =>
        http.EnviarAsync<ReservaSalida>(HttpMethod.Post, Url, dto);

    // Confirmar o completar. Cancelar tiene su propia operación.
    public Task<ReservaSalida?> CambiarEstadoAsync(int id, CambioEstadoModificar dto) =>
        http.EnviarAsync<ReservaSalida>(HttpMethod.Put, $"{Url}/{id}/estado", dto);

    public Task<ReservaSalida?> CancelarAsync(int id) =>
        http.EnviarAsync<ReservaSalida>(new HttpMethod("PATCH"), $"{Url}/{id}/cancelacion");

    public Task<List<ClienteResumen>> ListarClientesAsync() =>
        http.LeerTodasLasPaginasAsync<ClienteResumen>("clientes");
}
