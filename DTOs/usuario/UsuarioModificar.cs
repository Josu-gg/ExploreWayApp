using System.ComponentModel.DataAnnotations;
namespace ExploreWayApp.DTOs.usuario
{
    public class UsuarioModificar
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
        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
        [StringLength(150, ErrorMessage = "El correo no puede superar 150 caracteres.")]
        public string Correo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El rol es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El rol no es válido.")]
        public int? IdRol { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El estado no es válido.")]
        public int? IdEstado { get; set; }
    }
}
