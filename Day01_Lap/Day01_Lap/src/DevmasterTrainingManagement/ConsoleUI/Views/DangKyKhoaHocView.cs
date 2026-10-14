using BXLBT4.src.DevmasterTrainingManagement.Domain;

namespace BXLBT4.src.DevmasterTrainingManagement.ConsoleUI.Views
{
    internal class DangKyKhoaHocView
    {
        public void DisplayTitle()
        {
            Console.WriteLine();

            Console.WriteLine(
                "=============================================================================================================="
            );

            Console.WriteLine(
                "|                                      DANH SACH DANG KY KHOA HOC                                            |"
            );

            Console.WriteLine(
                "=============================================================================================================="
            );

            Console.WriteLine(
                "| {0,-10} | {1,-20} | {2,-10} | {3,-12} | {4,15} | {5,15} | {6,-18} |",
                "Ma DK",
                "Hoc Vien",
                "Ma Lop",
                "Ngay DK",
                "Hoc Phi",
                "Da Dong",
                "Trang Thai"
            );

            Console.WriteLine(
                "--------------------------------------------------------------------------------------------------------------"
            );
        }

        public void DisplayDangKy(DangKyKhoaHoc dangKy)
        {
            Console.WriteLine(
                "| {0,-10} | {1,-20} | {2,-10} | {3,-12} | {4,15:N0} | {5,15:N0} | {6,-18} |",
                dangKy.MaDangKy,
                dangKy.HocVien?.hoTen ?? "",
                dangKy.LopHoc?.MaLop ?? "",
                dangKy.NgayDangKy.ToString("dd/MM/yyyy"),
                dangKy.HocPhi,
                dangKy.SoTienDaDong,
                dangKy.TrangThaiThanhToan
            );
        }

        public void DisplayListDangKy(
            List<DangKyKhoaHoc> danhSachDangKy)
        {
            DisplayTitle();

            foreach (DangKyKhoaHoc dangKy in danhSachDangKy)
            {
                DisplayDangKy(dangKy);
            }

            Console.WriteLine(
                "=============================================================================================================="
            );
        }
    }
}