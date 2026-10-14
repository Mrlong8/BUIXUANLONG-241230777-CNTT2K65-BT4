using BXLBT4.src.DevmasterTrainingManagement.ConsoleUI.Views;
using BXLBT4.src.DevmasterTrainingManagement.Domain;
using BXLBT4.src.DevmasterTrainingManagement.Infrastructure;

namespace BXLBT4.src.DevmasterTrainingManagement.Application
{
    internal class AppDangKyKhoaHoc
    {
        private List<DangKyKhoaHoc> danhSachDangKy;

        private DangKyKhoaHocRepository repository;

        private AppLopHoc appLopHoc;

        private ApplctHocVien appHocVien;

        public AppDangKyKhoaHoc(
            DangKyKhoaHocRepository repository,
            AppLopHoc appLopHoc,
            ApplctHocVien appHocVien)
        {
            this.repository = repository;

            this.appLopHoc = appLopHoc;

            this.appHocVien = appHocVien;

            danhSachDangKy = repository.LoadData();
        }

        public List<DangKyKhoaHoc> GetDanhSachDangKy()
        {
            return danhSachDangKy;
        }

        public void DangKyKhoaHoc()
        {
            Console.WriteLine();
            Console.WriteLine("========== DANG KY KHOA HOC ==========");

            Console.Write("Nhap ma dang ky: ");
            string maDangKy = Console.ReadLine() ?? "";

            if (danhSachDangKy.Any(x => x.MaDangKy == maDangKy))
            {
                Console.WriteLine("Ma dang ky da ton tai!");
                return;
            }

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

            Console.Write("Nhap ma lop: ");
            string maLop = Console.ReadLine() ?? "";

            LopHoc? lopHoc = appLopHoc
                .GetDanhSachLopHoc()
                .FirstOrDefault(x => x.MaLop == maLop);

            if (lopHoc == null)
            {
                Console.WriteLine("Khong tim thay lop hoc!");
                return;
            }

        

            int soHocVien = danhSachDangKy.Count(
                x => x.LopHoc?.MaLop == maLop
            );

            if (soHocVien >= lopHoc.SiSoToiDa)
            {
                Console.WriteLine("Lop da day!");
                return;
            }

            bool daDangKy = danhSachDangKy.Any(
                x =>
                    x.HocVien?.maHV == maHV
                    && x.LopHoc?.MaLop == maLop
                    && x.TrangThaiThanhToan != "Da huy"
            );

            if (daDangKy)
            {
                Console.WriteLine(
                    "Hoc vien da dang ky lop nay!"
                );

                return;
            }

            Console.Write("Nhap hoc phi: ");

            decimal hocPhi;

            while (!decimal.TryParse(Console.ReadLine(), out hocPhi)
                   || hocPhi < 0)
            {
                Console.Write("Hoc phi khong hop le. Nhap lai: ");
            }

            Console.Write("Nhap so tien da dong: ");

            decimal soTienDaDong;

            while (!decimal.TryParse(
                Console.ReadLine(),
                out soTienDaDong)
                || soTienDaDong < 0
                || soTienDaDong > hocPhi)
            {
                Console.Write(
                    "So tien khong hop le. Nhap lai: "
                );
            }

            string trangThaiThanhToan;

            if (soTienDaDong == 0)
            {
                trangThaiThanhToan = "Chua thanh toan";
            }
            else if (soTienDaDong < hocPhi)
            {
                trangThaiThanhToan = "Con thieu";
            }
            else
            {
                trangThaiThanhToan = "Da thanh toan";
            }

            DangKyKhoaHoc dangKy = new DangKyKhoaHoc(
                maDangKy,
                hocVien,
                lopHoc,
                DateTime.Now,
                hocPhi,
                soTienDaDong,
                trangThaiThanhToan
            );

            danhSachDangKy.Add(dangKy);

            repository.SaveData(danhSachDangKy);

            Console.WriteLine();
            Console.WriteLine("Dang ky khoa hoc thanh cong!");
            Console.WriteLine(
                $"Hoc vien: {hocVien.hoTen}"
            );
            Console.WriteLine(
                $"Lop: {lopHoc.TenLop}"
            );
            Console.WriteLine(
                $"Hoc phi: {hocPhi:N0}"
            );
            Console.WriteLine(
                $"Da dong: {soTienDaDong:N0}"
            );
            Console.WriteLine(
                $"Con thieu: {(hocPhi - soTienDaDong):N0}"
            );
        }

        public void KiemTraLopConCho()
        {
            Console.Write("Nhap ma lop: ");

            string maLop = Console.ReadLine() ?? "";

            LopHoc? lopHoc = appLopHoc
                .GetDanhSachLopHoc()
                .FirstOrDefault(x => x.MaLop == maLop);

            if (lopHoc == null)
            {
                Console.WriteLine("Khong tim thay lop!");
                return;
            }

            int soLuongHienTai = danhSachDangKy.Count(
                x =>
                    x.LopHoc?.MaLop == maLop
                    && x.TrangThaiThanhToan != "Da huy"
            );

            int soChoConLai =
                lopHoc.SiSoToiDa - soLuongHienTai;

            Console.WriteLine();
            Console.WriteLine($"Lop: {lopHoc.TenLop}");
            Console.WriteLine($"Si so toi da: {lopHoc.SiSoToiDa}");
            Console.WriteLine($"Da dang ky: {soLuongHienTai}");
            Console.WriteLine($"Con lai: {soChoConLai}");

            if (soChoConLai > 0)
            {
                Console.WriteLine("Lop van con cho.");
            }
            else
            {
                Console.WriteLine("Lop da day.");
            }
        }

        public void KiemTraDangKyTrungLop()
        {
            Console.Write("Nhap ma hoc vien: ");
            string maHV = Console.ReadLine() ?? "";

            Console.Write("Nhap ma lop: ");
            string maLop = Console.ReadLine() ?? "";

            bool daDangKy = danhSachDangKy.Any(
                x =>
                    x.HocVien?.maHV == maHV
                    && x.LopHoc?.MaLop == maLop
                    && x.TrangThaiThanhToan != "Da huy"
            );

            if (daDangKy)
            {
                Console.WriteLine(
                    "Hoc vien da dang ky lop nay!"
                );
            }
            else
            {
                Console.WriteLine(
                    "Hoc vien chua dang ky lop nay."
                );
            }
        }

        public void TinhSoTienConThieu()
        {
            Console.Write("Nhap ma dang ky: ");

            string maDangKy = Console.ReadLine() ?? "";

            DangKyKhoaHoc? dangKy = danhSachDangKy
                .FirstOrDefault(x => x.MaDangKy == maDangKy);

            if (dangKy == null)
            {
                Console.WriteLine("Khong tim thay dang ky!");
                return;
            }

            decimal conThieu =
                dangKy.HocPhi - dangKy.SoTienDaDong;

            Console.WriteLine();
            Console.WriteLine(
                $"Hoc phi: {dangKy.HocPhi:N0}"
            );

            Console.WriteLine(
                $"Da dong: {dangKy.SoTienDaDong:N0}"
            );

            Console.WriteLine(
                $"Con thieu: {conThieu:N0}"
            );
        }

        public void GhiNhanThanhToan()
        {
            Console.Write("Nhap ma dang ky: ");

            string maDangKy = Console.ReadLine() ?? "";

            DangKyKhoaHoc? dangKy = danhSachDangKy
                .FirstOrDefault(x => x.MaDangKy == maDangKy);

            if (dangKy == null)
            {
                Console.WriteLine("Khong tim thay dang ky!");
                return;
            }

            decimal conThieu =
                dangKy.HocPhi - dangKy.SoTienDaDong;

            Console.WriteLine(
                $"So tien con thieu: {conThieu:N0}"
            );

            Console.Write("Nhap so tien thanh toan: ");

            decimal soTien;

            while (!decimal.TryParse(
                Console.ReadLine(),
                out soTien)
                || soTien <= 0
                || soTien > conThieu)
            {
                Console.Write("So tien khong hop le. Nhap lai: ");
            }

            dangKy.SoTienDaDong += soTien;

            if (dangKy.SoTienDaDong >= dangKy.HocPhi)
            {
                dangKy.TrangThaiThanhToan =
                    "Da thanh toan";
            }
            else
            {
                dangKy.TrangThaiThanhToan =
                    "Con thieu";
            }

            repository.SaveData(danhSachDangKy);

            Console.WriteLine(
                "Ghi nhan thanh toan thanh cong!"
            );
        }

        public void HuyDangKy()
        {
            Console.Write("Nhap ma dang ky can huy: ");

            string maDangKy = Console.ReadLine() ?? "";

            DangKyKhoaHoc? dangKy = danhSachDangKy
                .FirstOrDefault(x => x.MaDangKy == maDangKy);

            if (dangKy == null)
            {
                Console.WriteLine("Khong tim thay dang ky!");
                return;
            }

            if (dangKy.TrangThaiThanhToan == "Da huy")
            {
                Console.WriteLine("Dang ky nay da bi huy!");
                return;
            }

            dangKy.TrangThaiThanhToan = "Da huy";

            repository.SaveData(danhSachDangKy);

            Console.WriteLine("Huy dang ky thanh cong!");
        }

        public void ThongKeCongNo()
        {
            decimal tongHocPhi = danhSachDangKy
                .Where(x => x.TrangThaiThanhToan != "Da huy")
                .Sum(x => x.HocPhi);

            decimal tongDaDong = danhSachDangKy
                .Where(x => x.TrangThaiThanhToan != "Da huy")
                .Sum(x => x.SoTienDaDong);

            decimal tongConThieu =
                tongHocPhi - tongDaDong;

            int soNguoiConNo = danhSachDangKy
                .Count(
                    x =>
                        x.TrangThaiThanhToan == "Con thieu"
                        || x.TrangThaiThanhToan == "Chua thanh toan"
                );

            Console.WriteLine();
            Console.WriteLine("========== THONG KE CONG NO ==========");

            Console.WriteLine(
                $"Tong hoc phi : {tongHocPhi:N0}"
            );

            Console.WriteLine(
                $"Tong da dong : {tongDaDong:N0}"
            );

            Console.WriteLine(
                $"Tong con thieu : {tongConThieu:N0}"
            );

            Console.WriteLine(
                $"So hoc vien con no : {soNguoiConNo}"
            );
        }
    }
}