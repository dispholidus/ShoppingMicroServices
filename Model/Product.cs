namespace ShoppingMicroservices.Model
{
    public class Product
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int ProductCount { get; set; } = 0;
        public string? ProductDescription { get; set; }
        public Category ProductCategory { get; set; } = default!;
        public decimal Price { get; set; }
    }
}
