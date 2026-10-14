using BTHLap03_ProfileAccount.Models;
using BTHLap03_ProfileAccount.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace BTHLap03_ProfileAccount.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(int? categoryId)
        {
            var products = DataProducts.products;

            // Lọc theo danh mục nếu categoryId có giá trị
            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId.Value).ToList();
            }

            // Truyền danh sách Category sang View qua ViewBag để hiển thị menu bên trái
            ViewBag.Categories = DataCategory.categories;
            ViewBag.CurrentCategoryId = categoryId; // Lưu id danh mục đang chọn

            return View(products);
        }
        public IActionResult Detail(int id)
        {
            var product = DataProducts.products.FirstOrDefault(a => a.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

    }
}
