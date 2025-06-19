namespace CarbonNow.Model
{
    public class User
    {
        public User()
        {
        }

        public User(string nome, string email, DateTime dtCadastro)
        {
            Nome = nome;
            Email = email;
            DtCadastro = dtCadastro;
        }

        public int Id { get; private set; }
        public string? Nome { get; private set; }
        public string? Email { get; private set; }
        public DateTime DtCadastro { get; private set; }
    }
}
