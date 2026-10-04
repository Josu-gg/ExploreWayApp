using System.ComponentModel.DataAnnotations;
namespace ExploreWayApp.DTOs.GuiaActividad
{
    public class GuiaActividadGuardar
    {
        [Required(ErrorMessage = "El guía es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El guía no es válido.")]
        public int? IdGuia { get; set; }

        [Required(ErrorMessage = "La actividad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La actividad no es válida.")]
        public int? IdActividad { get; set; }
    }
}
