namespace CarbonNow.Web.Request
{
    public record TransportTypeRequest(string nome, decimal emissaoFatorPorKm, bool conformeIso)
    {
    }
}
