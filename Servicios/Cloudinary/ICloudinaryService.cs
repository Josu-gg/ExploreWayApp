namespace ExploreWayApp.Servicios.Imagenes;

public interface ICloudinaryService
{
    // Sube la imagen a Cloudinary y devuelve su URL https segura.
    Task<string> SubirImagenDestinoAsync(Stream contenido, string nombreArchivo, int idDestino);
}
