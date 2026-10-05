namespace ExploreWayApp.DTOs.DisponibilidadGuia;

public class DisponibilidadGuiaSalida
{
    public int IdDisponibilidad { get; set; }
    public int IdGuia { get; set; }
    public string NombreGuia { get; set; } = string.Empty;
    public string ApellidoGuia { get; set; } = string.Empty;
    public DateOnly Fecha { get; set; }
    public TimeOnly HoraInicio { get; set; }
    public TimeOnly HoraFin { get; set; }
    public int IdEstado { get; set; }
    public string NombreEstado { get; set; } = string.Empty;
}
