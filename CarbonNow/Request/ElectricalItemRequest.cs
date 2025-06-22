using CarbonNow.Model;

namespace CarbonNow.Request
{
    public record ElectricalItemRequest(
        User id,
        string nomeItem,
        int consumoKw,
        DateTime dtUso,
        int emissaoCalculada)
    {
    }
}
