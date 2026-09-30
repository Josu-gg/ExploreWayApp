using System.ComponentModel.DataAnnotations;


namespace ExploreWayApp.DTOs.actividad
{
    public class ActividadGuardar
    {

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(150, ErrorMessage = "El nombre no puede superar los 150 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(2000, ErrorMessage = "La descripción no puede superar los 2000 caracteres.")]
        public string? Descripcion { get; set; }

        [StringLength(50, ErrorMessage = "La dificultad no puede superar los 50 caracteres.")]
        public string? Dificultad { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Selecciona un estado.")]
        public int IdEstado { get; set; }
    }
}
