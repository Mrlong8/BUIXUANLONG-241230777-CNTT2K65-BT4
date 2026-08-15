using System;
using System.Collections.Generic;
using System.Text;

namespace BXLBT4.src.DevmasterTrainingManagement.Domain
{
    internal class LopHoc
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string KhoaHoc { get; set; }
        public DateTime NgayKhaiGiang { get; set; }
        public string LichHoc { get; set; }
        public int SiSoToiDa { get; set; }
        public string TrangThai { get; set; }


        public LopHoc()
        {
        }


        public LopHoc(
            string maLop,
            string tenLop,
            string khoaHoc,
            DateTime ngayKhaiGiang,
            string lichHoc,
            int siSoToiDa,
            string trangThai)
        {
            this.MaLop = maLop;
            this.TenLop = tenLop;
            this.KhoaHoc = khoaHoc;
            this.NgayKhaiGiang = ngayKhaiGiang;
            this.LichHoc = lichHoc;
            this.SiSoToiDa = siSoToiDa;
            this.TrangThai = trangThai;
        }
    }
    
}
