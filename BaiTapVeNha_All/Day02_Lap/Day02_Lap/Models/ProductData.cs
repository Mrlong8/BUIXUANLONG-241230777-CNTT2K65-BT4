using BXLBaiThucHanhLap1.Models;

namespace BXLBaiThucHanhLap1.Data
{
    public static class ProductData
    {
        public static List<Product> Products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Laptop Gaming ASUS",
                Price = 25000000,
                CreatedAt = new DateTime(2026, 8, 20),
                Image = "../img/Products/images1.jpg"
            },

            new Product
            {
                Id = 2,
                Name = "iPhone 16 Pro",
                Price = 28000000,
                CreatedAt = new DateTime(2026, 8, 21),
                Image = "../img/Products/images2.jpg"
            },
            new Product
            {
                Id = 3,
                Name = "Tai nghe Bluetooth Sony",
                Price = 1500000,
                CreatedAt = new DateTime(2026, 8, 22),
                Image = "../img/Products/images3.jpg"
            },

            new Product
            {
                Id = 4,
                Name = "Bàn phím cơ Logitech",
                Price = 2000000,
                CreatedAt = new DateTime(2026, 8, 22),
                Image = "../img/Products/images4.jpg"
            },

            new Product
            {
                Id = 5,
                Name = "Chuột Gaming Razer",
                Price = 1200000,
                CreatedAt = new DateTime(2026, 8, 22),
                Image = "../img/Products/images1.jpg"
            },

            new Product
            {
                Id = 6,
                Name = "Màn hình Samsung 27 inch",
                Price = 6500000,
                CreatedAt = new DateTime(2026, 8, 22),
                Image = "../img/Products/images2.jpg"
            },

            new Product
            {
                Id = 7,
                Name = "Loa Bluetooth JBL",
                Price = 2500000,
                CreatedAt = new DateTime(2026, 8, 22),
                Image = "../img/Products/images3.jpg"
            }
        };
    }
}