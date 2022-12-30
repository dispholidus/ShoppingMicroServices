using Microsoft.AspNetCore.Mvc;
using ShoppingMicroservices.Model;

namespace ShoppingMicroservices.Controller.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IExchangeRateRepository _exchangeRateRepository;

        public ProductController(IProductRepository productRepository, IExchangeRateRepository exchangeRateRepository)
        {
            _productRepository = productRepository;
            _exchangeRateRepository = exchangeRateRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allproducts = _productRepository.AllProducts;
            return Ok(allproducts);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_productRepository.AllProducts.Any(p => p.ProductId == id))
                return NotFound();
            return Ok(_productRepository.AllProducts.FirstOrDefault(p => p.ProductId == id));
        }
        [HttpGet("{id}/{exchangeName}")]
        public IActionResult GetPrice(int id, string exchangeName)
        {
            if (!_productRepository.AllProducts.Any(p => p.ProductId == id))
                return NotFound();
            decimal price = _productRepository.GetPrice(id, exchangeName);
            return Ok(price);
        }
    }
}
