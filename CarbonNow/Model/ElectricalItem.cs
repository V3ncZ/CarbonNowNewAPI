
using System.ComponentModel.DataAnnotations.Schema;

namespace CarbonNow.Model
{
    public class ElectricalItem
    {
        public ElectricalItem()
        {
            
        }

        public ElectricalItem(int id, int tipoItemEletricoId, decimal duracaoUsoHoras, DateTime dtUso)
        {
            DuracaoUsoHoras = duracaoUsoHoras;
            DtUso = dtUso;
        }

        public int Id { get; set; }

        [ForeignKey("IdUsuario")]
        public User Usuario { get; set; }
        public int IdUsuario { get; set; }

        [ForeignKey("TipoItemEletricoId")]
        public ElectricalItemType TipoItemEletrico { get; set; }
        public int TipoItemEletricoId { get; set; }

        public DateTime DtUso { get; set; }
        public decimal EmissaoCalculada { get; set; }
        public decimal DuracaoUsoHoras { get; set; }
    }
}
