using ExploreWayApp.Auth;
using ExploreWayApp.DTOs.Auth;
using ExploreWayApp.Excepciones;
using ExploreWayApp.Auth;
using ExploreWayApp.DTOs.Auth;
using ExploreWayApp.Excepciones;
using ExploreWayApp.Servicios;
using System.Net;
using System.Net.Http.Json;

namespace ExploreWay.Web.Servicios;

public sealed class AuthService(
    IHttpClientFactory fabrica,
    SesionUsuario sesion,
    ExploreWayAuthStateProvider proveedor) : IAuthService
{
    private HttpClient Cliente => fabrica.CreateClient("ExploreWayApi");

    public async Task IniciarSesionAsync(LoginGuardar credenciales)
    {
        var respuesta = await Cliente.PostAsJsonAsync("auth/login", credenciales);

        if (respuesta.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new ApiException(401, "Correo o contraseña incorrectos.");
        }
        await ValidarAsync(respuesta);

        var datos = await respuesta.Content.ReadFromJsonAsync<LoginSalida>()
                    ?? throw new ApiException(500, "La respuesta del servidor está vacía.");

        sesion.Iniciar(datos);
        proveedor.Notificar();
    }

    public async Task RegistrarClienteAsync(RegistroClienteGuardar datos)
    {
        var respuesta = await Cliente.PostAsJsonAsync("clientes/registro", datos);
        await ValidarAsync(respuesta);
    }

    public void CerrarSesion()
    {
        sesion.Cerrar();
        proveedor.Notificar();
    }

    // Traduce los errores del GlobalExceptionHandler de la API a ApiException.
    private static async Task ValidarAsync(HttpResponseMessage respuesta)
    {
        if (respuesta.IsSuccessStatusCode) return;

        var mensaje = await LeerMensajeAsync(respuesta);
        throw new ApiException((int)respuesta.StatusCode, mensaje);
    }

    private static async Task<string> LeerMensajeAsync(HttpResponseMessage respuesta)
    {
        try
        {
            var problema = await respuesta.Content.ReadFromJsonAsync<ErrorApi>();
            if (!string.IsNullOrWhiteSpace(problema?.Message)) return problema.Message;
            if (!string.IsNullOrWhiteSpace(problema?.Detail)) return problema.Detail;
        }
        catch (Exception) { /* la respuesta no era JSON */ }

        return "Ocurrió un error al procesar la solicitud.";
    }

    private sealed class ErrorApi
    {
        public string? Message { get; set; }
        public string? Detail { get; set; }
        public string? Error { get; set; }
    }
}