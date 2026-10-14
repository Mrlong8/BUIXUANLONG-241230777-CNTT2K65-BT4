using Bxl28_9Bt7andLap5.Models.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Bxl28_9Bt7andLap5.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {

        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop Dell", CategoryId = 1, Price = 15000000, SalePrice = 13000000, Image = "dell.jpg" },
            new Product { Id = 2, Name = "Áo thun nam", CategoryId = 2, Price = 200000, SalePrice = 150000, Image = "dell.jpg" }
        };

        public IViewComponentResult Invoke(int? catId)
        {
            var data = _products.AsQueryable();

            // Lọc nếu người dùng có truyền ID danh mục vào
            if (catId.HasValue && catId.Value > 0)
            {
                data = data.Where(p => p.CategoryId == catId.Value);
            }

            return View(data.ToList());
        }
    }
}
