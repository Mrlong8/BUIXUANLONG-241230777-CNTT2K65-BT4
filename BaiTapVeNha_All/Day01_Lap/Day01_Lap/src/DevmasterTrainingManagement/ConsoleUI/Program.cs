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

            KhoaHocRepository repositorykh = new KhoaHocRepository();
            AppKhoaHoc appKhoaHoc = new AppKhoaHoc(repositorykh);
            KhoaHocView viewkh = new KhoaHocView();

            DangKyKhoaHocRepository repositorydk = new DangKyKhoaHocRepository();
            AppDangKyKhoaHoc appDangKy =
                new AppDangKyKhoaHoc(
                    repositorydk,
                    appLopHoc,
                    appHocVien
                );
            DangKyKhoaHocView viewdk = new DangKyKhoaHocView();

            ChamSocHocVienRepository repositorycs = new ChamSocHocVienRepository();
            AppChamSocHocVien appChamSoc =
                new AppChamSocHocVien(
                    repositorycs,
                    appHocVien
                );
            ChamSocHocVienView viewChamSoc = new ChamSocHocVienView();

            DisplayMenuManage(
                    menu,
                    appHocVien,
                    viewhv,
                    appLopHoc,
                    viewlh,
                    appKhoaHoc,
                    viewkh,
                    appDangKy,
                    viewdk,
                    appChamSoc,
                    viewChamSoc
             );
        }

        public static void DisplayMenuManage(MainMenu menu,
                ApplctHocVien appHocVien,
                HocVienView viewhv,
                AppLopHoc appLopHoc,
                LopHocView viewlh,
                AppKhoaHoc appKhoaHoc,
                KhoaHocView viewkh,
                AppDangKyKhoaHoc appDangKy,
                DangKyKhoaHocView viewdk,
                AppChamSocHocVien appChamSoc,
                ChamSocHocVienView viewChamSoc
            )
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
                        QuanLyKhoaHoc(menu,appKhoaHoc,viewkh);
                        break;

                    case 3:
                        QuanLyHocVien(menu, appHocVien, viewhv);
                        break;
                    case 4:
                        QuanLyDangKyKhoaHoc(menu,appDangKy,viewdk);
                        break;
                    case 5:
                        QuanLyChamSocHocVien(menu,appChamSoc,viewChamSoc);
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

        static void QuanLyChamSocHocVien(MainMenu menu,AppChamSocHocVien appChamSoc,ChamSocHocVienView view)
        {
            int choose = -1;
            view.DisplayListChamSoc(appChamSoc.GetDanhSachChamSoc());
            while (choose != 0)
            {
                menu.ShowMenuChamSocHocVien();

                Console.Write("Nhap lua chon: ");

                while (!int.TryParse(Console.ReadLine(), out choose))
                {
                    Console.Write("Nhap sai! Vui long nhap so: ");
                }

                switch (choose)
                {
                    case 1:
                        appChamSoc.GhiLichSuChamSoc();
                        break;

                    case 2:
                        appChamSoc.HienThiLichSuTheoHocVien(view);
                        break;

                    case 3:
                        appChamSoc.HienThiLichHenHomNay(view);
                        break;

                    case 4:
                        appChamSoc.HienThiLichHenQuaHan(view);
                        break;

                    case 5:
                        appChamSoc.ThongKeKetQuaChamSoc();
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
        static void QuanLyDangKyKhoaHoc(MainMenu menu, AppDangKyKhoaHoc appDangKy,DangKyKhoaHocView view)
        {
            int choose = -1;
            view.DisplayListDangKy(appDangKy.GetDanhSachDangKy());
            while (choose != 0)
            {
                menu.ShowMenuDangKyHoc();

                Console.Write("Nhap lua chon: ");

                while (!int.TryParse(
                    Console.ReadLine(),
                    out choose))
                {
                    Console.Write(
                        "Nhap sai! Vui long nhap so: "
                    );
                }

                switch (choose)
                {
                    case 1:
                        appDangKy.DangKyKhoaHoc();
                        break;
                    case 2:
                        appDangKy.KiemTraLopConCho();
                        break;
                    case 3:
                        appDangKy.KiemTraDangKyTrungLop();
                        break;
                    case 4:
                        appDangKy.TinhSoTienConThieu();
                        break;
                    case 5:
                        appDangKy.GhiNhanThanhToan();
                        break;
                    case 6:
                        appDangKy.HuyDangKy();
                        break;
                    case 7:
                        appDangKy.ThongKeCongNo();
                        break;
                    case 0:
                        Console.WriteLine(
                            "Quay lai menu chinh..."
                        );
                        break;
                    default:
                        Console.WriteLine(
                            "Lua chon khong hop le!"
                        );
                        break;
                }
                if (choose != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine(
                        "Nhan phim bat ky de tiep tuc..."
                    );

                    Console.ReadKey();
                }
            }
        }
        static void QuanLyKhoaHoc( MainMenu menu,AppKhoaHoc appKhoaHoc,KhoaHocView viewkh)
        {
            int choose = -1;

            viewkh.DisplayListKhoaHoc(
                appKhoaHoc.GetDanhSachKhoaHoc()
            );

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
                        appKhoaHoc.ThemKhoaHoc();
                        viewkh.DisplayListKhoaHoc(
                            appKhoaHoc.GetDanhSachKhoaHoc()
                        );
                        break;
                    case 2:
                        appKhoaHoc.SuaKhoaHoc();
                        break;
                    case 3:
                        appKhoaHoc.XoaKhoaHoc();
                        break;
                    case 4:
                        appKhoaHoc.TimKiemKhoaHoc(viewkh);
                        break;
                    case 5:
                        appKhoaHoc.SapXepKhoaHoc(viewkh);
                        break;
                    case 6:
                        appKhoaHoc.LocTheoTrangThai(viewkh);
                        break;
                    case 7:
                        appKhoaHoc.ThongKeHocPhi();
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
                        viewhv.DisplayListHocVien(appHocVien.GetDanhSachHocVien());

                        break;

                    case 3:
                        // Xóa học viên
                        appHocVien.XoaHocVien();
                        viewhv.DisplayListHocVien(appHocVien.GetDanhSachHocVien());

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
                menu.ShowMeNuQLLH();

                Console.Write("Nhap lua chon: ");

                while (!int.TryParse(Console.ReadLine(), out choose))
                {
                    Console.Write("Nhap sai! Vui long nhap so: ");
                }

                switch (choose)
                {
                    case 1:
                        // Thêm học viên
                        appLopHoc.ThemLopHoc();
                        viewlh.DisplayListLopHoc(appLopHoc.GetDanhSachLopHoc());
                        break;
                    case 2:
                        appLopHoc.CapNhatLop();
                        viewlh.DisplayListLopHoc(appLopHoc.GetDanhSachLopHoc());
                        break;
                    case 3:
                        appLopHoc.KiemTraSiSo();
                        break;
                    case 4:
                        appLopHoc.HienThiLopSapKhaiGiang(viewlh);
                        break;
                    case 5:
                        appLopHoc.HienThiLopDangHoc(viewlh);
                        break;
                    case 6:
                        appLopHoc.XoaLopHoc();
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