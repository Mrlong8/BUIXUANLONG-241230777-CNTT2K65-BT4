using System.ComponentModel.DataAnnotations;

namespace Bxl28_9Bt7andLap5.Models.DataModel
{
    public class Product
    {
        [Required(ErrorMessage = "Mã sản phẩm là bắt buộc")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Tên sản phẩm phải từ 6 đến 150 ký tự")] 
        public string Name { get; set; }

        [Required(ErrorMessage = "Hình ảnh là bắt buộc")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm là bắt buộc")]
        [Range(100000, double.MaxValue, ErrorMessage = "Giá sản phẩm nhỏ nhất là 100,000")] 
        [DataType(DataType.Text)] 
        public float Price { get; set; }

        [Required(ErrorMessage = "Giá khuyến mãi là bắt buộc")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mãi không được âm")] 
        public float SalePrice { get; set; }

        [Required(ErrorMessage = "Mô tả là bắt buộc")]
        [MaxLength(1500, ErrorMessage = "Mô tả không được vượt quá 1500 ký tự")] 
        public string Description { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn danh mục")] 
        public int CategoryId { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (SalePrice > Price * 0.9)
            {
                yield return new ValidationResult("Giá khuyến mãi phải nhỏ hơn giá gốc ít nhất 10%", new[] { "SalePrice" });
            }
            if (!string.IsNullOrEmpty(Description))
            {
                var badWords = new List<string> { "die", "admin", "fack" }; //[cite: 10]
                foreach (var word in badWords)
                {
                    if (Description.ToLower().Contains(word))
                    {
                        yield return new ValidationResult($"Mô tả không được chứa từ nhạy cảm: '{word}'", new[] { "Description" });
                    }
                }
            }
        }
    }
}
