using System.ComponentModel.DataAnnotations;

namespace ExploreWayApp.DTOs.DisponibilidadGuia;

public class DisponibilidadGuiaGuardar
{
    [Required(ErrorMessage = "El guía es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "El guía no es válido.")]
    public int? IdGuia { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria.")]
    public DateOnly? Fecha { get; set; }

    [Required(ErrorMessage = "La hora de inicio es obligatoria.")]
    public TimeOnly? HoraInicio { get; set; }

    [Required(ErrorMessage = "La hora de fin es obligatoria.")]
    public TimeOnly? HoraFin { get; set; }
}
