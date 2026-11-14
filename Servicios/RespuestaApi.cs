using ExploreWayApp.Excepciones;
using System.Net.Http.Json;

namespace ExploreWayApp.Servicios;

// Traduce los errores del GlobalExceptionHandler de la API a ApiException.
// Lo comparten todos los servicios que consumen la API.
public static class RespuestaApi
{
    public static async Task ValidarAsync(HttpResponseMessage respuesta)
    {
        if (respuesta.IsSuccessStatusCode) return;

        var mensaje = await LeerMensajeAsync(respuesta, (int)respuesta.StatusCode);
        throw new ApiException((int)respuesta.StatusCode, mensaje);
    }

    private static async Task<string> LeerMensajeAsync(HttpResponseMessage respuesta, int codigo)
    {
        try
        {
            var problema = await respuesta.Content.ReadFromJsonAsync<ErrorApi>();
            if (!string.IsNullOrWhiteSpace(problema?.Message)) return problema.Message;
            if (!string.IsNullOrWhiteSpace(problema?.Detail)) return problema.Detail;
            if (!string.IsNullOrWhiteSpace(problema?.Error)) return problema.Error;
        }
        catch (Exception) { /* la respuesta no era JSON */ }

        // Spring Security responde 401/403 con el cuerpo vacío: se explica en lugar de mostrar un error genérico.
        return codigo switch
        {
            401 => "Necesitás iniciar sesión para ver esta información.",
            403 => "No tenés permiso para ver esta información.",
            _ => "Ocurrió un error al procesar la solicitud."
        };
    }

    private sealed class ErrorApi
    {
        public string? Message { get; set; }
        public string? Detail { get; set; }
        public string? Error { get; set; }
    }
}
