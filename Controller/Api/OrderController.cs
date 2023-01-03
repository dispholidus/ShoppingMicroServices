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
        private readonly NotificationController _notificationController;
        private readonly InventoryController _inventoryController;

        public OrderController(IOrderRepository orderRepository, ServicesDbContext servicesDbContext,
            NotificationController notificationController, InventoryController inventoryController)
        {
            _orderRepository = orderRepository;
            _servicesDbContext = servicesDbContext;
            _notificationController = notificationController;
            _inventoryController = inventoryController;
        }

        [HttpGet]
        public IActionResult GetAllOrders() => Ok(_orderRepository.GetAll());

        [HttpPost]
        public IActionResult PlaceOrder(int productId, int quantity, string? exchangeRateName)
        {
            if (!_servicesDbContext.Products.Any(p => p.ProductId == productId))
            {
                return new JsonResult($"Product not found!");
            }

            if (_servicesDbContext.Products.FirstOrDefault(p => p.ProductId == productId)?.ProductCount - quantity < 0)
            {
                return new JsonResult($"Not enough product in the inventory!");
            }
            Order order = new Order { ProductId = productId, OrderQuantity = quantity, OrderDate = DateTime.Now, ExchangeRateName = exchangeRateName };

            _inventoryController.UpdateItem(order);
            _servicesDbContext.Add(order);
            _servicesDbContext.SaveChanges();

            return _notificationController.SendNotificationAsync(order);
        }

    }
}
