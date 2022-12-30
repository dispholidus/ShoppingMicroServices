namespace ShoppingMicroservices.Model
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
        Product? GetProductById(int productId);
        decimal GetPrice(int productId, string exchangeRateName);
    }
}
