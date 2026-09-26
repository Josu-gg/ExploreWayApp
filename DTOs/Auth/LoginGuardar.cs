using System.ComponentModel.DataAnnotations;
namespace ExploreWayApp.DTOs.Auth
{
    public class LoginGuardar
    {
        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido.")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Contra { get; set; } = string.Empty;
    }
}
