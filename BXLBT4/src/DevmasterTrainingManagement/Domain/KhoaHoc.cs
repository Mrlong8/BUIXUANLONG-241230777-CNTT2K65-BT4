using System;
using System.Collections.Generic;
using System.Text;

namespace BXLBT4.src.DevmasterTrainingManagement.Domain
{
    internal class KhoaHoc
    {
        public string maKH { get; set; }
        public string nameKH { get; set; }
        public decimal hocPhi { get; set; }
        public float thoiLuong { get; set; }
        public string moTa { get; set; }
        public string trangThai { get; set; }

        public KhoaHoc() { }
        public KhoaHoc(
            string maKH,
            string nameKH,
            decimal hocPhi,
            float thoiLuong,
            string moTa,
            string trangThai
        )
        {
            this.maKH = maKH;
            this.nameKH = nameKH;
            this.hocPhi = hocPhi;
            this.thoiLuong = thoiLuong;
            this.moTa = moTa;
            this.trangThai = trangThai;
        }
    }
}
