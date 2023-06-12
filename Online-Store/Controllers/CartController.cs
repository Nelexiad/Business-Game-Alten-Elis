using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Online_Store.Models;

namespace Online_Store.Controllers
{
    public class CartController : Controller
    {
        private readonly ONLINE_STOREContext _context;

        public CartController(ONLINE_STOREContext context)
        {
            _context = context;
        }
        public IActionResult MyCart() 
        {

            ViewBag.users = new SelectList(_context.Users.ToList(), "IdUser", "Name");

            string usersJson = JsonConvert.SerializeObject(ViewBag.users);
            HttpContext.Session.SetString("Users", usersJson);
            ViewBag.result = Enumerable.Empty<string>();
            return View();
            
        }
        [HttpPost]
        public IActionResult MyCart(int id) 
        {
          
                ViewBag.users = new SelectList(_context.Users.ToList(), "IdUser", "Name",id);

            var query = (from cp in _context.CartProducts
                         join p in _context.Products on cp.IdProduct equals p.IdProduct
                         join c in _context.Carts on cp.IdCart equals c.IdCart
                         join u in _context.Users on c.IdUser equals u.IdUser
                         where u.IdUser == id
                         group new { p, cp } by new { p.IdProduct, p.Name, p.Price } into g
                         select new
                         {
                             ProductID = g.Key.IdProduct,
                             ProductName = g.Key.Name,
                             ProductPrice = g.Key.Price,
                             Amount = g.Sum(item => item.cp.Amout),
                             TotalPrice = g.Sum(item => item.cp.Amout * item.p.Price)
                         }).ToList();

            var totalPrice = query.Sum(item => item.TotalPrice);

            ViewBag.result = query;
            ViewBag.totalPrice = totalPrice;
            return View();
        }
    }
}
