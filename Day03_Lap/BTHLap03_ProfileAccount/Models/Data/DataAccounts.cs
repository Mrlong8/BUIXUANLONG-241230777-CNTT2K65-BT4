namespace BTHLap03_ProfileAccount.Models.Data
{
    public class DataAccounts
    {
        public static List<Account> accounts;
         static DataAccounts()
        {
            accounts = new List<Account>()
            {
                new Account
                {
                    Id = 1,
                    Name = "Nguyễn Văn A",
                    Email = "nguyenvana@gmail.com",
                    Phone = "0901234567",
                    Avatar = "~/Avatar/avt01.jpg",
                    Address = "Hà Nội",
                    Bio = "Lập trình viên Backend",
                    Gender = 1,
                    Birthday = new DateTime(1998, 5, 15)
                },
                new Account
                {
                    Id = 2,
                    Name = "Trần Thị B",
                    Email = "tranthib@gmail.com",
                    Phone = "0912345678",
                    Avatar = "~/Avatar/avt02.jpg",
                    Address = "Đà Nẵng",
                    Bio = "Yêu thích thiết kế UI/UX",
                    Gender = 0,
                    Birthday = new DateTime(2000, 10, 20)
                },
                new Account
                {
                    Id = 3,
                    Name = "Lê Hoàng C",
                    Email = "lehoangc@gmail.com",
                    Phone = "0923456789",
                    Avatar = "~/Avatar/avt03.jpg",
                    Address = "Hồ Chí Minh",
                    Bio = "Đam mê công nghệ và game",
                    Gender = 1,
                    Birthday = new DateTime(1995, 2, 28)
                },
                new Account
                {
                    Id = 4,
                    Name = "Phạm Mai D",
                    Email = "phammaid@gmail.com",
                    Phone = "0934567890",
                    Avatar = "~/Avatar/avt04.jpg",
                    Address = "Hải Phòng",
                    Bio = "Sinh viên ngành CNTT",
                    Gender = 0,
                    Birthday = new DateTime(2003, 8, 12)
                },
                new Account
                {
                    Id = 5,
                    Name = "Vũ Trọng E",
                    Email = "vutronge@gmail.com",
                    Phone = "0945678901",
                    Avatar = "~/Avatar/avt05.jpg",
                    Address = "Cần Thơ",
                    Bio = "Thích đọc sách và code",
                    Gender = 1,
                    Birthday = new DateTime(1992, 11, 5)
                }
            };

        }
    }
}
