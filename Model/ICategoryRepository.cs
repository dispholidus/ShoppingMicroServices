namespace ShoppingMicroservices.Model
{
    public interface ICategoryRepository
    {
        Category? GetCategoryById(int categoryId);
    }
}
