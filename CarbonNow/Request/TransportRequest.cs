using CarbonNow.Model;

namespace CarbonNow.Request
{
    public record TransportRequest(
        User idUsuario,
        int tipoTransporteId,
        decimal distanciaKm,
        DateTime dtUso,
        decimal emissaoCalculada)
    {
    }
}
