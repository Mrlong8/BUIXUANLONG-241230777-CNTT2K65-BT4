namespace BTHLap03_ProfileAccount.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public float SalePrice { get; set; }
        public  int CategoryId { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
