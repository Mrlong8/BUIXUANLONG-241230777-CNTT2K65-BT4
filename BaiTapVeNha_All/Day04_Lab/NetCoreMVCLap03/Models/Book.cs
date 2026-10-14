using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace NetCoreMVCLap03.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; }

        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chí Phèo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/b1.jpg",
                    Price = 120000,
                    Sumary = "Tác phẩm văn học kinh điển về số phận con người trong xã hội cũ.",
                    TotalPage = 250
                },
                new Book()
                {
                    Id = 2,
                    Title = "Tắt Đèn",
                    AuthorId = 2,
                    GenreId = 1,
                    Image = "/images/products/b2.jpg",
                    Price = 95000,
                    Sumary = "Bức tranh chân thực về đời sống nông thôn Việt Nam trước Cách mạng.",
                    TotalPage = 210
                },
                new Book()
                {
                    Id = 3,
                    Title = "Số Đỏ",
                    AuthorId = 3,
                    GenreId = 1,
                    Image = "/images/products/b3.jpg",
                    Price = 110000,
                    Sumary = "Tác phẩm trào phúng sắc bén về xã hội thượng lưu thời bấy giờ.",
                    TotalPage = 280
                },
                new Book()
                {
                    Id = 4,
                    Title = "Lập Trình C# Cơ Bản",
                    AuthorId = 4,
                    GenreId = 2,
                    Image = "/images/products/b4.jpg",
                    Price = 250000,
                    Sumary = "Hướng dẫn chi tiết ngôn ngữ C# dành cho người mới bắt đầu.",
                    TotalPage = 450
                },
                new Book()
                {
                    Id = 5,
                    Title = "ASP.NET Core Toàn Tập",
                    AuthorId = 4,
                    GenreId = 2,
                    Image = "/images/products/b5.jpg",
                    Price = 320000,
                    Sumary = "Xây dựng ứng dụng Web MVC và API hiện đại với .NET.",
                    TotalPage = 600
                },
                new Book()
                {
                    Id = 6,
                    Title = "Cấu Trúc Dữ Liệu & Giải Thuật",
                    AuthorId = 5,
                    GenreId = 2,
                    Image = "/images/products/b6.jpg",
                    Price = 180000,
                    Sumary = "Trình bày nền tảng thuật toán và tổ chức dữ liệu trong lập trình.",
                    TotalPage = 380
                },
                new Book()
                {
                    Id = 7,
                    Title = "Đắc Nhân Tâm",
                    AuthorId = 6,
                    GenreId = 3,
                    Image = "/images/products/b7.jpg",
                    Price = 135000,
                    Sumary = "Nghệ thuật thu phục lòng người và giao tiếp ứng xử trong cuộc sống.",
                    TotalPage = 320
                },
                new Book()
                {
                    Id = 8,
                    Title = "Nhà Giả Kim",
                    AuthorId = 7,
                    GenreId = 4,
                    Image = "/images/products/b8.jpg",
                    Price = 105000,
                    Sumary = "Hành trình theo đuổi ước mơ và lắng nghe tiếng nói của trái tim.",
                    TotalPage = 225
                },
                new Book()
                {
                    Id = 9,
                    Title = "Tuổi Trẻ Đáng Giá Bao Nhiêu",
                    AuthorId = 8,
                    GenreId = 3,
                    Image = "/images/products/b9.jpg",
                    Price = 90000,
                    Sumary = "Những chia sẻ và nguồn cảm hứng học tập, trải nghiệm cho giới trẻ.",
                    TotalPage = 270
                }
            };
            return books;
        }

        public Book GetBookId(int id)
        {
            Book book = this.GetBookList().FirstOrDefault(b => b.Id == id);
            return book;
        }

        public List<SelectListItem> Authors { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Nam Cao" },
            new SelectListItem { Value = "2", Text = "Ngô Tất Tố" },
            new SelectListItem { Value = "3", Text = "Vũ Trọng Phụng" },
            new SelectListItem { Value = "4", Text = "Nguyễn Văn A" }
        };

        public List<SelectListItem> Genres { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Truyện tranh" },
            new SelectListItem { Value = "2", Text = "lập trình" },
            new SelectListItem { Value = "3", Text = "tự nhiên" },
            new SelectListItem { Value = "4", Text = "văn học" }
        };

    }


}
