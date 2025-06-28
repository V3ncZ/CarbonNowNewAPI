using CarbonNow.Model;

namespace CarbonNow.Response
{
    public record ElectricalItemResponse(
        int id,
        int consumoKw,
        DateTime dtUso,
        decimal emissaoCalculada,
        decimal duracaoUsoHoras,

        ElectricalItemTypeResponse electricalItemTypeResponse

        )
    {
        public ElectricalItemResponse(int id, User? idUsuario, DateTime dtUso, decimal emissaoCalculada, decimal duracaoUsoHoras)
        {
            this.id = id;
            this.dtUso = dtUso;
            this.emissaoCalculada = emissaoCalculada;
            this.duracaoUsoHoras = duracaoUsoHoras;
        }
    }
}
