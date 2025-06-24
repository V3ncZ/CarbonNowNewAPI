using CarbonNow.Model;

namespace CarbonNow.Response
{
    public record ElectricalItemResponse(
        int id,
        int consumoKw,
        DateTime dtUso,
        decimal emissaoCalculada,
        decimal emissaoUsoHoras,
        
        ElectricalItemTypeResponse electricalItemTypeResponse
        
        )
    {
    }
}
