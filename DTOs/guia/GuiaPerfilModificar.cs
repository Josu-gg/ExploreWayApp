using System.ComponentModel.DataAnnotations;

namespace ExploreWayApp.DTOs.guia
{
    // Datos que el propio guía puede editar de su perfil (PUT guias/mi-perfil).
    public class GuiaPerfilModificar
    {
        [StringLength(500, ErrorMessage = "La biografía no puede superar los 500 caracteres.")]
        public string? Biografia { get; set; }

        [StringLength(500, ErrorMessage = "La experiencia no puede superar los 500 caracteres.")]
        public string? Experiencia { get; set; }

        [StringLength(200, ErrorMessage = "Los estudios no pueden superar los 200 caracteres.")]
        public string? Estudios { get; set; }

        [Required(ErrorMessage = "Debe indicarse si tiene primeros auxilios.")]
        public bool? PrimerosAuxilios { get; set; }

        [Required(ErrorMessage = "Debe indicarse la disponibilidad.")]
        public bool? EstadoDisponibilidad { get; set; }

        // URL de la foto de perfil: null = sin cambios, vacío = quitar la foto.
        [StringLength(500, ErrorMessage = "La URL de la foto no puede superar 500 caracteres.")]
        public string? Foto { get; set; }
    }
}
