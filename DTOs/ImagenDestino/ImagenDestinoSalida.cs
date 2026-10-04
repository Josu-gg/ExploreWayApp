namespace ExploreWayApp.DTOs.ImagenDestino
{
    public class ImagenDestinoSalida
    {
        public int IdImagen { get; set; }
        public string UrlImagen { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public bool EsPrincipal { get; set; }
    }
}
