namespace ShoppingMicroservices.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderQuantity { get; set; }
        public string? ExchangeRateName { get; set; }
        public decimal? Price { get; set; }
        public override string ToString()
        {
            string price = string.Format("{0:0,0.00}", Price);
            return $"Your order is placed.Product Id = {ProductId} Order Id = {OrderId} Quantity = {OrderQuantity} Time = {OrderDate} Price = {price}";
        }

    }
}
