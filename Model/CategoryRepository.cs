namespace ShoppingMicroservices.Model
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ServicesDbContext _servicesDbContext;

        public CategoryRepository(ServicesDbContext servicesDbContext)
        {
            _servicesDbContext = servicesDbContext;
        }

        public Category? GetCategoryById(int categoryId)
        {
            return _servicesDbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }
    }
}
