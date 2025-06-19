namespace CarbonNow.Model
{
    public class Transport
    {
        public int Id { get; private set; }
        public User? IdUsuario { get; private set; }
        public string? TipoTransporte { get; private set; }
        public int DistanciaKm { get; private set; }
        public DateTime DtUso { get; private set; }
        public int EmissaoCalculada { get; private set; }
        public int EmissaoPermitidaIso { get; private set; }
        public bool ConformeIso { get; private set; }
    }
}
