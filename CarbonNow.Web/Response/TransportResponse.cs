

namespace CarbonNow.Web.Response
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
