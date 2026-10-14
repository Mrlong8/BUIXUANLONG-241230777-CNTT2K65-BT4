using System;
using System.Collections.Generic;
using System.Text;

namespace BXLBT4.src.DevmasterTrainingManagement.Domain
{
    internal class ChamSocHocVien
    {
        public string MaChamSoc { get; set; }
        public HocVien hocVien { get; set; }
        public DateTime NgayChamSoc { get; set; }
        public string KenhLienHe { get; set; }
        public string NoiDung { get; set; }
        public string KetQua { get; set; }
        public DateTime? NgayHenTiepTheo { get; set; }

   
        public ChamSocHocVien()
        {
        }

 
        public ChamSocHocVien(
            string maChamSoc,
            HocVien hocVien,
            DateTime ngayChamSoc,
            string kenhLienHe,
            string noiDung,
            string ketQua,
            DateTime? ngayHenTiepTheo)
        {
            this.MaChamSoc = maChamSoc;
            this.hocVien = hocVien;
            this.NgayChamSoc = ngayChamSoc;
            this.KenhLienHe = kenhLienHe;
            this.NoiDung = noiDung;
            this.KetQua = ketQua;
            this.NgayHenTiepTheo = ngayHenTiepTheo;
        }
    }
}
