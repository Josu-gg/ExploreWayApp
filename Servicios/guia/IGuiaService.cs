using ExploreWayApp.DTOs.guia;

namespace ExploreWayApp.Servicios.Guia;

public interface IGuiaService
{
    Task<List<GuiaSalida>> ListarAsync();
    Task<GuiaSalida?> BuscarPorIdAsync(int id);
    Task<GuiaSalida?> RegistrarAsync(GuiaRegistroGuardar dto);
    Task<GuiaSalida?> ModificarAsync(int id, GuiaModificar dto);
    Task EliminarAsync(int id);
}
