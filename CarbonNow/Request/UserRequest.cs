namespace CarbonNow.Request
{
    public record UserRequest(
        string nome,
        string email,
        DateTime dtCadastro)
    {
    }
}
