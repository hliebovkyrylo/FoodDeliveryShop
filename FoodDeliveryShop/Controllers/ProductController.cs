using FoodDeliveryShop.Models;
using FoodDeliveryShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryShop.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public int PageSize { get; set; }

        public ProductController(IProductRepository repo)
        {
            repository = repo;
            PageSize = 4;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult List(int page = 1) => View(new ProductListViewModel
        {
            Products = repository.Products
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = repository.Products.Count()
            }
        });
    }
}