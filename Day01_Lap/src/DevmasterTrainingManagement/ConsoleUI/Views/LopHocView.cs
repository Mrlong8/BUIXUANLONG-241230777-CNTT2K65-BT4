using BXLBT4.src.DevmasterTrainingManagement.Domain;
using System;
using System.Collections.Generic;

namespace BXLBT4.src.DevmasterTrainingManagement.ConsoleUI.Views
{
    internal class LopHocView
    {
        public void DisplayTitle()
        {
            Console.WriteLine();

            Console.WriteLine(
                "================================================================================================================"
            );

            Console.WriteLine(
                "|                                               DANH SACH LOP HOC                                              |"
            );

            Console.WriteLine(
                "================================================================================================================"
            );

            Console.WriteLine(
                "| {0,-8} | {1,-25} | {2,-18} | {3,-12} | {4,-25} | {5,-10} | {6,-15} |",
                "Ma Lop",
                "Ten Lop",
                "Khoa Hoc",
                "Khai Giang",
                "Lich Hoc",
                "Si So",
                "Trang Thai"
            );

            Console.WriteLine(
                "----------------------------------------------------------------------------------------------------------------"
            );
        }


        public void DisplayLopHoc(LopHoc lopHoc)
        {
            Console.WriteLine(
                "| {0,-8} | {1,-25} | {2,-18} | {3,-12} | {4,-25} | {5,-10} | {6,-15} |",
                lopHoc.MaLop,
                lopHoc.TenLop,
                lopHoc.KhoaHoc,
                lopHoc.NgayKhaiGiang.ToString("dd/MM/yyyy"),
                lopHoc.LichHoc,
                lopHoc.SiSoToiDa,
                lopHoc.TrangThai
            );
        }


        public void DisplayListLopHoc(List<LopHoc> danhSachLopHoc)
        {
            DisplayTitle();

            foreach (LopHoc lopHoc in danhSachLopHoc)
            {
                DisplayLopHoc(lopHoc);
            }

            Console.WriteLine(
                "================================================================================================================"
            );
        }
    }
}