using Microsoft.EntityFrameworkCore;
using ShoppingMicroservices.Controller;
using ShoppingMicroservices.Controller.Api;
using ShoppingMicroservices.Model;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


//var connectionString = builder.Configuration.GetConnectionString("ServicesDbContextConnection") ??
//throw new InvalidOperationException("Connection string 'ServicesDbContextConnection' not found.");
var connectionString = builder.Configuration.GetConnectionString("DockerDbContextConnection") ??
    throw new InvalidOperationException("Connection string 'DockerDbContextConnection' not found.");

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
    options.UseSqlServer(//builder.Configuration["ConnectionStrings:ServicesDbContextConnectiondoc"]);
            builder.Configuration["ConnectionStrings:DockerDbContextConnection"]);
});

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ServicesDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

DbInitializer.Seed(app);
app.Run();
