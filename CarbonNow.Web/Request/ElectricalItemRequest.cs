namespace CarbonNow.Web.Request
{
    public record ElectricalItemRequest(
        int idUsuario,
        int tipoItemEletricoId,
        decimal duracaoUsoHoras,
        DateTime dtUso)
    {
    }
}
