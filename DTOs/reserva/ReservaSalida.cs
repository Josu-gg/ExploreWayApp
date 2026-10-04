namespace ExploreWayApp.DTOs.reserva
{
    public class ReservaSalida
    {
        public int IdReserva { get; set; }

        public int IdCliente { get; set; }
        public string NombreCliente { get; set; } = string.Empty;
        public string ApellidoCliente { get; set; } = string.Empty;

        public int IdGuia { get; set; }
        public string NombreGuia { get; set; } = string.Empty;
        public string ApellidoGuia { get; set; } = string.Empty;

        public int IdDestinoActividad { get; set; }
        public string NombreDestino { get; set; } = string.Empty;
        public string NombreActividad { get; set; } = string.Empty;

        public DateOnly FechaRecorrido { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
        public int CantidadPersonas { get; set; }
        public decimal PrecioTotal { get; set; }
        public DateTime FechaReserva { get; set; }
        public string? Observaciones { get; set; }

        public int IdEstado { get; set; }
        public string NombreEstado { get; set; } = string.Empty;
    }
}
