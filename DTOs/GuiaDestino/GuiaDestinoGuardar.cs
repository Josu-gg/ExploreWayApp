using System.ComponentModel.DataAnnotations;

namespace ExploreWayApp.DTOs.GuiaDestino
{
    public class GuiaDestinoGuardar
    {
        [Required(ErrorMessage = "El guía es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El guía no es válido.")]
        public int? IdGuia { get; set; }

        [Required(ErrorMessage = "El destino es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El destino no es válido.")]
        public int? IdDestino { get; set; }
    }
}
