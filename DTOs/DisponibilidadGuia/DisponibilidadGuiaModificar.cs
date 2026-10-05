using System.ComponentModel.DataAnnotations;

namespace ExploreWayApp.DTOs.DisponibilidadGuia;

public class DisponibilidadGuiaModificar
{
    [Required(ErrorMessage = "La fecha es obligatoria.")]
    public DateOnly? Fecha { get; set; }

    [Required(ErrorMessage = "La hora de inicio es obligatoria.")]
    public TimeOnly? HoraInicio { get; set; }

    [Required(ErrorMessage = "La hora de fin es obligatoria.")]
    public TimeOnly? HoraFin { get; set; }

    [Required(ErrorMessage = "El estado es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "El estado no es válido.")]
    public int? IdEstado { get; set; }
}
