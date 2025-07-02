
namespace CarbonNow.Model
{
    public class Transport
    {

        public Transport() { }


        public Transport(User idUsuario, TransportType tipoTransporteId, decimal distanciaKm, DateTime dtUso, decimal emissaoCalculada)
        {
            IdUsuario = idUsuario;
            TipoTransporte = tipoTransporteId;
            DistanciaKm = distanciaKm;
            DtUso = dtUso;
            EmissaoCalculada = emissaoCalculada;
        }

        public int Id { get; set; }
        public User IdUsuario { get; set; }
        public TransportType TipoTransporte { get; set; }
        public decimal DistanciaKm { get; set; }
        public DateTime DtUso { get; set; }
        public decimal EmissaoCalculada { get; set; }

    }
}
