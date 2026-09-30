namespace ExploreWayApp.DTOs.actividad
{
    public class ActividadSalida
    {
        public int IdActividad { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public string? Dificultad { get; set; }
        public int IdEstado { get; set; }
    }
}
