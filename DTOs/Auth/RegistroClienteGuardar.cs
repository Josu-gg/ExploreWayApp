using System.ComponentModel.DataAnnotations;
namespace ExploreWayApp.DTOs.Auth
{
    public class RegistroClienteGuardar
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [StringLength(100, ErrorMessage = "El apellido no puede superar 100 caracteres.")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [RegularExpression(@"^[0-9+\-\s]{8,20}$", ErrorMessage = "El teléfono solo admite números, +, - y espacios (8 a 20 caracteres).")]
        public string Telefono { get; set; } = string.Empty;

        [StringLength(250, ErrorMessage = "La dirección no puede superar 250 caracteres.")]
        public string? Direccion { get; set; }

        public DateOnly? FechaNacimiento { get; set; }

        [StringLength(500, ErrorMessage = "La URL de la foto no puede superar 500 caracteres.")]
        public string? Foto { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo no es válido.")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(72, MinimumLength = 8, ErrorMessage = "La contraseña debe tener entre 8 y 72 caracteres.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d).+$", ErrorMessage = "La contraseña debe incluir al menos una letra y un número.")]
        public string Contra { get; set; } = string.Empty;
    }
}
