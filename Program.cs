using Microsoft.EntityFrameworkCore;
using ShoppingMicroservices.Controller;
using ShoppingMicroservices.Model;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ServicesDbContextConnection") ??
    throw new InvalidOperationException("Connection string 'ServicesDbContextConnection' not found.");

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IExchangeRateRepository, ExchangeRateRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<InventoryController, InventoryController>();
builder.Services.AddScoped<NotificationController, NotificationController>();



builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddDbContext<ServicesDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:ServicesDbContextConnection"]);
});

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();
DbInitializer.Seed(app);
app.Run();
