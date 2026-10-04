
using System.ComponentModel.DataAnnotations;
namespace ExploreWayApp.DTOs.guia
{
    public class GuiaModificar
    {
        [StringLength(500, ErrorMessage = "La biografía no puede superar los 500 caracteres.")]
        public string? Biografia { get; set; }

        [StringLength(500, ErrorMessage = "La experiencia no puede superar los 500 caracteres.")]
        public string? Experiencia { get; set; }

        [StringLength(200, ErrorMessage = "Los estudios no pueden superar los 200 caracteres.")]
        public string? Estudios { get; set; }

        [Required(ErrorMessage = "Debe indicarse si tiene primeros auxilios.")]
        public bool? PrimerosAuxilios { get; set; }

        [Required(ErrorMessage = "Debe indicarse la disponibilidad.")]
        public bool? EstadoDisponibilidad { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El estado no es válido.")]
        public int? IdEstado { get; set; }
    }
}
