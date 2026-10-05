using System.ComponentModel.DataAnnotations;
namespace ExploreWayApp.DTOs.Cliente
{
    public class ClienteModificar
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

        // null = sin cambios en el formulario; la API guarda lo que reciba (vacío = sin foto).
        public string? Foto { get; set; }

        // El cliente no cambia su estado: se reenvía el que ya tiene.
        public int IdEstado { get; set; }
    }
}
