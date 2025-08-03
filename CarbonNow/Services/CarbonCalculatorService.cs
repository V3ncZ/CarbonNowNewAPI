namespace CarbonNow.Services
{
    public class CarbonCalculatorService
    {
        public decimal CalcularEmissaoDeCarbono(decimal emissaoPorKm, decimal distanciaKm)
        {
            return emissaoPorKm * distanciaKm;
        }
    }
}
