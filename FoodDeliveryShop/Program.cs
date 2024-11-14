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
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();

app.MapControllerRoute("pagination", "Products/Page{page}", new { Controller = "Product", Action = "List" });

app.UseMvc(routes =>
{
    routes.MapRoute(
        name: null,
        template: "{category}/Page{page:int}",
        defaults: new
        {
            controller = "Product",
            action = "List"
        });

    routes.MapRoute(
        name: null,
        template: "Page{page:int}",
        defaults: new
        {
            controller = "Product",
            action = "List",
            page = 1
        });

    routes.MapRoute(
        name: null,
        template: "{category}",
        defaults: new
        {
            controller = "Product",
            action = "List",
            page = 1
        });

    routes.MapRoute(
        name: null,
        template: "",
        defaults: new
        {
            controller = "Product",
            action = "List",
            page = 1
        });

    routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
});

SeedData.EnsurePopulated(app);
app.Run();