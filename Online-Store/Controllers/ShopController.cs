using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Online_Store.Models;
using System.Linq;

namespace Online_Store.Controllers
{
    public class ShopController : Controller
    {

        private readonly ONLINE_STOREContext _context;

        public ShopController(ONLINE_STOREContext context)
        {
            _context = context;
        }
        public IActionResult Shops()
        {
            ViewBag.users = new SelectList(_context.Users,"IdUser","Name");
           

            ViewBag.shops= _context.Shops.Select(t=> new SelectListItem
            {
                Value=t.Name,
                Text=t.Name
            }).ToList();

            string shopsJson = JsonConvert.SerializeObject(ViewBag.shops);
            HttpContext.Session.SetString("Shops", shopsJson);
            ViewBag.productsAvailable = Enumerable.Empty<string>();

            return View();
        }
        [HttpPost]
        public IActionResult Shops(string shop)
        {
            var shopsJson = HttpContext.Session.GetString("Shops");
            if (shopsJson != null)
            {
                var shops=JsonConvert.DeserializeObject<List<SelectListItem>>(shopsJson);
                var selectedShop = shop;
                foreach (var item in shops)
                {
                    if (item.Value == selectedShop)
                    {
                        item.Selected = true;
                       
                    }
                    ViewBag.shops = shops;
                }
            }
            else
            {
                ViewBag.shops = new SelectList(_context.Shops.Select(t=>t.Name).ToList(),shop);
            }

            ViewBag.productsAvailable= _context.Shops
                    .Join(_context.AvailableProducts,shop=>shop.IdShop,availables=> availables.IdShop,(shop,availables)=> new {shop,availables})
                    .Join(_context.Products, shopAvailable => shopAvailable.availables.IdProduct, product => product.IdProduct, (shopAvailable, product) => new {product,shopAvailable})
                    .Select(final => new
                    {
                        ShopName = final.shopAvailable.shop.Name ,
                       ProductName= final.product.Name,
                      ProductPrice=  final.product.Price,
                      AvailableAmount=  final.shopAvailable.availables.AvailableAmount,
                      IDProduct=final.product.IdProduct,
                    }).Where(a=>a.ShopName==shop).ToList();
                    

            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(int userId,int id, int quantity)
        {

            var newElement = new CartProduct();
            newElement.IdCart = userId;
            newElement.IdProduct = id;
            newElement.Amout = quantity;

            var updateProduct = _context.AvailableProducts.Find(id);
            if (updateProduct != null)
            {
                updateProduct.AvailableAmount = (updateProduct.AvailableAmount - quantity);
                _context.AvailableProducts.Update(updateProduct);
            }

            _context.CartProducts.Add(newElement);
            
            _context.SaveChanges();

            ViewBag.message = "prodotto aggiunto al carrello";



            return RedirectToAction("Shops");
        }
    }
}
