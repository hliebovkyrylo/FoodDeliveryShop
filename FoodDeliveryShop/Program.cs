using FoodDeliveryShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseDefaultServiceProvider(options => options.ValidateScopes = false);

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(configuration["Data:FoodDeliveryShopProducts:ConnectionStrings"]);
});

builder.Services.AddTransient<IProductRepository, EFProductRepository>();
builder.Services.AddMvc();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=List}/{id?}");

SeedData.EnsurePopulated(app);

app.Run();