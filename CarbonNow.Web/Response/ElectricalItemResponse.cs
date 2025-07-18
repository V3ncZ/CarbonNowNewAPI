
namespace CarbonNow.Web.Response
{
    public record ElectricalItemResponse(
        int id,
        int consumoKw,
        DateTime dtUso,
        decimal emissaoCalculada,
        decimal duracaoUsoHoras,

        ElectricalItemTypeResponse tipoItemEletrico

        )
    {
    }
}
