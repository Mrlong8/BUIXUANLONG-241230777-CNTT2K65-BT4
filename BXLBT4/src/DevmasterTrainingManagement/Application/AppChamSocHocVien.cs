using BXLBT4.src.DevmasterTrainingManagement.Domain;
using BXLBT4.src.DevmasterTrainingManagement.Infrastructure;
using BXLBT4.src.DevmasterTrainingManagement.ConsoleUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BXLBT4.src.DevmasterTrainingManagement.Application
{
    internal class AppChamSocHocVien
    {
        private List<ChamSocHocVien> danhSachChamSoc;
        private ChamSocHocVienRepository repository;
        private ApplctHocVien appHocVien;

        public AppChamSocHocVien(
            ChamSocHocVienRepository repository,
            ApplctHocVien appHocVien)
        {
            this.repository = repository;
            this.appHocVien = appHocVien;

            danhSachChamSoc = repository.LoadData();
        }

        public List<ChamSocHocVien> GetDanhSachChamSoc()
        {
            return danhSachChamSoc;
        }

        public void GhiLichSuChamSoc()
        {
            Console.WriteLine();
            Console.WriteLine("========== GHI LICH SU CHAM SOC ==========");

            Console.Write("Nhap ma cham soc: ");
            string maChamSoc = Console.ReadLine() ?? "";

            Console.Write("Nhap ma hoc vien: ");
            string maHV = Console.ReadLine() ?? "";

            HocVien? hocVien = appHocVien
                .GetDanhSachHocVien()
                .FirstOrDefault(x => x.maHV == maHV);

            if (hocVien == null)
            {
                Console.WriteLine("Khong tim thay hoc vien!");
                return;
            }

            Console.Write("Nhap kenh lien he: ");
            string kenhLienHe = Console.ReadLine() ?? "";

            Console.Write("Nhap noi dung: ");
            string noiDung = Console.ReadLine() ?? "";

            Console.Write("Nhap ket qua: ");
            string ketQua = Console.ReadLine() ?? "";

            Console.Write("Nhap ngay hen tiep theo (dd/MM/yyyy), bo trong neu khong co: ");

            string inputNgayHen = Console.ReadLine() ?? "";

            DateTime? ngayHenTiepTheo = null;

            if (!string.IsNullOrWhiteSpace(inputNgayHen))
            {
                DateTime ngayHen;

                while (!DateTime.TryParse(inputNgayHen, out ngayHen))
                {
                    Console.Write("Ngay khong hop le, nhap lai: ");
                    inputNgayHen = Console.ReadLine() ?? "";
                }

                ngayHenTiepTheo = ngayHen;
            }

            ChamSocHocVien chamSoc = new ChamSocHocVien(
                maChamSoc,
                hocVien,
                DateTime.Now,
                kenhLienHe,
                noiDung,
                ketQua,
                ngayHenTiepTheo
            );

            danhSachChamSoc.Add(chamSoc);

            repository.SaveData(danhSachChamSoc);

            Console.WriteLine("Ghi lich su cham soc thanh cong!");
        }

        public void HienThiLichSuTheoHocVien(ChamSocHocVienView view)
        {
            Console.Write("Nhap ma hoc vien: ");
            string maHV = Console.ReadLine() ?? "";

            List<ChamSocHocVien> ketQua =
                danhSachChamSoc
                .Where(x => x.hocVien != null &&
                            x.hocVien.maHV == maHV)
                .ToList();

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong tim thay lich su cham soc!");
                return;
            }

            view.DisplayListChamSoc(ketQua);
        }

        public void HienThiLichHenHomNay(ChamSocHocVienView view)
        {
            DateTime homNay = DateTime.Today;

            List<ChamSocHocVien> ketQua =
                danhSachChamSoc
                .Where(x => x.NgayHenTiepTheo.HasValue &&
                            x.NgayHenTiepTheo.Value.Date == homNay)
                .ToList();

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Hom nay khong co lich hen!");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("========== LICH HEN HOM NAY ==========");

            foreach (ChamSocHocVien item in ketQua)
            {
                view.DisplayLichHen(item);
            }
        }

        public void HienThiLichHenQuaHan(ChamSocHocVienView view)
        {
            DateTime homNay = DateTime.Today;

            List<ChamSocHocVien> ketQua =
                danhSachChamSoc
                .Where(x => x.NgayHenTiepTheo.HasValue &&
                            x.NgayHenTiepTheo.Value.Date < homNay)
                .ToList();

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong co lich hen qua han!");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("========== LICH HEN QUA HAN ==========");

            foreach (ChamSocHocVien item in ketQua)
            {
                view.DisplayLichHen(item);
            }
        }

        public void ThongKeKetQuaChamSoc()
        {
            Console.WriteLine();
            Console.WriteLine("========== THONG KE KET QUA CHAM SOC ==========");

            if (danhSachChamSoc.Count == 0)
            {
                Console.WriteLine("Chua co du lieu cham soc!");
                return;
            }

            var thongKe = danhSachChamSoc
                .GroupBy(x => x.KetQua)
                .Select(x => new
                {
                    KetQua = x.Key,
                    SoLuong = x.Count()
                })
                .OrderByDescending(x => x.SoLuong);

            Console.WriteLine();
            Console.WriteLine("| {0,-50} | {1,-10} |",
                "Ket Qua",
                "So Luong");

            Console.WriteLine("---------------------------------------------------------------");

            foreach (var item in thongKe)
            {
                Console.WriteLine(
                    "| {0,-50} | {1,-10} |",
                    item.KetQua,
                    item.SoLuong
                );
            }

            Console.WriteLine("---------------------------------------------------------------");
        }
    }
}