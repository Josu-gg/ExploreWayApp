using ExploreWayApp.DTOs.ImagenDestino;

namespace ExploreWayApp.Servicios.ImagenDestino;

// Las imágenes viven anidadas bajo su destino: destinos/{idDestino}/imagenes. Máximo 10 por destino.
public sealed class ImagenDestinoService(HttpClient http) : IImagenDestinoService
{
    private static string Url(int idDestino) => $"destinos/{idDestino}/imagenes";

    public async Task<List<ImagenDestinoSalida>> ListarPorDestinoAsync(int idDestino) =>
        await http.LeerAsync<List<ImagenDestinoSalida>>(Url(idDestino)) ?? [];

    public Task<ImagenDestinoSalida?> AgregarAsync(int idDestino, ImagenDestinoGuardar dto) =>
        http.EnviarAsync<ImagenDestinoSalida>(HttpMethod.Post, Url(idDestino), dto);

    public Task<ImagenDestinoSalida?> ActualizarDescripcionAsync(int idDestino, int idImagen, ImagenDestinoModificar dto) =>
        http.EnviarAsync<ImagenDestinoSalida>(HttpMethod.Put, $"{Url(idDestino)}/{idImagen}", dto);

    public Task<ImagenDestinoSalida?> MarcarPrincipalAsync(int idDestino, int idImagen) =>
        http.EnviarAsync<ImagenDestinoSalida>(new HttpMethod("PATCH"), $"{Url(idDestino)}/{idImagen}/principal");

    public Task EliminarAsync(int idDestino, int idImagen) =>
        http.EnviarAsync(HttpMethod.Delete, $"{Url(idDestino)}/{idImagen}");
}
