using BXLBT4.src.DevmasterTrainingManagement.Domain;
using System;
using System.Collections.Generic;

namespace BXLBT4.src.DevmasterTrainingManagement.ConsoleUI.Views
{
    internal class ChamSocHocVienView
    {
        public void DisplayTitle()
        {
            Console.WriteLine();
            Console.WriteLine("====================================================================================================================");
            Console.WriteLine("|                                            LICH SU CHAM SOC HOC VIEN                                            |");
            Console.WriteLine("====================================================================================================================");

            Console.WriteLine(
                "| {0,-8} | {1,-10} | {2,-22} | {3,-18} | {4,-35} | {5,-25} | {6,-16} |",
                "Ma CS",
                "Ma HV",
                "Ngay Cham Soc",
                "Kenh Lien He",
                "Noi Dung",
                "Ket Qua",
                "Ngay Hen"
            );

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
        }

        public void DisplayChamSoc(ChamSocHocVien chamSoc)
        {
            string ngayHen = chamSoc.NgayHenTiepTheo.HasValue
                ? chamSoc.NgayHenTiepTheo.Value.ToString("dd/MM/yyyy")
                : "Khong co";

            Console.WriteLine(
                "| {0,-8} | {1,-10} | {2,-22} | {3,-18} | {4,-35} | {5,-25} | {6,-16} |",
                chamSoc.MaChamSoc,
                chamSoc.hocVien?.maHV ?? "N/A",
                chamSoc.NgayChamSoc.ToString("dd/MM/yyyy HH:mm"),
                chamSoc.KenhLienHe,
                chamSoc.NoiDung,
                chamSoc.KetQua,
                ngayHen
            );
        }

        public void DisplayListChamSoc(List<ChamSocHocVien> danhSachChamSoc)
        {
            DisplayTitle();

            if (danhSachChamSoc == null || danhSachChamSoc.Count == 0)
            {
                Console.WriteLine("|                                            KHONG CO DU LIEU                                            |");
            }
            else
            {
                foreach (ChamSocHocVien chamSoc in danhSachChamSoc)
                {
                    DisplayChamSoc(chamSoc);
                }
            }
            Console.WriteLine("====================================================================================================================");
        }

        public void DisplayLichHen(ChamSocHocVien chamSoc)
        {
            string ngayHen = chamSoc.NgayHenTiepTheo.HasValue
                ? chamSoc.NgayHenTiepTheo.Value.ToString("dd/MM/yyyy HH:mm")
                : "Khong co";

            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Ma cham soc     : {chamSoc.MaChamSoc}");
            Console.WriteLine($"Ma hoc vien     : {chamSoc.hocVien?.maHV ?? "N/A"}");
            Console.WriteLine($"Ho ten          : {chamSoc.hocVien?.hoTen ?? "N/A"}");
            Console.WriteLine($"Kenh lien he    : {chamSoc.KenhLienHe}");
            Console.WriteLine($"Noi dung        : {chamSoc.NoiDung}");
            Console.WriteLine($"Ket qua         : {chamSoc.KetQua}");
            Console.WriteLine($"Ngay hen        : {ngayHen}");
            Console.WriteLine("---------------------------------------------");
        }
    }
}