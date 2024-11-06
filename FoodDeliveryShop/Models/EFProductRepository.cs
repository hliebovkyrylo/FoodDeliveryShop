namespace FoodDeliveryShop.Models
{
    public class EFProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products => context.Product;

        private ApplicationDbContext context;

        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
    }
}