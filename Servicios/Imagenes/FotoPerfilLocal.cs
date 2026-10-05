using System.Text.Json;

namespace ExploreWayApp.Servicios.Imagenes;

// Respaldo local de la URL de la foto de perfil (IdPersona -> URL de Cloudinary) para cuando la API
// no la devuelve. Se guarda en App_Data/fotos-perfil.json del servidor Blazor.
public sealed class FotoPerfilLocal(IWebHostEnvironment entorno)
{
    private readonly string _ruta = Path.Combine(entorno.ContentRootPath, "App_Data", "fotos-perfil.json");
    private readonly object _candado = new();

    public string? Obtener(int idPersona)
    {
        lock (_candado)
            return Leer().TryGetValue(idPersona, out var url) ? url : null;
    }

    public void Guardar(int idPersona, string? url)
    {
        lock (_candado)
        {
            var datos = Leer();
            if (string.IsNullOrWhiteSpace(url)) datos.Remove(idPersona);
            else datos[idPersona] = url;

            Directory.CreateDirectory(Path.GetDirectoryName(_ruta)!);
            File.WriteAllText(_ruta, JsonSerializer.Serialize(datos));
        }
    }

    private Dictionary<int, string> Leer()
    {
        try
        {
            return File.Exists(_ruta)
                ? JsonSerializer.Deserialize<Dictionary<int, string>>(File.ReadAllText(_ruta)) ?? []
                : [];
        }
        catch (Exception ex) when (ex is IOException or JsonException)
        {
            return [];
        }
    }
}
