
namespace ExploreWayApp.DTOs.usuario
{
    public class UsuarioSalida
    {
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string? Direccion { get; set; }
        public DateOnly? FechaNacimiento { get; set; }
        public string? Foto { get; set; }
        public string Correo { get; set; } = string.Empty;
        public int IdRol { get; set; }
        public string NombreRol { get; set; } = string.Empty;
        public int IdEstado { get; set; }
        public string NombreEstado { get; set; } = string.Empty;
    }
}
