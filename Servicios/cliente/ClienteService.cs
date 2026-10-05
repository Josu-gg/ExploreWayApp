using ExploreWayApp.DTOs.Cliente;

namespace ExploreWayApp.Servicios.Cliente;

public sealed class ClienteService(HttpClient http) : IClienteService
{
    private const string Url = "clientes";

    public Task<ClienteSalida?> ObtenerMiPerfilAsync() =>
        http.LeerAsync<ClienteSalida>($"{Url}/mi-perfil");

    public Task<ClienteSalida?> ModificarAsync(int id, ClienteModificar dto) =>
        http.EnviarAsync<ClienteSalida>(HttpMethod.Put, $"{Url}/{id}", dto);
}
