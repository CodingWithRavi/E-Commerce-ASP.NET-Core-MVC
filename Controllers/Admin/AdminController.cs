using E_Commerce.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext context;
        public AdminController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Dashboard()
        {
            ViewBag.TotalProducts = context.Products.Count();
            ViewBag.TotalCategories = context.Category.Count();
            ViewBag.TotalUsers = context.Users.Count();
            ViewBag.TotalOrder = context.Orders.Count();
            return View();
        }
        //Total Order
        public IActionResult TotalOrder()
        {
            var totalorder = context.Orders.
                Include(x => x.Product)
                .Include(x => x.User)
                .OrderByDescending(x => x.OrderDate)
                .ToList();
            return View(totalorder);
        }
    }
}