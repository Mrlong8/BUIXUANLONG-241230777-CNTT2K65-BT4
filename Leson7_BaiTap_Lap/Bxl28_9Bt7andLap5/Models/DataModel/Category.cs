using System.ComponentModel.DataAnnotations;

namespace Bxl28_9Bt7andLap5.Models.DataModel
{
    public class Category
    {
        [Required(ErrorMessage = "Mã danh mục là bắt buộc nhập")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục là bắt buộc nhập")]
        public string Name { get; set; }
    }
}
