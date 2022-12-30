namespace ShoppingMicroservices.Model
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ServicesDbContext _servicesDbContext;

        public OrderRepository(ServicesDbContext servicesDbContext)
        {
            _servicesDbContext = servicesDbContext;
        }

        public IEnumerable<Order> GetAll()
        {
            return _servicesDbContext.Orders.OrderBy(p => p.OrderDate);
        }

        public Order? GetOrderById(int id) => _servicesDbContext.Orders.FirstOrDefault(o => o.OrderId == id);

    }
}
