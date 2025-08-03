using CarbonNow.Model;

namespace CarbonNow.Request
{
    public record TransportRequest(
        int idUsuario,
        int tipoTransporteId,
        decimal distanciaKm,
        DateTime dtUso)
    {
    }
}
