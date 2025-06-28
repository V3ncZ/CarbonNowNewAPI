
namespace CarbonNow.Model
{
    public class ElectricalItem
    {
        public ElectricalItem()
        {
            
        }

        public ElectricalItem(User id, int tipoItemEletricoId, decimal duracaoUsoHoras, DateTime dtUso)
        {
            DuracaoUsoHoras = duracaoUsoHoras;
            DtUso = dtUso;
        }

        public int Id { get; set; }
        public User? IdUsuario { get; set; }
        public ElectricalItemType TipoItemEletrico { get; set; }
        public DateTime DtUso { get; set; }
        public decimal EmissaoCalculada { get; set; }
        public decimal DuracaoUsoHoras { get; set; }
    }
}
