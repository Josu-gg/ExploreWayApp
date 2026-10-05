using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ExploreWayApp.Config;
using Microsoft.Extensions.Options;

namespace ExploreWayApp.Servicios.Imagenes;

// Se usa el nombre de namespace "Imagenes" para no chocar con la clase Cloudinary del SDK.
public sealed class CloudinaryService(IOptions<CloudinaryOptions> opciones) : ICloudinaryService
{
    private readonly CloudinaryOptions _opciones = opciones.Value;

    public Task<string> SubirImagenDestinoAsync(Stream contenido, string nombreArchivo, int idDestino) =>
        SubirAsync(contenido, nombreArchivo, $"exploreway/destinos/{idDestino}");

    public Task<string> SubirFotoGuiaAsync(Stream contenido, string nombreArchivo) =>
        SubirAsync(contenido, nombreArchivo, "exploreway/guias");

    private async Task<string> SubirAsync(Stream contenido, string nombreArchivo, string carpeta)
    {
        if (!_opciones.EstaConfigurado)
            throw new InvalidOperationException("Cloudinary no está configurado. Revisá las credenciales del servidor.");

        var cloudinary = new Cloudinary(new Account(_opciones.CloudName, _opciones.ApiKey, _opciones.ApiSecret))
        {
            Api = { Secure = true }
        };

        var parametros = new ImageUploadParams
        {
            File = new FileDescription(nombreArchivo, contenido),
            Folder = carpeta,
            UseFilename = false,
            UniqueFilename = true,
            Overwrite = false
        };

        var resultado = await cloudinary.UploadAsync(parametros);
        if (resultado.Error is not null)
            throw new InvalidOperationException($"Cloudinary rechazó la imagen: {resultado.Error.Message}");

        return resultado.SecureUrl.ToString();
    }
}
