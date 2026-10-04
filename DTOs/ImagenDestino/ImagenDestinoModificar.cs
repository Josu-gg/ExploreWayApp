using System.ComponentModel.DataAnnotations;

namespace ExploreWayApp.DTOs.ImagenDestino
{
    public class ImagenDestinoModificar
    {
        [StringLength(255, ErrorMessage = "La descripción no puede superar los 255 caracteres.")]
        public string? Descripcion { get; set; }
    }
}
