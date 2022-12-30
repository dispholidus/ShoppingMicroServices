namespace ShoppingMicroservices.Model
{
    public class ExchangeRate
    {
        public int ExchangeRateId { get; set; }
        public string ExchangeRateName { get; set; } = string.Empty;
        public decimal ExchangeRateValue { get; set; }
    }
}
