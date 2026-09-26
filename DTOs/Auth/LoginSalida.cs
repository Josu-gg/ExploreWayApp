namespace ExploreWayApp.DTOs.Auth
{
    public class LoginSalida
    {
        public string Token { get; set; } = string.Empty;
        public int IdUsuario { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string NombreRol { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
    }
}
