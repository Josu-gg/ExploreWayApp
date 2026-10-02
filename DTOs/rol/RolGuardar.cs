using System.ComponentModel.DataAnnotations;

namespace ExploreWayApp.DTOs.Rol;

public class RolGuardar
{
    [Required(ErrorMessage = "El nombre del rol es obligatorio.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres.")]
    public string NombreRol { get; set; } = string.Empty;

    [Required(ErrorMessage = "Debe seleccionar un estado.")]
    public int? IdEstado { get; set; }
}
