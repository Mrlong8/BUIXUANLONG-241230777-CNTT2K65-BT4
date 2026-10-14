using Microsoft.AspNetCore.Mvc;
using NetCoreMVCLap03.Models;

namespace NetCoreMVCLap03.Controllers
{
    public class BookController : Controller
    {
        protected Book book = new Book();
        private static List<Book> books = new List<Book>();

        // Constructor để khởi tạo dữ liệu ban đầu nếu danh sách đang rỗng
        public BookController()
        {
            if (books.Count == 0)
            {
                books = book.GetBookList();
            }
        }
        public IActionResult Index()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            return View(books);
        }

        public IActionResult Create()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            Book model = new Book();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Book model, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var fileName = Path.GetFileName(image.FileName);
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images/products");
                var filePath = Path.Combine(uploadsFolder, fileName);
                using (var stream = new FileStream(filePath,FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                model.Image = "/images/products/" + fileName;

            }
            model.Id = books.Max(b => b.Id) + 1;
            books.Add(model);
            return RedirectToAction("Index");

        }
    
        public IActionResult Edit(int id)
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            Book model = books.FirstOrDefault(b => b.Id == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Book model, IFormFile image)
        {
            var bookUpdate = books.FirstOrDefault(b => b.Id == model.Id);
            if (bookUpdate != null)
            {
                bookUpdate.Title = model.Title;
                bookUpdate.AuthorId = model.AuthorId;
                bookUpdate.GenreId = model.GenreId;
                bookUpdate.Price = model.Price;
                bookUpdate.TotalPage = model.TotalPage;
                bookUpdate.Sumary = model.Sumary;

                if (image != null && image.Length > 0)
                {
                    var fileName = Path.GetFileName(image.FileName);
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products");
                    var filePath = Path.Combine(uploadsFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }
                    bookUpdate.Image = "/images/products/" + fileName;
                }
            }

            return RedirectToAction("Index");
        }
        
        // khi load dữ liệu chỉ load đúng trang này mà không load lại cả web 
        public PartialViewResult PopularBook()
        {
            return PartialView(books);
        }
    }
}
