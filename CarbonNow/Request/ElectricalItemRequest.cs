using CarbonNow.Model;

namespace CarbonNow.Request
{
    public record ElectricalItemRequest(
        int idUsuario,
        int tipoItemEletricoId,
        decimal duracaoUsoHoras,
        DateTime dtUso)
    {
    }
}
