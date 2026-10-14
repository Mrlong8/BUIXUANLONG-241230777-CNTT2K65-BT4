using BXLBT4.src.DevmasterTrainingManagement.Domain;

namespace BXLBT4.src.DevmasterTrainingManagement.ConsoleUI.Views
{
    internal class KhoaHocView
    {
        public void DisplayTitle()
        {
            Console.WriteLine();

            Console.WriteLine(
                "=========================================================================================================================="
            );

            Console.WriteLine(
                "|                                                   DANH SACH KHOA HOC                                                   |"
            );

            Console.WriteLine(
                "=========================================================================================================================="
            );

            Console.WriteLine(
                "| {0,-8} | {1,-25} | {2,15} | {3,12} | {4,-50} | {5,-15} |",
                "Ma KH",
                "Ten Khoa Hoc",
                "Hoc Phi",
                "Thoi Luong",
                "Mo Ta",
                "Trang Thai"
            );

            Console.WriteLine(
                "--------------------------------------------------------------------------------------------------------------------------"
            );
        }

        public void DisplayKhoaHoc(KhoaHoc khoaHoc)
        {
            Console.WriteLine(
                "| {0,-8} | {1,-25} | {2,15:N0} | {3,12} | {4,-50} | {5,-15} |",
                khoaHoc.maKH,
                khoaHoc.nameKH,
                khoaHoc.hocPhi,
                khoaHoc.thoiLuong,
                khoaHoc.moTa,
                khoaHoc.trangThai
            );
        }

        public void DisplayListKhoaHoc(List<KhoaHoc> danhSachKhoaHoc)
        {
            DisplayTitle();

            foreach (KhoaHoc khoaHoc in danhSachKhoaHoc)
            {
                DisplayKhoaHoc(khoaHoc);
            }

            Console.WriteLine(
                "=========================================================================================================================="
            );
        }
    }
}