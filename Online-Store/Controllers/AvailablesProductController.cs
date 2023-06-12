using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Store.Models;

namespace Online_Store.Controllers
{
    public class AvailablesProductController : Controller
    {
        private readonly ONLINE_STOREContext _context;

        public AvailablesProductController(ONLINE_STOREContext context)
        {
            _context = context;
        }
        public IActionResult AddProductToShop()
        {
            ViewBag.shops = new SelectList(_context.Shops, "IdShop", "Name");
            ViewBag.products = new SelectList(_context.Products, "IdProduct", "Name");





            return View();
        }
        [HttpPost]
        public IActionResult AddProductToShop(int idShop,int idProduct,int amount)
        {
            ViewBag.shops = new SelectList(_context.Shops, "IdShop", "Name",idShop);
            ViewBag.products = new SelectList(_context.Products, "IdProduct", "Name",idProduct)    ;
            var record = new AvailableProduct();
            record.IdShop = idShop;
            record.IdProduct = idProduct;
            record.AvailableAmount = amount;

            _context.AvailableProducts.Add(record);
            _context.SaveChanges();




            return View();
        }
    }
}
