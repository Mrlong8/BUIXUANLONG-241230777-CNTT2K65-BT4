using BXLBT4.src.DevmasterTrainingManagement.Domain;
using BXLBT4.src.DevmasterTrainingManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Globalization;
using BXLBT4.src.DevmasterTrainingManagement.ConsoleUI.Views;

namespace BXLBT4.src.DevmasterTrainingManagement.Application
{
    internal class AppLopHoc
    {
        private List<LopHoc> danhSachLopHoc;
        private LopHocRepository repository;

        public AppLopHoc(LopHocRepository repository)
        {
            this.repository = repository;
            danhSachLopHoc = repository.LoadData();
        }

        public void ThemLopHoc()
        {
            Console.WriteLine();
            Console.WriteLine("========== THEM LOP HOC ==========");

            Console.Write("Nhap ma Lop Hoc: ");
            string MaLop = Console.ReadLine() ?? "";

            Console.Write("Nhap Ten Lop : ");
            string tenLop = Console.ReadLine() ?? "";

            Console.Write("Nhap Khoa Hoc : ");
            string KhoaHoc = Console.ReadLine() ?? "";

            DateTime ngayKhaiGiang;

            Console.Write("Nhap ngay khai giang (dd/MM/yyyy): ");

            while (!DateTime.TryParse(
                Console.ReadLine(),
                out ngayKhaiGiang))
            {
                Console.Write("Ngay khong hop le, nhap lai: ");
            }

            Console.Write("Nhap Lich Hoc : ");
            string lichHoc = Console.ReadLine() ?? "";

            Console.Write("Nhap si so toi da: ");
            int siSoToida;
            //TryParse() nếu nhập số thì trả về true còn ko thì trả vef false
            while (!int.TryParse(Console.ReadLine(), out siSoToida)
                   || siSoToida <= 0)
            {
                Console.Write("Si so phai la so nguyen > 0. Nhap lai: ");
            }

            Console.Write("Nhap Trang Thai : ");
            string TrangThai = Console.ReadLine() ?? "";

            LopHoc lopHoc = new LopHoc(
                MaLop,
                tenLop,
                KhoaHoc,
                ngayKhaiGiang,
                lichHoc,
                siSoToida,
                TrangThai

            );
            
            danhSachLopHoc.Add(lopHoc);
            repository.SaveData(danhSachLopHoc);
            Console.WriteLine("Them lop thanh cong ");
        }

        public void CapNhatLop()
        {
            Console.WriteLine();
            Console.WriteLine("========== CAP NHAT LOP ==========");

            Console.WriteLine("Nhap ma lop hoc can sua : ");
            string maLop = Console.ReadLine() ?? "";
            LopHoc? lopHoc = danhSachLopHoc.FirstOrDefault(x => x.MaLop == maLop);

            if (lopHoc == null)
            {
                Console.WriteLine("Khong tim thay hoc vien");
                return;
            }

            Console.Write("Nhap Ten Lop Moi : ");
            lopHoc.TenLop = Console.ReadLine() ?? "";

            Console.Write("Nhap Khoa Hoc Moi : ");
            lopHoc.KhoaHoc = Console.ReadLine() ?? "";

            DateTime ngayKhaiGiang;

            Console.Write("Nhap ngay khai giang moi (dd/MM/yyyy): ");

            while (!DateTime.TryParse(
                Console.ReadLine(),
                out ngayKhaiGiang))
            {
                Console.Write("Ngay khong hop le, nhap lai: ");
            }
            lopHoc.NgayKhaiGiang = ngayKhaiGiang;

            Console.Write("Nhap Lich Hoc moi : ");
            lopHoc.LichHoc= Console.ReadLine() ?? "";

            Console.Write("Nhap si so toi da moi: ");
            int siSoToida;
            //TryParse() nếu nhập số thì trả về true còn ko thì trả vef false
            while (!int.TryParse(Console.ReadLine(), out siSoToida)
                   || siSoToida <= 0)
            {
                Console.Write("Si so phai la so nguyen > 0. Nhap lai: ");
            }
            lopHoc.SiSoToiDa =siSoToida;

            Console.Write("Nhap Trang Thai moi : ");
            lopHoc.TrangThai = Console.ReadLine() ?? "";

            repository.SaveData(danhSachLopHoc);
            Console.WriteLine("Cap nhat lop hoc thanh cong");

        }

        public List<LopHoc> GetDanhSachLopHoc()
        {
            return danhSachLopHoc;
        }

        public void KiemTraSiSo()
        {
            Console.WriteLine("Nhap ma lop can kiem tra : ");
            string makt = Console.ReadLine();
            foreach (LopHoc item in danhSachLopHoc)
            {
                if (item.MaLop == makt)
                {
                    Console.WriteLine(" Si SO la : " + item.SiSoToiDa);
                }
            }

           
        }

        public void HienThiLopSapKhaiGiang(LopHocView view)
        {

            bool timThay = false;

            foreach (LopHoc item in danhSachLopHoc)
            {
                if (item.TrangThai == "Sap Khai Giang")
                {
                    view.DisplayLopHoc(item);
                    timThay = true;
                }
            }

            if (!timThay)
            {
                Console.WriteLine("Khong tim thay lop hoc sap khai giang");
            }
        }
        public void HienThiLopDangHoc(LopHocView view)
        {

            bool timThay = false;

            foreach (LopHoc item in danhSachLopHoc)
            {
                if (item.TrangThai == "Dang Hoc")
                {
                    view.DisplayLopHoc(item);
                    timThay = true;
                }
            }

            if (!timThay)
            {
                Console.WriteLine("Khong tim thay lop dang hoc");
            }
        }

        public void XoaLopHoc()
        {
            Console.WriteLine();
            Console.WriteLine("========== XOA LOP HOC ==========");

            Console.Write("Nhap ma lop hoc can xoa: ");
            string maLH = Console.ReadLine() ?? "";
            LopHoc? lopHoc = danhSachLopHoc.FirstOrDefault(x => x.MaLop == maLH);


            if (lopHoc == null)
            {
                Console.WriteLine("Khong tim thay hoc vien!");
                return;
            }
            Console.Write(
               $"Ban co chac muon xoa {lopHoc.TenLop}? (Y/N): "
           );
            string answer = Console.ReadLine() ?? "";

            if (answer.ToUpper() != "Y")
            {
                Console.WriteLine("Da huy thao tac xoa.");
                return;
            }

            danhSachLopHoc.Remove(lopHoc);
            repository.SaveData(danhSachLopHoc);
            Console.WriteLine(" Xoa Thanh cong");
        }

    }
}
