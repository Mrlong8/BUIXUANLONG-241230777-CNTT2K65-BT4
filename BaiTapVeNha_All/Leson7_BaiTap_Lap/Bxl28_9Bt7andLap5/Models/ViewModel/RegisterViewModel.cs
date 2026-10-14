using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bxl28_9Bt7andLap5.Models.ViewModel
{
    public class RegisterViewModel
    {
        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đang nhạp không được để trống")]
        [StringLength(28,MinimumLength = 3,ErrorMessage = "Độ dài từ 3 đến 28 ký tự")]
        public string UserName { get; set; }

        [DisplayName("Học và tên")]
        [Required(ErrorMessage = "Họ Và Tên không được để trống")]
        public string FullName { get; set; }

        [DisplayName("Mật Khẩu")]
        [Required(ErrorMessage = "mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }


        [DisplayName("Xác nhận Mật Khẩu")]
        [Required(ErrorMessage = "Vui Long xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("PassWord",ErrorMessage ="Mật khẩu không khớp")]
        public string ConfirmPassWord { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email Không được bở trống")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Điện thoại")]
        [RegularExpression(@"^0\d{8,11}$", ErrorMessage = "Số điện thoại phải bắt đầu bằng 0 và có từ 9 đến 12 chữ số")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DisplayName("Ngày Sinh")]
        public DateTime Birthday { get; set; }
    }
}
