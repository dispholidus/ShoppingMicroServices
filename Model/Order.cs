namespace ShoppingMicroservices.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderQuantity { get; set; }
        public string? ExchangeRateName { get; set; }

    }
}
