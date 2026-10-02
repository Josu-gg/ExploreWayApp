using System.ComponentModel.DataAnnotations;

namespace ExploreWayApp.DTOs.Rol;

public class RolModificar : RolGuardar
{
    [Range(1, int.MaxValue, ErrorMessage = "El identificador del rol no es válido.")]
    public int IdRol { get; set; }
}
