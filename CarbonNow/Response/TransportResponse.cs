using CarbonNow.Model;

namespace CarbonNow.Response
{
    public record TransportResponse(
        int id,
        decimal distanciaKm,
        DateTime dtUso,
        decimal emissaoCalculada,

        TransportTypeResponse transportTypeResponse)
    {
    }
}
