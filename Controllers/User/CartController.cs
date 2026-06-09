using E_Commerce.Data;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    [Authorize(Roles = "User")]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        public CartController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult AddToCart(int id)
        {
            var product = context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }
            //var exist = context.Carts.FirstOrDefault(x => x.ProductId == id);
            var UserId = userManager.GetUserId(User);
            var exist = context.Carts.FirstOrDefault(x => x.ProductId == id && x.UserId == UserId);
            if (exist!=null)
            {
                exist.Quantity++;
            }
            else
            {
                Cart cart = new Cart()
                {
                    ProductId = product.ProductId,
                    Quantity = 1,
                    UserId = UserId
                };
                context.Carts.Add(cart);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Index
        public IActionResult Index()
        {
            var UserId = userManager.GetUserId(User);
            var carts = context.Carts
                .Where(x => x.UserId == UserId)
                .Include(c => c.Product)
                .ToList();
            return View(carts);
        }
        //Quantity Increase
        public IActionResult Increase(int Id)
        {
            var cart = context.Carts.Find(Id);
            if (cart == null)
            {
                return NotFound();
            }
            cart.Quantity++;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Quantity Decrease
        public IActionResult Decrease(int Id)
        {
            var cart = context.Carts.Find(Id);
            if (cart == null)
            {
                return NotFound();
            }
            if (cart.Quantity > 1)
            {
                cart.Quantity--;
            }
            else
            {
                context.Carts.Remove(cart);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Remove item from cart
        public IActionResult Remove(int id)
        {
            var cart = context.Carts.Find(id);
            if (cart == null)
            {
                return NotFound();
            }
            context.Carts.Remove(cart);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}