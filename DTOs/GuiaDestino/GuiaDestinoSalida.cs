namespace ExploreWayApp.DTOs.GuiaDestino
{
    public class GuiaDestinoSalida
    {
        public int IdGuiaDestino { get; set; }
        public int IdGuia { get; set; }
        public string NombreGuia { get; set; } = string.Empty;
        public string ApellidoGuia { get; set; } = string.Empty;
        public int IdDestino { get; set; }
        public string NombreDestino { get; set; } = string.Empty;
        public string? Departamento { get; set; }
        public string? Municipio { get; set; }
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; } = string.Empty;
    }
}
