using CarbonNow.Model;

namespace CarbonNow.Response
{
    public class TransportResponse(
        int id, 
        decimal distanciaKm,
        DateTime dtUso,
        decimal emissaoCalculada,
        
        TransportTypeResponse transportTypeResponse)
    {
    }
}
