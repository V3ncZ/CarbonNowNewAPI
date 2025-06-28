namespace CarbonNow.Response
{
    public record TransportTypeResponse(
        int id,
        string nome,
        bool conformeIso
        )
    {
        private decimal emissaoFatorPorKm;

        public TransportTypeResponse(int id, string nome, decimal emissaoFatorPorKm, bool conformeIso)
        {
            this.id = id;
            this.nome = nome;
            this.emissaoFatorPorKm = emissaoFatorPorKm;
            this.conformeIso = conformeIso;
        }
    }
}
