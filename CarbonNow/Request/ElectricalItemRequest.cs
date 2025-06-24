using CarbonNow.Model;

namespace CarbonNow.Request
{
    public record ElectricalItemRequest(
        User id,
        int tipoItemEletricoId,
        decimal duracaoUsoHoras,
        DateTime dtUso)
    {
    }
}
