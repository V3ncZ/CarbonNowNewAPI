using CarbonNow.Model;

namespace CarbonNow.Response
{
    public class TransportResponse(
        int id, 
        User idUsuario,
        string tipoTransporte,
        int distanciaKm,
        DateTime dtUso,
        int emissaoCalculada,
        bool conformeIso)
    {
    }
}
