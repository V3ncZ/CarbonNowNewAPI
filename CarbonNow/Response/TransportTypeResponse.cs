namespace CarbonNow.Response
{
    public record TransportTypeResponse(
        int id,
        string nome,
        bool conformeIso
        )
    {
    }
}
