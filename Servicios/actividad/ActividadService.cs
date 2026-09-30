using ExploreWayApp.DTOs.actividad;

namespace ExploreWayApp.Servicios.actividad
{
    public class ActividadService(HttpClient http) : IActividadService
    {
        private const string Ruta = "actividades";

        public async Task<PaginaResultado<ActividadSalida>> ListarAsync(int pagina, int tamano) =>
            await (await http.GetAsync($"{Ruta}?page={pagina - 1}&size={tamano}"))
                .LeerPaginaAsync<ActividadSalida>(pagina, tamano);

        public async Task<ActividadSalida> ObtenerAsync(int id) =>
            await (await http.GetAsync($"{Ruta}/{id}")).LeerAsync<ActividadSalida>();

        public async Task<ActividadSalida> CrearAsync(ActividadGuardar actividad) =>
            await (await http.PostAsJsonAsync<ActividadGuardar>(Ruta, actividad)).LeerAsync<ActividadSalida>();

        public async Task<ActividadSalida> ModificarAsync(int id, ActividadGuardar actividad) =>
            await (await http.PutAsJsonAsync<ActividadGuardar>($"{Ruta}/{id}", actividad)).LeerAsync<ActividadSalida>();

        public async Task EliminarAsync(int id) =>
            await (await http.DeleteAsync($"{Ruta}/{id}")).AsegurarExitoAsync();
    }
}
