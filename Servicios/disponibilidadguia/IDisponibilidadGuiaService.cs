using ExploreWayApp.DTOs.DisponibilidadGuia;

namespace ExploreWayApp.Servicios.DisponibilidadGuia;

public interface IDisponibilidadGuiaService
{
    // Franjas vigentes del guía (activas y desde hoy).
    Task<List<DisponibilidadGuiaSalida>> ListarPorGuiaAsync(int idGuia);
    Task<DisponibilidadGuiaSalida?> CrearAsync(DisponibilidadGuiaGuardar dto);
    Task<DisponibilidadGuiaSalida?> ModificarAsync(int id, DisponibilidadGuiaModificar dto);
    Task EliminarAsync(int id);
}
