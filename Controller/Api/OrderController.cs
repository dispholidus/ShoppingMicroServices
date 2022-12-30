using Microsoft.AspNetCore.Mvc;
using ShoppingMicroservices.Model;

namespace ShoppingMicroservices.Controller.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ServicesDbContext _servicesDbContext;

        public OrderController(IOrderRepository orderRepository, ServicesDbContext servicesDbContext)
        {
            _orderRepository = orderRepository;
            _servicesDbContext = servicesDbContext;
        }

        [HttpGet]
        public IActionResult GetAllOrders() => Ok(_orderRepository.GetAll());

        [HttpPost]
        public IActionResult PlaceOrder(int productId, int quantity)
        {
            if (!_servicesDbContext.Products.Any(p => p.ProductId == productId))
            {
                return new JsonResult($"Product not found!");
            }

            if (_servicesDbContext.Products.FirstOrDefault(p => p.ProductId == productId)?.ProductCount - quantity < 0)
            {
                return new JsonResult($"Not enough product in the inventory!");
            }

            Order order = new Order { ProductId = productId, OrderQuantity = quantity, OrderDate = DateTime.Now };
            _servicesDbContext.Add(order);
            _servicesDbContext.SaveChanges();

            return new JsonResult($"Your order is placed. Order Id = {order.OrderId} Quantity = {quantity}");
        }

    }
}
