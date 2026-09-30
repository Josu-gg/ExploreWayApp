using ExploreWayApp.Excepciones;
using System.Net;
using System.Text.Json;

namespace ExploreWayApp.Servicios.actividad
{
    internal static class RespuestaHttpExtensions
    {
        public static async Task<T> LeerAsync<T>(this HttpResponseMessage respuesta)
        {
            await respuesta.AsegurarExitoAsync();
            return (await respuesta.Content.ReadFromJsonAsync<T>())!;
        }

        public static async Task AsegurarExitoAsync(this HttpResponseMessage respuesta)
        {
            if (respuesta.IsSuccessStatusCode) return;
            throw new ApiException((int)respuesta.StatusCode, await ExtraerMensajeAsync(respuesta));
        }

        private static async Task<string> ExtraerMensajeAsync(HttpResponseMessage respuesta)
        {
            var porDefecto = respuesta.StatusCode switch
            {
                HttpStatusCode.Unauthorized => "Tu sesión expiró o no has iniciado sesión.",
                HttpStatusCode.Forbidden => "No tienes permiso para realizar esta acción.",
                HttpStatusCode.NotFound => "El recurso solicitado no existe.",
                _ => "Ocurrió un error al comunicarse con el servidor."
            };

            if ((int)respuesta.StatusCode >= 500) return porDefecto;

            try
            {
                using var doc = await JsonDocument.ParseAsync(await respuesta.Content.ReadAsStreamAsync());
                if (doc.RootElement.ValueKind != JsonValueKind.Object) return porDefecto;

                foreach (var campo in new[] { "message", "mensaje", "detail" })
                {
                    if (doc.RootElement.TryGetProperty(campo, out var valor) && valor.ValueKind == JsonValueKind.String)
                        return valor.GetString()!;
                }
            }
            catch (JsonException) { }

            return porDefecto;
        }
    }


}

namespace ExploreWayApp.Servicios.actividad
{
    internal static class PaginaHttpExtensions
    {
        // Acepta una página ({ content, totalElements, ... }) o un arreglo simple, que se pagina en memoria.
        public static async Task<DTOs.actividad.PaginaResultado<T>> LeerPaginaAsync<T>(
            this HttpResponseMessage respuesta, int pagina, int tamano)
        {
            await respuesta.AsegurarExitoAsync();
            var json = await respuesta.Content.ReadFromJsonAsync<System.Text.Json.JsonElement>();

            if (json.ValueKind == System.Text.Json.JsonValueKind.Array)
            {
                var todos = json.Deserialize<List<T>>(new System.Text.Json.JsonSerializerOptions(System.Text.Json.JsonSerializerDefaults.Web)) ?? [];
                return new DTOs.actividad.PaginaResultado<T>
                {
                    Contenido = todos.Skip((pagina - 1) * tamano).Take(tamano).ToList(),
                    TotalElementos = todos.Count,
                    TotalPaginas = (int)Math.Ceiling(todos.Count / (double)tamano),
                    Numero = pagina - 1
                };
            }

            return json.Deserialize<DTOs.actividad.PaginaResultado<T>>(new System.Text.Json.JsonSerializerOptions(System.Text.Json.JsonSerializerDefaults.Web))
                   ?? new DTOs.actividad.PaginaResultado<T>();
        }
    }
}
