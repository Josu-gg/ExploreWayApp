using ExploreWay.Web.Servicios;
using ExploreWayApp.Auth;
using ExploreWayApp.Components;
using ExploreWayApp.Config;
using ExploreWayApp.Servicios;
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

builder.Services.AddScoped<JwtHandler>();
builder.Services.AddHttpClient("ExploreWayApi", (sp, c) =>
{
    var opciones = sp.GetRequiredService<IOptions<ApiOptions>>().Value;
    c.BaseAddress = new Uri(opciones.BaseUrl);
}).AddHttpMessageHandler<JwtHandler>();

builder.Services.AddScoped<IAuthService, AuthService>();

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
