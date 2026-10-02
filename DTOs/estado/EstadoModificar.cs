using System.ComponentModel.DataAnnotations;

namespace ExploreWayApp.DTOs.Estado;

public class EstadoModificar : EstadoGuardar
{
    [Range(1, int.MaxValue, ErrorMessage = "El identificador del estado no es válido.")]
    public int IdEstado { get; set; }
}