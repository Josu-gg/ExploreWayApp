using ExploreWayApp.Components;
using ExploreWayApp.Auth;
using ExploreWayApp.Config;
using ExploreWayApp.Servicios;
using ExploreWayApp.Servicios.actividad;
using ExploreWayApp.Servicios.Destino;
using ExploreWayApp.Servicios.DisponibilidadGuia;
using ExploreWayApp.Servicios.Resena;
using ExploreWayApp.Servicios.DestinoActividad;
using ExploreWayApp.Servicios.Guia;
using ExploreWayApp.Servicios.GuiaActividad;
using ExploreWayApp.Servicios.GuiaDestino;
using ExploreWayApp.Servicios.ImagenDestino;
using ExploreWayApp.Servicios.Imagenes;
using ExploreWayApp.Servicios.Reserva;
using ExploreWayApp.Servicios.Estado;
using ExploreWayApp.Servicios.Rol;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services.Configure<ApiOptions>(builder.Configuration.GetSection("ExploreWayApi"));
builder.Services.Configure<CloudinaryOptions>(builder.Configuration.GetSection("Cloudinary"));

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
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IDestinoActividadService, DestinoActividadService>();
builder.Services.AddScoped<IGuiaService, GuiaService>();
builder.Services.AddScoped<IGuiaActividadService, GuiaActividadService>();
builder.Services.AddScoped<IDisponibilidadGuiaService, DisponibilidadGuiaService>();
builder.Services.AddScoped<IResenaService, ResenaService>();
builder.Services.AddScoped<IGuiaDestinoService, GuiaDestinoService>();
builder.Services.AddScoped<IImagenDestinoService, ImagenDestinoService>();
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();
builder.Services.AddScoped<IReservaService, ReservaService>();



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
