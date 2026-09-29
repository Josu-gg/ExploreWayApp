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
            if (!string.IsNullOrWhiteSpace(problema?.Error)) return problema.Error;
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
