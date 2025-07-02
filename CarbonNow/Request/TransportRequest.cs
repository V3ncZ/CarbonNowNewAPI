using CarbonNow.Model;

namespace CarbonNow.Request
{
    public record TransportRequest(
        User idUsuario,
        TransportType tipoTransporteId,
        decimal distanciaKm,
        DateTime dtUso,
        decimal emissaoCalculada)
    {
    }
}
