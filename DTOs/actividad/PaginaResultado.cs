using System.Text.Json.Serialization;

namespace ExploreWayApp.DTOs.actividad
{
    public class PaginaResultado<T>
    {
        [JsonPropertyName("content")]
        public List<T> Contenido { get; set; } = [];

        [JsonPropertyName("totalElements")]
        public long TotalElementos { get; set; }

        [JsonPropertyName("totalPages")]
        public int TotalPaginas { get; set; }

        [JsonPropertyName("number")]
        public int Numero { get; set; }
    }
}
