using ExploreWayApp.DTOs.Comun;
using ExploreWayApp.DTOs.reserva;

namespace ExploreWayApp.Servicios.Reserva;

public interface IReservaService
{
    Task<List<ReservaSalida>> ListarAsync();
    // Agenda del guía autenticado (la API solo la entrega a su dueño o al Admin).
    Task<List<ReservaSalida>> ListarPorGuiaAsync(int idGuia);
    // Historial del cliente autenticado (la API solo lo entrega a su dueño o al Admin).
    Task<List<ReservaSalida>> ListarPorClienteAsync(int idCliente);
    Task<ReservaSalida?> CrearAsync(ReservaGuardar dto);
    Task<ReservaSalida?> CambiarEstadoAsync(int id, CambioEstadoModificar dto);
    Task<ReservaSalida?> CancelarAsync(int id);
    Task<List<ClienteResumen>> ListarClientesAsync();
}
