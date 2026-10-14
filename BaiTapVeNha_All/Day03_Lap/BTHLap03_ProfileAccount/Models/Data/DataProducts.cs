namespace BTHLap03_ProfileAccount.Models.Data
{
    public static class DataProducts
    {
        public static List<Product> products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Áo Sơ Mi Nam",
                Image = "~/Products/ao.jpg",
                Price = 350000,
                SalePrice = 299000,
                CategoryId = 1, // Quần Áo
                Description = "Áo sơ mi nam chất liệu đũi thoáng mát.",
                Status = true,
                CreateAt = new DateTime(2026, 1, 10)
            },
            new Product
            {
                Id = 2,
                Name = "Túi Xách Da Ca Cao",
                Image = "~/Products/khangiay.jpg",
                Price = 850000,
                SalePrice = 699000,
                CategoryId = 2, // Túi xách
                Description = "Túi xách da cao cấp phong cách Hàn Quốc.",
                Status = true,
                CreateAt = new DateTime(2026, 2, 1)
            },
            new Product
            {
                Id = 3,
                Name = "Đồng Hồ Thể Thao",
                // Sửa lại dòng 35:
                Image = "~/Products/mubaohiem.jpg",
                Price = 1200000,
                SalePrice = 950000,
                CategoryId = 3, // Đồng hồ
                Description = "Đồng hồ chống nước, dây cao su bền bỉ.",
                Status = true,
                CreateAt = new DateTime(2026, 2, 15)
            },
            new Product
            {
                Id = 4,
                Name = "Smart TV 4K 55 inch",
                Image = "~/Products/nuoctaytrang.jpg",
                Price = 10500000,
                SalePrice = 8990000,
                CategoryId = 4, // Ti vi
                Description = "Màn hình tràn viền, âm thanh vòm đỉnh cao.",
                Status = true,
                CreateAt = new DateTime(2026, 3, 1)
            },
            new Product
            {
                Id = 5,
                Name = "Tủ Lạnh Inverter 250L",
                Image = "~/Products/quat.jpg",
                Price = 7800000,
                SalePrice = 7200000,
                CategoryId = 5, // Tủ lạnh
                Description = "Công nghệ tiết kiệm điện Inverter hiện đại.",
                Status = true,
                CreateAt = new DateTime(2026, 3, 10)
            },
            new Product
            {
                Id = 6,
                Name = "Quạt Điện Đứng",
                Image = "~/Products/sac.jpg",
                Price = 450000,
                SalePrice = 390000,
                CategoryId = 7, // Quạt điện
                Description = "Quạt đứng 3 tốc độ gió, vận hành êm ái.",
                Status = false,
                CreateAt = new DateTime(2026, 3, 12)
            }
        };
    }
}
