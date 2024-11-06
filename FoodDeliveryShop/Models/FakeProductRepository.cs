namespace FoodDeliveryShop.Models
{
    public class FakeProductRepository : IProductRepository
    {
        private IEnumerable<Product>? _products;
        public IEnumerable<Product> Products => _products ??= new List<Product>()
        {
            new Product { Name = "Pizza", Price = 10 },
            new Product { Name = "Burger", Price = 15 },
            new Product { Name = "Sandwich", Price = 5 }
        };
    }
}