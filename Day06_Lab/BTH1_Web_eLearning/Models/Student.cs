namespace BTH1_Web_eLearning.Models
{
    public class Student
    {

        public int Id { get; set; }//Mã sinh viên
        public string? Name { get; set; } //Họ tên
        public string? Email { get; set; } //Email
        public string? Password { get; set; }//Mật khẩu
        public Branch? Branch { get; set; }//Ngành học
        public Gender? Gender { get; set; }//Giới tính
        public bool IsRegular { get; set; }//Hệ: true-chính qui, false-phi cq
        public string? Address { get; set; }//Địa chi
        public DateTime DateOfBorth { get; set; }//Ngày sinh
        public string? Avatar { get; set; }// Tên hoặc đường dẫn ảnh đại diện
    }
}
