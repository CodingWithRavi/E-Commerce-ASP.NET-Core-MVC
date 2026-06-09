using E_Commerce.Data;
using E_Commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_Commerce.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;
        public OrderController(ApplicationDbContext context)
        {
            this.context = context;
        }
        //place order 
        // GET: Order/Buy/5
        [HttpGet]
        public IActionResult PlaceOrder(int Id)
        {
            var product = context.Products.Find(Id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // POST: Order/PlaceOrder/5
        [HttpPost]
        public IActionResult PlaceOrder(Order order)
        {
            //Login user ki Id Nikal Rha
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            order.UserId = userId;
            //Date
            order.OrderDate = DateTime.Now;

            //product from database
            var product=context.Products.Find(order.ProductId);

            //price Save 
            order.Price = product!.Price;
            context.Orders.Add(order);
            context.SaveChanges();
            //TempData["Success"] = "Your order has been placed successfully!";
            return RedirectToAction("OrderSuccess","Order");
        }
        //User See Your Orders
        public IActionResult MyOrders()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = context.Orders.
                Include(x=>x.Product)
                .Where(x => x.UserId == userId)
                .OrderByDescending(x => x.OrderDate)
                .ToList();
            return View(orders);
        }
        //success Page after Place order  
        public IActionResult OrderSuccess()
        {
            return View();
        }
    }
}
