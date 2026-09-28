using MudBlazor;

namespace ExploreWayApp.Components.Layout;

// Paleta de colores oficial ExploreWay:
// #00A86B (Principal Verde), #5BE3C2 (Menta Acento), #5BBAE3 (Cielo Info), #67BECB (Turquesa Suave)
public static class TemaExploreWay
{
    public static readonly MudTheme Instancia = new()
    {
        PaletteLight = new PaletteLight
        {
            Primary = "#00A86B",
            Secondary = "#5BE3C2",
            Info = "#5BBAE3",
            Success = "#67BECB",
            AppbarBackground = "rgba(255, 255, 255, 0.95)",
            AppbarText = "#1e293b",
            Background = "#f8fafc",
            Surface = "#ffffff",
            TextPrimary = "#0f172a",
            TextSecondary = "#475569",
            ActionDefault = "#00A86B",
            DrawerBackground = "#ffffff",
            DrawerText = "#1e293b"
        }
    };
}
