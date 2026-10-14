using BXLBaiThucHanhLap1.Data;
using BXLBaiThucHanhLap1.Models;
using Microsoft.AspNetCore.Mvc;

namespace BXLBaiThucHanhLap1.Controllers
{
    public class ProductController : Controller
    {
        private List<Product> products = ProductData.Products;
        private static List<Product> cartProducts = new List<Product>();
        

        [HttpPost]
        public IActionResult AddToCart(int Id)
        {
            var product = products.FirstOrDefault(x => x.Id == Id);
            if (product != null)
            {
                cartProducts.Add(product);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View(cartProducts);
        }
      
    }
}
