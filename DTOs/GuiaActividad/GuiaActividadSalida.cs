namespace ExploreWayApp.DTOs.GuiaActividad
{
    public class GuiaActividadSalida
    {
        public int IdGuiaActividad { get; set; }
        public int IdGuia { get; set; }
        public string NombreGuia { get; set; } = string.Empty;
        public string ApellidoGuia { get; set; } = string.Empty;
        public int IdActividad { get; set; }
        public string NombreActividad { get; set; } = string.Empty;
        public string? Dificultad { get; set; }
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; } = string.Empty;
    }
}
