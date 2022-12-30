namespace ShoppingMicroservices.Model
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        private readonly ServicesDbContext _servicesDbContext;

        public ExchangeRateRepository(ServicesDbContext servicesDbContext)
        {
            _servicesDbContext = servicesDbContext;
        }

        public ExchangeRate? GetExchangeRateById(int exchangeRateId)
        {
            return _servicesDbContext.ExchangeRates.FirstOrDefault(e => e.ExchangeRateId == exchangeRateId);
        }

        public ExchangeRate? GetExchangeRateByName(string exchangeRateName)
        {
            return _servicesDbContext.ExchangeRates.FirstOrDefault(e => e.ExchangeRateName.Equals(exchangeRateName));
        }
    }
}
