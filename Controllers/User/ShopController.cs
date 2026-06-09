using E_Commerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext context;

        public ShopController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //Index With Search and categories filtering
        public IActionResult Index(string search)
        {
            //Creare dropdown list of categories
            ViewBag.Categories = context.Category.ToList();

            // Get all products and filter by search term if provided
            var products = context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.ProductName!.Contains(search));
            }
            return View(products.ToList());
        }

        public IActionResult Details(int id)
        {
            var product = context.Products
                .Include(p => p.Category)
                .FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}