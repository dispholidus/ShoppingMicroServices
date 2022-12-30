namespace ShoppingMicroservices.Model
{
    public interface IExchangeRateRepository
    {
        ExchangeRate? GetExchangeRateById(int exchangeRateId);
        ExchangeRate? GetExchangeRateByName(string exchangeRateName);
    }
}
