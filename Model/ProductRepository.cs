using Microsoft.EntityFrameworkCore;

namespace ShoppingMicroservices.Model
{
    public class ProductRepository : IProductRepository
    {
        private readonly ServicesDbContext _servicesDbContext;
        private readonly IExchangeRateRepository _exchangeRateRepository;
        public ProductRepository(ServicesDbContext servicesDbContext, IExchangeRateRepository exchangeRateRepository)
        {
            _servicesDbContext = servicesDbContext;
            _exchangeRateRepository = exchangeRateRepository;
        }
        public IEnumerable<Product> AllProducts
        {
            get
            {
                return _servicesDbContext.Products.Include(c => c.ProductCategory);
            }
        }

        public decimal GetPrice(int productId, string exchangeRateName)
        {
            decimal? price = _servicesDbContext.Products.FirstOrDefault(p => p.ProductId == productId)?.Price /
                _exchangeRateRepository.GetExchangeRateByName(exchangeRateName)?.ExchangeRateValue;
            if (price == null)
            {
                return -1.0M;
            }
            return (decimal)price;
        }

        public Product? GetProductById(int productId)
        {
            return _servicesDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
