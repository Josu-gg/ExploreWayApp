namespace ExploreWayApp.DTOs.Cliente
{
    public class ClienteSalida
    {
        public int IdCliente { get; set; }
        public int IdPersona { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string? Direccion { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
        public string? Foto { get; set; }
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; } = string.Empty;
    }
}
