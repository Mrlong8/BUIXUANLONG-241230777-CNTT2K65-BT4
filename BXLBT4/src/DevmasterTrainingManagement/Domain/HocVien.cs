using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BXLBT4.src.DevmasterTrainingManagement.Domain
{
    internal class HocVien
    {
        public string maHV { get; set; }
        public string hoTen { get; set; }
        public DateTime ngaySinh { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string diaChi { get; set; }
        public DateTime ngayDangKy { get; set; }

        public HocVien() { }
        public HocVien(
            string maHV,
            string hoTen,
            DateTime ngaySinh,
            string phone,
            string email,
            string diaChi,
            DateTime ngayDangky)
        {
            this.maHV = maHV;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.phone = phone;
            this.email = email;
            this.diaChi = diaChi;
            this.ngayDangKy = ngayDangky;
        }
    }
}
