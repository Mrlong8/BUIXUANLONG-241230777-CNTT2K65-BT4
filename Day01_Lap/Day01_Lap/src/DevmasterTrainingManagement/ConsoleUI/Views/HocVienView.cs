using BXLBT4.src.DevmasterTrainingManagement.Application;
using BXLBT4.src.DevmasterTrainingManagement.ConsoleUI.Menus;
using BXLBT4.src.DevmasterTrainingManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BXLBT4.src.DevmasterTrainingManagement.ConsoleUI.Views
{
    internal class HocVienView
    {
        public void DisplayTitle()
        {
            Console.WriteLine();
            Console.WriteLine("================================================================================================");
            Console.WriteLine("|                                      DANH SACH HOC VIEN                                      |");
            Console.WriteLine("================================================================================================");

            Console.WriteLine(
                "| {0,-10} | {1,-22} | {2,-12} | {3,-12} | {4,-25} | {5,-15} | {6,-15} |",
                "Ma HV",
                "Ho Ten",
                "Ngay Sinh",
                "Phone",
                "Email",
                "Dia Chi",
                "Ngay Dang Ky"
            );

            Console.WriteLine("------------------------------------------------------------------------------------------------");
        }

        public void DisplayStudent(HocVien student)
        {
            Console.WriteLine(
                "| {0,-10} | {1,-22} | {2,-12} | {3,-12} | {4,-25} | {5,-15} | {6,-15} |",
                student.maHV,
                student.hoTen,
                student.ngaySinh.ToString("dd/MM/yyyy"),
                student.phone,
                student.email,
                student.diaChi,
                student.ngayDangKy.ToString("dd/MM/yyyy")
            );
        }

        public void DisplayListHocVien(List<HocVien> danhSachHocVien)
        {
            DisplayTitle();

            foreach (HocVien student in danhSachHocVien)
            {
                DisplayStudent(student);
            }

            Console.WriteLine("================================================================================================");
        }
      
    }
}
