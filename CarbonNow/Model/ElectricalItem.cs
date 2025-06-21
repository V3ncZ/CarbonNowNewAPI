namespace CarbonNow.Model
{
    public class ElectricalItem
    {
        public int Id { get; set; }
        public User? IdUsuario { get; set; }
        public string? NomeItem { get; set; }
        public int ConsumoKwh { get; set; }
        public DateTime DtUso { get; set; }
        public int EmissaoCalculada { get; set; }
    }
}
