namespace ExploreWayApp.Servicios.Imagenes;

public interface ICloudinaryService
{
    // Sube la imagen a Cloudinary y devuelve su URL https segura.
    Task<string> SubirImagenDestinoAsync(Stream contenido, string nombreArchivo, int idDestino);

    // Sube la foto de perfil de un guía y devuelve su URL https segura.
    Task<string> SubirFotoGuiaAsync(Stream contenido, string nombreArchivo);
}
