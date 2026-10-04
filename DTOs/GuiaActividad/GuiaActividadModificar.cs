using System.ComponentModel.DataAnnotations;

namespace ExploreWayApp.DTOs.GuiaActividad
{
    public class GuiaActividadModificar
    {
        [Required(ErrorMessage = "El estado es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El estado no es válido.")]
        public int? IdEstado { get; set; }
    }
}
