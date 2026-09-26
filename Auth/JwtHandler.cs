using System.Net.Http.Headers;
namespace ExploreWayApp.Auth
{
    public sealed class JwtHandler(SesionUsuario sesion) : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (sesion.Autenticado)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", sesion.Token);
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
