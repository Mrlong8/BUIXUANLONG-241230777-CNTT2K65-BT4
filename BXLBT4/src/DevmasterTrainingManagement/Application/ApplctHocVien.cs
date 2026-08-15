using BXLBT4.src.DevmasterTrainingManagement.Domain;
using BXLBT4.src.DevmasterTrainingManagement.Infrastructure;

namespace BXLBT4.src.DevmasterTrainingManagement.Application
{
    internal class ApplctHocVien
    {
        private List<HocVien> danhSachHocVien;

        private HocVienRepository repository;

        public ApplctHocVien(HocVienRepository repository)
        {
            this.repository = repository;

            danhSachHocVien = repository.LoadData();
        }

        public void ThemHocVien()
        {
            Console.WriteLine();
            Console.WriteLine("========== THEM HOC VIEN ==========");

            Console.Write("Nhap ma hoc vien: ");
            string maHV = Console.ReadLine() ?? "";

            Console.Write("Nhap ho ten: ");
            string hoTen = Console.ReadLine() ?? "";

            Console.Write("Nhap ngay sinh (dd/MM/yyyy): ");

            DateTime ngaySinh;

            while (!DateTime.TryParse(Console.ReadLine(), out ngaySinh))
            {
                Console.Write("Ngay sinh khong hop le, nhap lai: ");
            }

            Console.Write("Nhap so dien thoai: ");
            string phone = Console.ReadLine() ?? "";

          
            if (KiemTraTrungPhone(phone))
            {
                Console.WriteLine("So dien thoai da ton tai!");
                return;
            }

            Console.Write("Nhap email: ");
            string email = Console.ReadLine() ?? "";

            Console.Write("Nhap dia chi: ");
            string diaChi = Console.ReadLine() ?? "";

            HocVien hocVien = new HocVien(
                maHV,
                hoTen,
                ngaySinh,
                phone,
                email,
                diaChi,
                DateTime.Now
            );

            danhSachHocVien.Add(hocVien);

            repository.SaveData(danhSachHocVien);

            Console.WriteLine("Them hoc vien thanh cong!");
        }

        public void SuaHocVien()
        {
            Console.WriteLine();
            Console.WriteLine("========== SUA HOC VIEN ==========");

            Console.Write("Nhap ma hoc vien can sua: ");
            string maHV = Console.ReadLine() ?? "";

            HocVien? hocVien = danhSachHocVien
                .FirstOrDefault(x => x.maHV == maHV);

            if (hocVien == null)
            {
                Console.WriteLine("Khong tim thay hoc vien!");
                return;
            }

            Console.Write("Nhap ho ten moi: ");
            hocVien.hoTen = Console.ReadLine() ?? "";

            Console.Write("Nhap ngay sinh moi (dd/MM/yyyy): ");

            DateTime ngaySinh;

            while (!DateTime.TryParse(Console.ReadLine(), out ngaySinh))
            {
                Console.Write("Ngay sinh khong hop le, nhap lai: ");
            }

            hocVien.ngaySinh = ngaySinh;

            Console.Write("Nhap so dien thoai moi: ");
            string phoneMoi = Console.ReadLine() ?? "";

            bool trungPhone = danhSachHocVien.Any(
                x => x.phone == phoneMoi && x.maHV != maHV
            );

            if (trungPhone)
            {
                Console.WriteLine("So dien thoai da ton tai!");
                return;
            }

            hocVien.phone = phoneMoi;

            Console.Write("Nhap email moi: ");
            hocVien.email = Console.ReadLine() ?? "";

            Console.Write("Nhap dia chi moi: ");
            hocVien.diaChi = Console.ReadLine() ?? "";

            repository.SaveData(danhSachHocVien);

            Console.WriteLine("Sua hoc vien thanh cong!");
        }


        public void XoaHocVien()
        {
            Console.WriteLine();
            Console.WriteLine("========== XOA HOC VIEN ==========");

            Console.Write("Nhap ma hoc vien can xoa: ");
            string maHV = Console.ReadLine() ?? "";

            HocVien? hocVien = danhSachHocVien
                .FirstOrDefault(x => x.maHV == maHV);

            if (hocVien == null)
            {
                Console.WriteLine("Khong tim thay hoc vien!");
                return;
            }

            Console.Write(
                $"Ban co chac muon xoa {hocVien.hoTen}? (Y/N): "
            );

            string answer = Console.ReadLine() ?? "";

            if (answer.ToUpper() != "Y")
            {
                Console.WriteLine("Da huy thao tac xoa.");
                return;
            }

            danhSachHocVien.Remove(hocVien);

            repository.SaveData(danhSachHocVien);

            Console.WriteLine("Xoa hoc vien thanh cong!");
        }

        public bool KiemTraTrungPhone(string phone)
        {
            return danhSachHocVien.Any(
                x => x.phone == phone
            );
        }

        public void KiemTraTrungDienThoai()
        {
            Console.WriteLine();
            Console.WriteLine("====== KIEM TRA SO DIEN THOAI ======");

            Console.Write("Nhap so dien thoai: ");
            string phone = Console.ReadLine() ?? "";

            if (KiemTraTrungPhone(phone))
            {
                Console.WriteLine(
                    "So dien thoai nay da ton tai trong he thong!"
                );
            }
            else
            {
                Console.WriteLine(
                    "So dien thoai chua ton tai."
                );
            }
        }

        public void TimTheoTen()
        {
            Console.WriteLine();
            Console.WriteLine("========== TIM THEO TEN ==========");

            Console.Write("Nhap ten can tim: ");
            string ten = Console.ReadLine() ?? "";

            List<HocVien> ketQua = danhSachHocVien
                .Where(hv =>
                    hv.hoTen.Contains(
                        ten,
                        StringComparison.OrdinalIgnoreCase
                    )
                )
                .ToList();

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong tim thay hoc vien!");
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Tim thay {ketQua.Count} hoc vien:");

            foreach (HocVien hv in ketQua)
            {
                Console.WriteLine(
                    $"Ma: {hv.maHV} | " +
                    $"Ho ten: {hv.hoTen} | " +
                    $"Phone: {hv.phone} | " +
                    $"Email: {hv.email}"
                );
            }
        }


        public void TimTheoDienThoai()
        {
            Console.WriteLine();
            Console.WriteLine("====== TIM THEO DIEN THOAI ======");

            Console.Write("Nhap so dien thoai: ");
            string phone = Console.ReadLine() ?? "";

            HocVien? hocVien = danhSachHocVien
                .FirstOrDefault(x => x.phone == phone);

            if (hocVien == null)
            {
                Console.WriteLine("Khong tim thay hoc vien!");
                return;
            }

            Console.WriteLine(
                $"{hocVien.maHV} - " +
                $"{hocVien.hoTen} - " +
                $"{hocVien.phone} - " +
                $"{hocVien.email}"
            );
        }

 

        public void TimTheoEmail()
        {
            Console.WriteLine();
            Console.WriteLine("========== TIM THEO EMAIL ==========");

            Console.Write("Nhap email: ");
            string email = Console.ReadLine() ?? "";

            HocVien? hocVien = danhSachHocVien
                .FirstOrDefault(
                    x => x.email.Equals(
                        email,
                        StringComparison.OrdinalIgnoreCase
                    )
                );

            if (hocVien == null)
            {
                Console.WriteLine("Khong tim thay hoc vien!");
                return;
            }

            Console.WriteLine(
                $"{hocVien.maHV} - " +
                $"{hocVien.hoTen} - " +
                $"{hocVien.phone} - " +
                $"{hocVien.email}"
            );
        }

        public void ImportCSV()
        {
            Console.WriteLine();
            Console.WriteLine("========== IMPORT CSV ==========");

            Console.Write("Nhap duong dan file CSV: ");
            string path = Console.ReadLine() ?? "";

            List<HocVien> danhSachImport =
                repository.ImportCSV(path);

            if (danhSachImport.Count == 0)
            {
                Console.WriteLine("Khong co du lieu de import!");
                return;
            }

            int soLuongThem = 0;

            foreach (HocVien hv in danhSachImport)
            {
    
                bool trungMa = danhSachHocVien.Any(
                    x => x.maHV == hv.maHV
                );

             
                bool trungPhone = danhSachHocVien.Any(
                    x => x.phone == hv.phone
                );

                if (trungMa || trungPhone)
                {
                    continue;
                }

                danhSachHocVien.Add(hv);

                soLuongThem++;
            }

            repository.SaveData(danhSachHocVien);

            Console.WriteLine(
                $"Import thanh cong {soLuongThem} hoc vien!"
            );
        }

        public void ExportCSV()
        {
            Console.WriteLine();
            Console.WriteLine("========== EXPORT CSV ==========");

            Console.Write(
                "Nhap duong dan file CSV muon luu: "
            );

            string path = Console.ReadLine() ?? "";

            repository.ExportCSV(
                path,
                danhSachHocVien
            );

            Console.WriteLine("Export CSV thanh cong!");
        }

   

        public List<HocVien> GetDanhSachHocVien()
        {
            return danhSachHocVien;
        }
    }
}