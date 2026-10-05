using ExploreWayApp.DTOs.guia;

namespace ExploreWayApp.Servicios.Guia;

public interface IGuiaService
{
    Task<List<GuiaSalida>> ListarAsync();
    Task<GuiaSalida?> BuscarPorIdAsync(int id);
    Task<GuiaSalida?> BuscarPorPersonaAsync(int idPersona);
    // El guía autenticado edita su propio perfil (PUT guias/mi-perfil).
    Task<GuiaSalida?> ModificarMiPerfilAsync(GuiaPerfilModificar dto);
    Task<GuiaSalida?> RegistrarAsync(GuiaRegistroGuardar dto);
    Task<GuiaSalida?> ModificarAsync(int id, GuiaModificar dto);
    Task EliminarAsync(int id);
}
