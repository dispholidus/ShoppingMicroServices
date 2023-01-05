using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

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

        public decimal GetPrice(int productId, string? exchangeRateName)
        {
            Product? product = _servicesDbContext.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                return -1m;
            }

            if (exchangeRateName == null)
            {
                return product.Price;
            }

            ExchangeRate? exchangeRate = _servicesDbContext.ExchangeRates.FirstOrDefault(e => e.ExchangeRateName == exchangeRateName);

            if (exchangeRate == null)
            {
                return -2m;
            }

            return product.Price / exchangeRate.ExchangeRateValue;
        }

        public Product? GetProductById(int productId)
        {
            return _servicesDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
