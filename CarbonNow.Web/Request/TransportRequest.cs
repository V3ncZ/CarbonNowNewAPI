namespace CarbonNow.Web.Request
{
    public record TransportRequest(
        int idUsuario,
        int tipoTransporteId,
        decimal distanciaKm,
        DateTime dtUso,
        decimal emissaoCalculada)
    {
    }
}
