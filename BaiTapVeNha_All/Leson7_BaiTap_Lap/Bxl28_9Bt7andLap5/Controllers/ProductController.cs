using Bxl28_9Bt7andLap5.Models.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bxl28_9Bt7andLap5.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _env;

        private static List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Đồ điện tử" },
            new Category { Id = 2, Name = "Thời trang" }
        };

        private static List<Product> _products = new List<Product>();

        public ProductController(IWebHostEnvironment env)
        {
            _env = env;
        }
      
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categories, "Id", "Name");
            return View(new Product());
        }

        [HttpPost]
        public IActionResult Create(Product product, IFormFile imageFile)
        {
         
            ModelState.Remove("Image");

            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                  
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "product");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                
                    string uniqueFileName = System.Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                  
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(fileStream);
                    }

                  
                    product.Image = uniqueFileName;
                }
                else
                {
                    ModelState.AddModelError("Image", "Vui lòng chọn hình ảnh sản phẩm!");
                    ViewBag.Categories = new SelectList(_categories, "Id", "Name");
                    return View(product);
                }

                _products.Add(product);

                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(_categories, "Id", "Name");
            return View(product);
        }
    }
}
