using System.ComponentModel.DataAnnotations;
namespace ExploreWayApp.DTOs.DestinoActividad
{
    public class DestinoActividadModificar
    {
        [Required(ErrorMessage = "La duración es obligatoria.")]
        [Range(1, 1439, ErrorMessage = "La duración debe estar entre 1 y 1439 minutos.")]
        public int? DuracionMinutos { get; set; }

        [Required(ErrorMessage = "El precio base es obligatorio.")]
        [Range(typeof(decimal), "0.00", "99999999.99", ErrorMessage = "El precio base no puede ser negativo (máx. 8 enteros y 2 decimales).")]
        public decimal? PrecioBase { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El estado no es válido.")]
        public int? IdEstado { get; set; }
    }
}
