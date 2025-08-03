namespace CarbonNow.Response
{
    public record TransportTypeResponse(
        int id,
        string nome,
        decimal emissaoFatorPorKm,
        bool conformeIso
        )
    {

    }
}
