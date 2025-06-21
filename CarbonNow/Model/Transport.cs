namespace CarbonNow.Model
{
    public class Transport
    {
        public Transport(User idUsuario, string tipoTransporte, int distanciaKm, DateTime dtUso, int emissaoCalculada, bool conformeIso)
        {
            IdUsuario = idUsuario;
            TipoTransporte = tipoTransporte;
            DistanciaKm = distanciaKm;
            DtUso = dtUso;
            EmissaoCalculada = emissaoCalculada;
            ConformeIso = conformeIso;
        }

        public int Id { get; set; }
        public User? IdUsuario { get; set; }
        public string? TipoTransporte { get; set; }
        public int DistanciaKm { get; set; }
        public DateTime DtUso { get; set; }
        public int EmissaoCalculada { get; set; }
        public int EmissaoPermitidaIso { get;  set; }
        public bool ConformeIso { get;  set; }
    }
}
