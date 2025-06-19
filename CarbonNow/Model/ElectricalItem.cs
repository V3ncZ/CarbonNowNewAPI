namespace CarbonNow.Model
{
    public class ElectricalItem
    {
        public int Id { get; private set; }
        public User? IdUsuario { get; private set; }
        public string? NomeItem { get; private set; }
        public int ConsumoKwh { get; private set; }
        public DateTime DtUso { get; private set; }
        public int EmissaoCalculada { get; private set; }
    }
}
