using System.ComponentModel.DataAnnotations;

namespace ExploreWayApp.DTOs.Destino;

public class DestinoGuardarDto
{
    [Required(ErrorMessage = "El nombre del destino es obligatorio")]
    [StringLength(150, ErrorMessage = "El nombre no puede superar los 150 caracteres")]
    public string Nombre { get; set; } = string.Empty;

    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "El departamento es obligatorio")]
    [StringLength(100, ErrorMessage = "El departamento no puede superar los 100 caracteres")]
    public string Departamento { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "El municipio no puede superar los 100 caracteres")]
    public string? Municipio { get; set; }

    [Required(ErrorMessage = "El estado es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "Seleccione un estado")]
    public int? IdEstado { get; set; }
}