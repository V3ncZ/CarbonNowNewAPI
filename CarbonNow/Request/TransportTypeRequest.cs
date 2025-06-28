namespace CarbonNow.Request
{
    public record TransportTypeRequest(int id, string nome, decimal emissaoFatorPorKm, bool conformeIso)
    {
    }
}
