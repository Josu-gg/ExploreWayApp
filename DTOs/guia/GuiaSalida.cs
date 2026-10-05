namespace ExploreWayApp.DTOs.guia
{
    public class GuiaSalida
    {
        public int IdGuia { get; set; }
        public int IdPersona { get; set; }
        public string NombrePersona { get; set; } = string.Empty;
        public string ApellidoPersona { get; set; } = string.Empty;
        public string? Biografia { get; set; }
        public string? Experiencia { get; set; }
        public string? Estudios { get; set; }
        public bool PrimerosAuxilios { get; set; }
        public bool EstadoDisponibilidad { get; set; }
        public decimal? CalificacionPromedio { get; set; }
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; } = string.Empty;
        public string? Foto { get; set; }
    }
}
