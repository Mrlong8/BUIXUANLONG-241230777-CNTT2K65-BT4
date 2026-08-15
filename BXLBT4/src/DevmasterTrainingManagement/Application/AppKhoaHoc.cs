using BXLBT4.src.DevmasterTrainingManagement.ConsoleUI.Views;
using BXLBT4.src.DevmasterTrainingManagement.Domain;
using BXLBT4.src.DevmasterTrainingManagement.Infrastructure;

namespace BXLBT4.src.DevmasterTrainingManagement.Application
{
    internal class AppKhoaHoc
    {
        private List<KhoaHoc> danhSachKhoaHoc;

        private KhoaHocRepository repository;

        public AppKhoaHoc(KhoaHocRepository repository)
        {
            this.repository = repository;

            danhSachKhoaHoc = repository.LoadData();
        }

        public List<KhoaHoc> GetDanhSachKhoaHoc()
        {
            return danhSachKhoaHoc;
        }

        public void ThemKhoaHoc()
        {
            Console.WriteLine();
            Console.WriteLine("========== THEM KHOA HOC ==========");

            Console.Write("Nhap ma khoa hoc: ");
            string maKH = Console.ReadLine() ?? "";

 
            if (danhSachKhoaHoc.Any(x => x.maKH == maKH))
            {
                Console.WriteLine("Ma khoa hoc da ton tai!");
                return;
            }

            Console.Write("Nhap ten khoa hoc: ");
            string nameKH = Console.ReadLine() ?? "";

            Console.Write("Nhap hoc phi: ");

            decimal hocPhi;

            while (!decimal.TryParse(Console.ReadLine(), out hocPhi)
                   || hocPhi < 0)
            {
                Console.Write("Hoc phi khong hop le. Nhap lai: ");
            }

            Console.Write("Nhap thoi luong: ");

            float thoiLuong;

            while (!float.TryParse(Console.ReadLine(), out thoiLuong)
                   || thoiLuong <= 0)
            {
                Console.Write("Thoi luong khong hop le. Nhap lai: ");
            }

            Console.Write("Nhap mo ta: ");
            string moTa = Console.ReadLine() ?? "";

            Console.WriteLine();
            Console.WriteLine("1. Dang mo");
            Console.WriteLine("2. Tam dung");
            Console.WriteLine("3. Da ket thuc");

            Console.Write("Chon trang thai: ");

            int chonTrangThai;

            while (!int.TryParse(Console.ReadLine(), out chonTrangThai)
                   || chonTrangThai < 1
                   || chonTrangThai > 3)
            {
                Console.Write("Lua chon khong hop le. Nhap lai: ");
            }

            string trangThai;

            switch (chonTrangThai)
            {
                case 1:
                    trangThai = "Dang mo";
                    break;

                case 2:
                    trangThai = "Tam dung";
                    break;

                default:
                    trangThai = "Da ket thuc";
                    break;
            }

            KhoaHoc khoaHoc = new KhoaHoc(
                maKH,
                nameKH,
                hocPhi,
                thoiLuong,
                moTa,
                trangThai
            );

            danhSachKhoaHoc.Add(khoaHoc);

            repository.SaveData(danhSachKhoaHoc);

            Console.WriteLine("Them khoa hoc thanh cong!");
        }


        public void SuaKhoaHoc()
        {
            Console.Write("Nhap ma khoa hoc can sua: ");
            string maKH = Console.ReadLine() ?? "";

            KhoaHoc? khoaHoc = danhSachKhoaHoc
                .FirstOrDefault(x => x.maKH == maKH);

            if (khoaHoc == null)
            {
                Console.WriteLine("Khong tim thay khoa hoc!");
                return;
            }

            Console.Write("Nhap ten moi: ");
            khoaHoc.nameKH = Console.ReadLine() ?? "";

            Console.Write("Nhap hoc phi moi: ");

            decimal hocPhi;

            while (!decimal.TryParse(Console.ReadLine(), out hocPhi)
                   || hocPhi < 0)
            {
                Console.Write("Hoc phi khong hop le. Nhap lai: ");
            }

            khoaHoc.hocPhi = hocPhi;

            Console.Write("Nhap thoi luong moi: ");

            float thoiLuong;

            while (!float.TryParse(Console.ReadLine(), out thoiLuong)
                   || thoiLuong <= 0)
            {
                Console.Write("Thoi luong khong hop le. Nhap lai: ");
            }

            khoaHoc.thoiLuong = thoiLuong;

            Console.Write("Nhap mo ta moi: ");
            khoaHoc.moTa = Console.ReadLine() ?? "";

            repository.SaveData(danhSachKhoaHoc);

            Console.WriteLine("Cap nhat khoa hoc thanh cong!");
        }


        public void XoaKhoaHoc()
        {
            Console.Write("Nhap ma khoa hoc can xoa: ");
            string maKH = Console.ReadLine() ?? "";

            KhoaHoc? khoaHoc = danhSachKhoaHoc
                .FirstOrDefault(x => x.maKH == maKH);

            if (khoaHoc == null)
            {
                Console.WriteLine("Khong tim thay khoa hoc!");
                return;
            }

            danhSachKhoaHoc.Remove(khoaHoc);

            repository.SaveData(danhSachKhoaHoc);

            Console.WriteLine("Xoa khoa hoc thanh cong!");
        }


        public void TimKiemKhoaHoc(KhoaHocView view)
        {
            Console.Write("Nhap tu khoa can tim: ");
            string keyword = Console.ReadLine() ?? "";

            List<KhoaHoc> ketQua = danhSachKhoaHoc
                .Where(x =>
                    x.maKH.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                    || x.nameKH.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                    || x.moTa.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                )
                .ToList();

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong tim thay khoa hoc!");
                return;
            }

            view.DisplayListKhoaHoc(ketQua);
        }


        public void SapXepKhoaHoc(KhoaHocView view)
        {
            Console.WriteLine();
            Console.WriteLine("1. Sap xep theo ten A-Z");
            Console.WriteLine("2. Sap xep theo hoc phi tang dan");
            Console.WriteLine("3. Sap xep theo hoc phi giam dan");

            Console.Write("Nhap lua chon: ");

            int choose;

            while (!int.TryParse(Console.ReadLine(), out choose))
            {
                Console.Write("Nhap sai. Nhap lai: ");
            }

            List<KhoaHoc> ketQua;

            switch (choose)
            {
                case 1:
                    ketQua = danhSachKhoaHoc
                        .OrderBy(x => x.nameKH)
                        .ToList();
                    break;

                case 2:
                    ketQua = danhSachKhoaHoc
                        .OrderBy(x => x.hocPhi)
                        .ToList();
                    break;

                case 3:
                    ketQua = danhSachKhoaHoc
                        .OrderByDescending(x => x.hocPhi)
                        .ToList();
                    break;

                default:
                    Console.WriteLine("Lua chon khong hop le!");
                    return;
            }

            view.DisplayListKhoaHoc(ketQua);
        }


        public void LocTheoTrangThai(KhoaHocView view)
        {
            Console.WriteLine();
            Console.WriteLine("1. Dang mo");
            Console.WriteLine("2. Tam dung");
            Console.WriteLine("3. Da ket thuc");

            Console.Write("Nhap lua chon: ");

            int choose;

            while (!int.TryParse(Console.ReadLine(), out choose))
            {
                Console.Write("Nhap sai. Nhap lai: ");
            }

            string trangThai;

            switch (choose)
            {
                case 1:
                    trangThai = "Dang mo";
                    break;

                case 2:
                    trangThai = "Tam dung";
                    break;

                case 3:
                    trangThai = "Da ket thuc";
                    break;

                default:
                    Console.WriteLine("Lua chon khong hop le!");
                    return;
            }

            List<KhoaHoc> ketQua = danhSachKhoaHoc
                .Where(x => x.trangThai == trangThai)
                .ToList();

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong co khoa hoc nao!");
                return;
            }

            view.DisplayListKhoaHoc(ketQua);
        }


        public void ThongKeHocPhi()
        {
            if (danhSachKhoaHoc.Count == 0)
            {
                Console.WriteLine("Chua co khoa hoc!");
                return;
            }

            decimal tongHocPhi = danhSachKhoaHoc
                .Sum(x => x.hocPhi);

            decimal hocPhiTrungBinh = danhSachKhoaHoc
                .Average(x => x.hocPhi);

            decimal hocPhiCaoNhat = danhSachKhoaHoc
                .Max(x => x.hocPhi);

            decimal hocPhiThapNhat = danhSachKhoaHoc
                .Min(x => x.hocPhi);

            Console.WriteLine();
            Console.WriteLine("========== THONG KE HOC PHI ==========");

            Console.WriteLine(
                "Tong hoc phi: {0:N0}",
                tongHocPhi
            );

            Console.WriteLine(
                "Hoc phi trung binh: {0:N0}",
                hocPhiTrungBinh
            );

            Console.WriteLine(
                "Hoc phi cao nhat: {0:N0}",
                hocPhiCaoNhat
            );

            Console.WriteLine(
                "Hoc phi thap nhat: {0:N0}",
                hocPhiThapNhat
            );
        }
    }
}