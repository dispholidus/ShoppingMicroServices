namespace ShoppingMicroservices.Model
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order? GetOrderById(int id);
    }
}
