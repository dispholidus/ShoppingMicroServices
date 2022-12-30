namespace ShoppingMicroservices.Model
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            ServicesDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ServicesDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }
            if (context.Orders.Any())
            {
                var rows = from o in context.Orders select o;
                foreach (var row in rows)
                {
                    context.Remove(row);
                }
            }
            if (!context.Products.Any())
            {
                context.AddRange
                    (
                        new Product { ProductName = "Samsung S22 Ultra", ProductCount = 25, ProductCategory = Categories["Electronics"], Price = 37500.0M, ProductDescription = "" },
                        new Product { ProductName = "Iphone 13 Pro Max", ProductCount = 35, ProductCategory = Categories["Electronics"], Price = 45000.0M, ProductDescription = "" },
                        new Product { ProductName = "Elbise", ProductCount = 750, ProductCategory = Categories["Clothes"], Price = 775.5M, ProductDescription = "" },
                        new Product { ProductName = "Tshirt", ProductCount = 2500, ProductCategory = Categories["Clothes"], Price = 154.9M, ProductDescription = "" },
                        new Product { ProductName = "Oturma Takımı", ProductCount = 150, ProductCategory = Categories["Furnitures"], Price = 5675.0M, ProductDescription = "" },
                        new Product { ProductName = "Dolap", ProductCount = 75, ProductCategory = Categories["Furnitures"], Price = 575.0M, ProductDescription = "" },
                        new Product { ProductName = "Kolye", ProductCount = 30, ProductCategory = Categories["Accessories"], Price = 1235.0M, ProductDescription = "" },
                        new Product { ProductName = "Saat", ProductCount = 50, ProductCategory = Categories["Accessories"], Price = 4750.0M, ProductDescription = "" },
                        new Product { ProductName = "Xiaomi Redmi Note 11", ProductCount = 59, ProductCategory = Categories["Electronics"], Price = 8900.0M, ProductDescription = "" },
                        new Product { ProductName = "Pantolon", ProductCount = 3000, ProductCategory = Categories["Clothes"], Price = 559.95M, ProductDescription = "" },
                        new Product { ProductName = "Avize", ProductCount = 150, ProductCategory = Categories["Furnitures"], Price = 1350.50M, ProductDescription = "" },
                        new Product { ProductName = "Bileklik", ProductCount = 300, ProductCategory = Categories["Accessories"], Price = 350.50M, ProductDescription = "" }
                    );
            }
            if (!context.ExchangeRates.Any())
            {
                context.AddRange
                    (
                        new ExchangeRate { ExchangeRateName = "Dolar", ExchangeRateValue = 18.71M },
                        new ExchangeRate { ExchangeRateName = "Euro", ExchangeRateValue = 19.95M }
                    );
            }
            context.SaveChanges();
        }
        private static Dictionary<string, Category>? categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Electronics" },
                        new Category { CategoryName = "Clothes" },
                        new Category { CategoryName = "Furnitures" },
                        new Category { CategoryName = "Accessories" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}
