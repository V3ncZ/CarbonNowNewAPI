namespace CarbonNow.Model
{
    public class ElectricalItem
    {
        private User id;
        private int consumoKw;

        public ElectricalItem()
        {
            
        }

        public ElectricalItem(User id, string nomeItem, int consumoKw, DateTime dtUso, int emissaoCalculada)
        {
            this.id = id;
            NomeItem = nomeItem;
            this.consumoKw = consumoKw;
            DtUso = dtUso;
            EmissaoCalculada = emissaoCalculada;
        }

        public int Id { get; set; }
        public User? IdUsuario { get; set; }
        public string? NomeItem { get; set; }
        public int ConsumoKwh { get; set; }
        public DateTime DtUso { get; set; }
        public int EmissaoCalculada { get; set; }
    }
}
