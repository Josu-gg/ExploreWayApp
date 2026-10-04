using ExploreWayApp.DTOs.ImagenDestino;

namespace ExploreWayApp.Servicios.ImagenDestino;

public interface IImagenDestinoService
{
    Task<List<ImagenDestinoSalida>> ListarPorDestinoAsync(int idDestino);
    Task<ImagenDestinoSalida?> AgregarAsync(int idDestino, ImagenDestinoGuardar dto);
    Task<ImagenDestinoSalida?> ActualizarDescripcionAsync(int idDestino, int idImagen, ImagenDestinoModificar dto);
    Task<ImagenDestinoSalida?> MarcarPrincipalAsync(int idDestino, int idImagen);
    Task EliminarAsync(int idDestino, int idImagen);
}
