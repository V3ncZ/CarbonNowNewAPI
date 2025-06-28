namespace CarbonNow.Model
{
    public class ElectricalItemType
    {
        private decimal consumo;

        public ElectricalItemType()
        {
            
        }

        public ElectricalItemType(string nome, decimal consumo)
        {
            Nome = nome;
            this.consumo = consumo;
        }

        public ElectricalItemType(int id, string nome, decimal consumo)
        {
            Id = id;
            Nome = nome;
            this.consumo = consumo;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ConsumoKwhPorHora { get; set; }
        
    }
}
