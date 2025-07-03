
using System.ComponentModel.DataAnnotations.Schema;

namespace CarbonNow.Model
{
    public class Transport
    {

        public Transport() { }


        public Transport(int idUsuario, int tipoTransporteId, decimal distanciaKm, DateTime dtUso, decimal emissaoCalculada)
        {
            IdUsuario = idUsuario;
            TipoTransporteId = tipoTransporteId;
            DistanciaKm = distanciaKm;
            DtUso = dtUso;
            EmissaoCalculada = emissaoCalculada;
        }

        public int Id { get; set; }

        [ForeignKey("IdUsuario")]
        public User Usuario { get; set; }
        public int IdUsuario { get; set; }

        [ForeignKey("TipoTransporteId")]
        public TransportType TipoTransporte { get; set; }
        public int TipoTransporteId { get; set; }

        public decimal DistanciaKm { get; set; }
        public DateTime DtUso { get; set; }
        public decimal EmissaoCalculada { get; set; }

    }
}
