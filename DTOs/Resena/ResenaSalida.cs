namespace ExploreWayApp.DTOs.Resena;

public class ResenaSalida
{
    public int IdResena { get; set; }
    public int IdReserva { get; set; }
    public int IdCliente { get; set; }
    public string NombreCliente { get; set; } = string.Empty;
    public string ApellidoCliente { get; set; } = string.Empty;
    public int IdGuia { get; set; }
    public string NombreGuia { get; set; } = string.Empty;
    public string ApellidoGuia { get; set; } = string.Empty;
    public int Calificacion { get; set; }
    public string? Comentario { get; set; }
    public DateTime Fecha { get; set; }
}
