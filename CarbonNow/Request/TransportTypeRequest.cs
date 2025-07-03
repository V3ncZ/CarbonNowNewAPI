namespace CarbonNow.Request
{
    public record TransportTypeRequest(string nome, decimal emissaoFatorPorKm, bool conformeIso)
    {
    }
}
