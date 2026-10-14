namespace NetCoreMVCLap03.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int CatalogId { get; set; }

        public List<Product> GetListproduct()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Sản phẩm 1",
                    Price = 100000,
                    Description = "Mô tả sản phẩm 1",
                    Image = "/images/products/quat.jpg",
                    CatalogId = 1
                },
                new Product()
                {
                    Id = 2,
                    Name = "Sản phẩm 2",
                    Price = 200000,
                    Description = "Mô tả sản phẩm 2",
                    Image = "/images/products/quat.jpg",
                    CatalogId = 2
                },
                new Product()
                {
                    Id = 3,
                    Name = "Sản phẩm 3",
                    Price = 300000,
                    Description = "Mô tả sản phẩm 3",
                    Image = "/images/products/quat.jpg",
                    CatalogId = 3
                }
            };
            return products;
        }



    }
}
