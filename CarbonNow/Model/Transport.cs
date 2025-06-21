namespace CarbonNow.Model
{
    public class Transport
    {
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
