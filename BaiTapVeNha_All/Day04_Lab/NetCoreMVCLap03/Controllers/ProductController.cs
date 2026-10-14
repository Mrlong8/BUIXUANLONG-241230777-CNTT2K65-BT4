using Microsoft.AspNetCore.Mvc;
using NetCoreMVCLap03.Models;

namespace NetCoreMVCLap03.Controllers
{
    public class ProductController : Controller
    {
        public Product product = new Product();
        protected Catalog catalog = new Catalog();
        public static List<Product> products = new List<Product>();

        public ProductController() {
            if (products.Count == 0)
            {
                products = product.GetListproduct();
            }
        }

        public IActionResult Index()
        {
            ViewBag.Catalogs = catalog.GetCatalogList();
            return View(products);
        }
        public IActionResult LatestProducts()
        {
            var latest = product.GetListproduct().Take(3).ToList();
            return PartialView("_ProductListPartial", latest);
        }

    }
}
