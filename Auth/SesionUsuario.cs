namespace ExploreWayApp.Auth
{
    public class SesionUsuario
    {
        public string? Token { get; private set; }
        public int IdUsuario { get; private set; }
        public string Correo { get; private set; } = string.Empty;
        public string NombreRol { get; private set; } = string.Empty;
        public string NombreCompleto { get; private set; } = string.Empty;

        public int IdPersona { get; private set; }
        public int IdGuia { get; private set; }
        public string? Foto { get; private set; }

        // Avisa a los componentes que muestran la foto (por ejemplo la barra superior).
        public event Action? FotoCambiada;

        public bool EsAdmin => string.Equals(NombreRol, "Admin", StringComparison.OrdinalIgnoreCase);

        public bool EsGuia => string.Equals(NombreRol, "Guia", StringComparison.OrdinalIgnoreCase);

        public bool Autenticado => !string.IsNullOrWhiteSpace(Token);

        public void Iniciar(DTOs.Auth.LoginSalida datos)
        {
            Token = datos.Token;
            Correo = datos.Correo;
            NombreRol = datos.Rol;
        }

        public void CompletarPerfil(DTOs.Auth.UsuarioActualSalida usuario)
        {
            IdUsuario = usuario.IdUsuario;
            IdPersona = usuario.IdPersona;
            Correo = usuario.Correo;
            NombreRol = usuario.NombreRol;
            NombreCompleto = $"{usuario.Nombre} {usuario.Apellido}".Trim();
            Foto = usuario.Foto;
        }

        public void ActualizarFoto(string? foto)
        {
            Foto = string.IsNullOrWhiteSpace(foto) ? null : foto;
            FotoCambiada?.Invoke();
        }

        public void AsignarGuia(int idGuia) => IdGuia = idGuia;

        public void Cerrar()
        {
            Token = null;
            IdUsuario = 0;
            IdGuia = 0;
            IdPersona = 0;
            Foto = null;
            Correo = string.Empty;
            NombreRol = string.Empty;
            NombreCompleto = string.Empty;
        }
    }
}
