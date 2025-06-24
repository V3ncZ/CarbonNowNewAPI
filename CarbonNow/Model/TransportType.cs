namespace CarbonNow.Model
{
    public class TransportType
    {
        public TransportType()
        {
            
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal EmissaoFatorPorKm { get; set; }
        public bool ConformeIso { get; set; }
    }
}
