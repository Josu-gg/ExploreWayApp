using ExploreWayApp.Auth;
using ExploreWayApp.Components;
using ExploreWayApp.Config;
using ExploreWayApp.Servicios;
using ExploreWayApp.Servicios.actividad;
using ExploreWayApp.Servicios.Destino;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services.Configure<ApiOptions>(builder.Configuration.GetSection("ExploreWayApi"));

builder.Services.AddScoped<SesionUsuario>();
builder.Services.AddScoped<ExploreWayAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp =>
    sp.GetRequiredService<ExploreWayAuthStateProvider>());

// HttpClient por circuito (scoped) para que el JwtHandler lea el SesionUsuario
// del propio circuito y envíe siempre el token vigente del usuario conectado.
builder.Services.AddScoped(sp =>
{
    // El JwtHandler necesita un handler interno que haga la petición HTTP real.
    var jwt = new JwtHandler(sp.GetRequiredService<SesionUsuario>())
    {
        InnerHandler = new HttpClientHandler()
    };
    return new HttpClient(jwt)
    {
        BaseAddress = new Uri(sp.GetRequiredService<IOptions<ApiOptions>>().Value.BaseUrl)
    };
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDestinoService, DestinoService>();
builder.Services.AddScoped<IActividadService, ActividadService>();
builder.Services.AddScoped<IEstadoService, EstadoService>();



builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorizationCore();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
