using Microsoft.AspNetCore.Mvc;
using Online_Store.Models;

namespace Online_Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly ONLINE_STOREContext _context;

        public ProductController(ONLINE_STOREContext context)
        {
            _context = context;
        }
        public IActionResult AddProduct()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(string name,decimal money)
        {
            var newProduct = new Product();
            newProduct.Name = name;
            newProduct.Price = money;

           _context.Products.Add(newProduct);
            _context.SaveChanges();
            return View();
        }
    }
}
