namespace ExploreWayApp.DTOs.DestinoActividad
{
    public class DestinoActividadSalida
    {
        public int IdDestinoActividad { get; set; }
        public int IdDestino { get; set; }
        public string NombreDestino { get; set; } = string.Empty;
        public int IdActividad { get; set; }
        public string NombreActividad { get; set; } = string.Empty;
        public string? DescripcionActividad { get; set; }
        public string? Dificultad { get; set; }
        public int DuracionMinutos { get; set; }
        public decimal PrecioBase { get; set; }
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; } = string.Empty;
    }
}
