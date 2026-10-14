using System;
using System.Collections.Generic;
using System.Text;

namespace BXLBT4.src.DevmasterTrainingManagement.Domain
{
    internal class DangKyKhoaHoc
    {
        public string MaDangKy { get; set; }
        public HocVien HocVien { get; set; }
        public LopHoc LopHoc { get; set; }
        public DateTime NgayDangKy { get; set; }
        public decimal HocPhi { get; set; }
        public decimal SoTienDaDong { get; set; }
        public string TrangThaiThanhToan { get; set; }

      
        public DangKyKhoaHoc()
        {
        }

       
        public DangKyKhoaHoc(
            string maDangKy,
            HocVien hocVien,
            LopHoc lopHoc,
            DateTime ngayDangKy,
            decimal hocPhi,
            decimal soTienDaDong,
            string trangThaiThanhToan)
        {
            this.MaDangKy = maDangKy;
            this.HocVien = hocVien;
            this.LopHoc = lopHoc;
            this.NgayDangKy = ngayDangKy;
            this.HocPhi = hocPhi;
            this.SoTienDaDong = soTienDaDong;
            this.TrangThaiThanhToan = trangThaiThanhToan;
        }
    }
}
