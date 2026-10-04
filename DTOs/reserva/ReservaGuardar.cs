using System.ComponentModel.DataAnnotations;
namespace ExploreWayApp.DTOs.reserva
{
    public class ReservaGuardar
    {
        [Required(ErrorMessage = "El cliente es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El cliente no es válido.")]
        public int? IdCliente { get; set; }

        [Required(ErrorMessage = "El guía es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El guía no es válido.")]
        public int? IdGuia { get; set; }

        [Required(ErrorMessage = "La actividad del destino es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La actividad del destino no es válida.")]
        public int? IdDestinoActividad { get; set; }

        [Required(ErrorMessage = "La fecha del recorrido es obligatoria.")]
        public DateOnly? FechaRecorrido { get; set; }

        [Required(ErrorMessage = "La hora de inicio es obligatoria.")]
        public TimeOnly? HoraInicio { get; set; }

        [Required(ErrorMessage = "La cantidad de personas es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de personas debe ser mayor que cero.")]
        public int? CantidadPersonas { get; set; }

        [StringLength(500, ErrorMessage = "Las observaciones no pueden superar los 500 caracteres.")]
        public string? Observaciones { get; set; }
    }
}
