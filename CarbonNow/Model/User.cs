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

        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
