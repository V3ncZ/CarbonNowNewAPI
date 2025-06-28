namespace CarbonNow.Model
{
    public class TransportType
    {
        public TransportType()
        {
            
        }

        public TransportType(string nome, decimal emissaoFatorPorKm)
        {
            Nome = nome;
            EmissaoFatorPorKm = emissaoFatorPorKm;
        }

        public TransportType(int id, string nome, decimal emissaoFatorPorKm)
        {
            Id = id;
            Nome = nome;
            EmissaoFatorPorKm = emissaoFatorPorKm;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal EmissaoFatorPorKm { get; set; }
        public bool ConformeIso { get; set; }
    }
}
