using System.ComponentModel.DataAnnotations;

namespace ExploreWayApp.DTOs.Estado;

public class EstadoGuardar
{
    [Required(ErrorMessage = "El nombre del estado es obligatorio.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres.")]
    public string NombreEstado { get; set; } = string.Empty;

    [Required(ErrorMessage = "El tipo de estado es obligatorio.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "El tipo debe tener entre 3 y 50 caracteres.")]
    public string TipoEstado { get; set; } = string.Empty;
}