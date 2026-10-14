namespace NetCoreMVCLap03.Models
{
    public class Catalog
    {
        public int Id { get; set; }
        public string Name { get; set; }

   
        public List<Catalog> GetCatalogList()
        {
            return new List<Catalog>()
            {
                new Catalog() { Id = 1, Name = "Áo dài" },
                new Catalog() { Id = 2, Name = "Áo đông" },
                new Catalog() { Id = 3, Name = "Túi xách" },
                new Catalog() { Id = 4, Name = "Đồng hồ" },
                new Catalog() { Id = 5, Name = "Ví da" },
                new Catalog() { Id = 6, Name = "Thắt lưng da" },
                new Catalog() { Id = 7, Name = "Tủ lạnh" },
                new Catalog() { Id = 8, Name = "Tivi" },
                new Catalog() { Id = 9, Name = "Quạt điện" },
                new Catalog() { Id = 10, Name = "Lò sưởi" }
            };
        }
    }
}