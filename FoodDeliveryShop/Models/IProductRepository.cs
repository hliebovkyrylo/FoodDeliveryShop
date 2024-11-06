namespace FoodDeliveryShop.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}