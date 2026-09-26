namespace ExploreWayApp.Excepciones
{
    public sealed class ApiException : Exception
    {
        public int CodigoEstado { get; }

        public ApiException(int codigoEstado, string mensaje) : base(mensaje)
            => CodigoEstado = codigoEstado;
    }
}
