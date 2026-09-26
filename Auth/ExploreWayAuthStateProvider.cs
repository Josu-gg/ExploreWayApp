using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
namespace ExploreWayApp.Auth
{
    public sealed class ExploreWayAuthStateProvider(SesionUsuario sesion) : AuthenticationStateProvider
    {
        private static readonly AuthenticationState Anonimo =
            new(new ClaimsPrincipal(new ClaimsIdentity()));

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
            => Task.FromResult(sesion.Autenticado ? Construir() : Anonimo);

        public void Notificar() => NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

        private AuthenticationState Construir()
        {
            var identidad = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.NameIdentifier, sesion.IdUsuario.ToString()),
            new Claim(ClaimTypes.Name, sesion.Correo),
            new Claim(ClaimTypes.Role, sesion.NombreRol)
            ], "ExploreWay");

            return new AuthenticationState(new ClaimsPrincipal(identidad));
        }
    }
}
