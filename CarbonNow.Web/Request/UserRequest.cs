namespace CarbonNow.Web.Request
{
    public record UserRequest(
        string nome,
        string email,
        DateTime dtCadastro)
    {
    }
}
