using CarbonNow.Model;

namespace CarbonNow.Response
{
    public record ElectricalItemResponse(
        int id,
        User idUsuario,
        string nomeItem,
        int consumoKw,
        DateTime dtUso,
        int emissaoCalculada)
    {
    }
}
