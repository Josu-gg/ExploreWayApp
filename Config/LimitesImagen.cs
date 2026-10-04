namespace ExploreWayApp.Config;

// Límites de la galería de un destino en la interfaz (la API admite hasta 10).
public static class LimitesImagen
{
    public const int MaximoPorDestino = 5;
    public const long TamanoMaximoBytes = 5 * 1024 * 1024;
}
