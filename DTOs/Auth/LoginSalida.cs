namespace ExploreWayApp.DTOs.Auth
{
    public class LoginSalida
    {
        public string Token { get; set; } = string.Empty;
        public string TipoToken { get; set; } = string.Empty;
        public string ExpiraEn { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }
}
