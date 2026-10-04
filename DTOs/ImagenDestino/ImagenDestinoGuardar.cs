using System.ComponentModel.DataAnnotations;

namespace ExploreWayApp.DTOs.ImagenDestino
{
    public class ImagenDestinoGuardar
    {
        [Required(ErrorMessage = "La URL de la imagen es obligatoria.")]
        [StringLength(500, ErrorMessage = "La URL no puede superar los 500 caracteres.")]
        [RegularExpression(@"^https://\S+$", ErrorMessage = "La URL debe ser válida y usar https.")]
        public string UrlImagen { get; set; } = string.Empty;

        [StringLength(255, ErrorMessage = "La descripción no puede superar los 255 caracteres.")]
        public string? Descripcion { get; set; }

        public bool? EsPrincipal { get; set; }
    }
}
