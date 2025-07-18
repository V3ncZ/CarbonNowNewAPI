namespace CarbonNow.Web.Response
{
    public record ElectricalItemTypeResponse(
        int id,
        string nome,
        decimal consumoKhwPorHora)
    {
    }
}
