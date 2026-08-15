using BXLBT4.src.DevmasterTrainingManagement.Application;
using BXLBT4.src.DevmasterTrainingManagement.ConsoleUI.Menus;
using BXLBT4.src.DevmasterTrainingManagement.ConsoleUI.Views;
using BXLBT4.src.DevmasterTrainingManagement.Domain;
using BXLBT4.src.DevmasterTrainingManagement.Infrastructure;

namespace BXLBT4.src.DevmasterTrainingManagement.ConsoleUI
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();

            HocVienRepository repositoryhv = new HocVienRepository();
            ApplctHocVien appHocVien = new ApplctHocVien(repositoryhv);
            HocVienView viewhv = new HocVienView();

            LopHocRepository repositorylh = new LopHocRepository();
            AppLopHoc appLopHoc = new AppLopHoc(repositorylh);
            LopHocView viewlh = new LopHocView();


            DisplayMenuManage(menu, appHocVien, viewhv, appLopHoc, viewlh);
        }

        public static void DisplayMenuManage(MainMenu menu, ApplctHocVien appHocVien, HocVienView viewhv, AppLopHoc appLopHoc, LopHocView viewlh)
        {
            int choose = -1;

            while (choose != 0)
            {
                menu.ShowMenuMain();

                Console.Write("Nhap so: ");

                while (!int.TryParse(Console.ReadLine(), out choose))
                {
                    Console.Write("Nhap sai! Vui long nhap so: ");
                }

                switch (choose)
                {
                    case 1:
                        QuanLyLopHoc(menu,appLopHoc,viewlh);
                        break;

                    case 2:
                        Console.WriteLine("Quan ly khoa hoc");
                        break;

                    case 3:
                        QuanLyHocVien(menu, appHocVien, viewhv);
                        
                        break;


                    case 0:
                        Console.WriteLine("Thoat chuong trinh!");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
            }
        }

        static void QuanLyHocVien(MainMenu menu, ApplctHocVien appHocVien, HocVienView viewhv)
        {
            int choose = -1;
            viewhv.DisplayListHocVien(appHocVien.GetDanhSachHocVien());

            while (choose != 0)
            {
                menu.ShowMenuQLHV();

                Console.Write("Nhap lua chon: ");

                while (!int.TryParse(Console.ReadLine(), out choose))
                {
                    Console.Write("Nhap sai! Vui long nhap so: ");
                }

                switch (choose)
                {
                    case 1:
                        // Thêm học viên
                        appHocVien.ThemHocVien();
                        viewhv.DisplayListHocVien(appHocVien.GetDanhSachHocVien());
                        break;

                    case 2:
                        // Sửa học viên
                        appHocVien.SuaHocVien();
                        break;

                    case 3:
                        // Xóa học viên
                        appHocVien.XoaHocVien();
                        break;

                    case 4:
                        // Kiểm tra trùng số điện thoại
                        appHocVien.KiemTraTrungDienThoai();
                        break;

                    case 5:
                        // Tìm theo tên
                        appHocVien.TimTheoTen();
                        break;

                    case 6:
                        // Tìm theo số điện thoại
                        appHocVien.TimTheoDienThoai();
                        break;

                    case 7:
                        // Tìm theo email
                        appHocVien.TimTheoEmail();
                        break;

                    case 8:
                        // Import CSV
                        appHocVien.ImportCSV();
                        break;

                    case 9:
                        // Export CSV
                        appHocVien.ExportCSV();
                        break;
                    case 0:
                        Console.WriteLine("Quay lai menu chinh...");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

                if (choose != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nhan phim bat ky de tiep tuc...");
                    Console.ReadKey();
                }
            }
        }

        static void QuanLyLopHoc(MainMenu menu, AppLopHoc appLopHoc, LopHocView viewlh)
        {
            int choose = -1;
            viewlh.DisplayListLopHoc(appLopHoc.GetDanhSachLopHoc());

            while (choose != 0)
            {
                menu.ShowMenuQLKH();

                Console.Write("Nhap lua chon: ");

                while (!int.TryParse(Console.ReadLine(), out choose))
                {
                    Console.Write("Nhap sai! Vui long nhap so: ");
                }

                switch (choose)
                {
                    case 1:
                        // Thêm học viên
                        //appLopHoc.ThemLopHhoc();
                        viewlh.DisplayListLopHoc(appLopHoc.GetDanhSachLopHoc());
                        break;

                 
                    case 0:
                        Console.WriteLine("Quay lai menu chinh...");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }

                if (choose != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nhan phim bat ky de tiep tuc...");
                    Console.ReadKey();
                }
            }
        }

    }
}