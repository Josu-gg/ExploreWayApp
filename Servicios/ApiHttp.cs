using System.Net.Http.Json;
using ExploreWayApp.DTOs.Comun;

namespace ExploreWayApp.Servicios;

// Helpers compartidos por los servicios que consumen la API (el BaseUrl ya termina en "/api/").
internal static class ApiHttp
{
    public static async Task<T?> LeerAsync<T>(this HttpClient http, string ruta)
    {
        var respuesta = await http.GetAsync(ruta);
        await RespuestaApi.ValidarAsync(respuesta);
        return await respuesta.Content.ReadFromJsonAsync<T>();
    }

    public static async Task<T?> EnviarAsync<T>(this HttpClient http, HttpMethod metodo, string ruta, object? cuerpo = null)
    {
        using var peticion = new HttpRequestMessage(metodo, ruta);
        if (cuerpo is not null) peticion.Content = JsonContent.Create(cuerpo, cuerpo.GetType());

        var respuesta = await http.SendAsync(peticion);
        await RespuestaApi.ValidarAsync(respuesta);
        return await respuesta.Content.ReadFromJsonAsync<T>();
    }

    public static async Task EnviarAsync(this HttpClient http, HttpMethod metodo, string ruta, object? cuerpo = null)
    {
        using var peticion = new HttpRequestMessage(metodo, ruta);
        if (cuerpo is not null) peticion.Content = JsonContent.Create(cuerpo, cuerpo.GetType());

        await RespuestaApi.ValidarAsync(await http.SendAsync(peticion));
    }

    // Los listados paginados de la API (PagedModel) se recorren completos: las vistas filtran en cliente.
    public static async Task<List<T>> LeerTodasLasPaginasAsync<T>(this HttpClient http, string ruta, int tamano = 100)
    {
        var resultado = new List<T>();
        var separador = ruta.Contains('?') ? '&' : '?';

        for (var pagina = 0; ; pagina++)
        {
            var datos = await http.LeerAsync<PagedResult<T>>($"{ruta}{separador}page={pagina}&size={tamano}");
            if (datos is null) break;

            resultado.AddRange(datos.Content);
            if (pagina + 1 >= datos.Page.TotalPages) break;
        }

        return resultado;
    }
}
