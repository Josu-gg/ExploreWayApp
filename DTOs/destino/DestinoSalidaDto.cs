namespace ExploreWayApp.DTOs.Destino;

public class DestinoSalidaDto
{
    public int IdDestino { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public string Departamento { get; set; } = string.Empty;
    public string? Municipio { get; set; }
    public int IdEstado { get; set; }
    public string? NombreEstado { get; set; }
}
