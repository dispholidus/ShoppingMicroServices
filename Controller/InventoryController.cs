using Microsoft.AspNetCore.Mvc;
using ShoppingMicroservices.Model;

namespace ShoppingMicroservices.Controller
{
    public class InventoryController : ControllerBase
    {
        private readonly ServicesDbContext _servicesDbContext;

        public InventoryController(ServicesDbContext servicesDbContext)
        {
            _servicesDbContext = servicesDbContext;
        }

        public void UpdateItem(Order order)
        {
            var product = _servicesDbContext.Products.FirstOrDefault(p => p.ProductId == order.ProductId);
            if (product != null)
            {
                product.ProductCount -= order.OrderQuantity;
            }
            _servicesDbContext.SaveChanges();
        }
    }
}
