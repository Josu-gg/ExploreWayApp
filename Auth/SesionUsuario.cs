namespace ExploreWayApp.Auth
{
    public class SesionUsuario
    {
        public string? Token { get; private set; }
        public int IdUsuario { get; private set; }
        public string Correo { get; private set; } = string.Empty;
        public string NombreRol { get; private set; } = string.Empty;
        public string NombreCompleto { get; private set; } = string.Empty;

        public bool Autenticado => !string.IsNullOrWhiteSpace(Token);

        public void Iniciar(DTOs.Auth.LoginSalida datos)
        {
            Token = datos.Token;
            IdUsuario = datos.IdUsuario;
            Correo = datos.Correo;
            NombreRol = datos.NombreRol;
            NombreCompleto = $"{datos.Nombre} {datos.Apellido}".Trim();
        }

        public void Cerrar()
        {
            Token = null;
            IdUsuario = 0;
            Correo = string.Empty;
            NombreRol = string.Empty;
            NombreCompleto = string.Empty;
        }
    }
}
