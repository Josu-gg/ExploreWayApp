using ExploreWayApp.Auth;
using ExploreWayApp.DTOs.Auth;
using ExploreWayApp.DTOs.guia;
using ExploreWayApp.Excepciones;
using System.Net;
using System.Net.Http.Json;

namespace ExploreWayApp.Servicios;

public sealed class AuthService(
    HttpClient cliente,
    SesionUsuario sesion,
    ExploreWayAuthStateProvider proveedor) : IAuthService
{
    public async Task IniciarSesionAsync(LoginGuardar credenciales)
    {
        var respuesta = await cliente.PostAsJsonAsync("auth/login", credenciales);

        if (respuesta.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new ApiException(401, "Correo o contraseña incorrectos.");
        }
        await ValidarAsync(respuesta);

        var datos = await respuesta.Content.ReadFromJsonAsync<LoginSalida>()
                    ?? throw new ApiException(500, "La respuesta del servidor está vacía.");

        sesion.Iniciar(datos);

        var respuestaMe = await cliente.GetAsync("auth/me");
        await ValidarAsync(respuestaMe);

        var usuario = await respuestaMe.Content.ReadFromJsonAsync<UsuarioActualSalida>()
                      ?? throw new ApiException(500, "No se pudieron obtener los datos del usuario autenticado.");

        sesion.CompletarPerfil(usuario);

        // El token no trae el Id del guía: se resuelve una vez a partir de su persona.
        if (sesion.EsGuia)
        {
            try
            {
                var guia = await cliente.LeerAsync<GuiaSalida>($"guias/persona/{usuario.IdPersona}")
                           ?? throw new ApiException(500, "No se encontró el perfil de guía de este usuario.");
                sesion.AsignarGuia(guia.IdGuia);
            }
            catch
            {
                sesion.Cerrar();
                throw;
            }
        }

        proveedor.Notificar();
    }

    public async Task RegistrarClienteAsync(RegistroClienteGuardar datos)
    {
        var respuesta = await cliente.PostAsJsonAsync("clientes/registro", datos);
        await ValidarAsync(respuesta);
    }

    public void CerrarSesion()
    {
        sesion.Cerrar();
        proveedor.Notificar();
    }

    private static Task ValidarAsync(HttpResponseMessage respuesta) =>
        RespuestaApi.ValidarAsync(respuesta);
}
