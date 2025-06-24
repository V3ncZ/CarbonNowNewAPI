namespace CarbonNow.Model
{
    public class ElectricalItemType
    {
        public ElectricalItemType()
        {
            
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ConsumoKwhPorHora { get; set; }
        
    }
}
