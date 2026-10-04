namespace ExploreWayApp.DTOs.reserva
{
    // Subconjunto de ClienteSalida de la API para elegir al cliente de una reserva.
    public class ClienteResumen
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string NombreCompleto => $"{Nombre} {Apellido}".Trim();
    }
}
