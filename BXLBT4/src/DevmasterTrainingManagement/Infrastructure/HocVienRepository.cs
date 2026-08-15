using BXLBT4.src.DevmasterTrainingManagement.Domain;
using System.Text;
using System.Text.Json;

namespace BXLBT4.src.DevmasterTrainingManagement.Infrastructure
{
    internal class HocVienRepository
    {
        private readonly string filePath;

        public HocVienRepository()
        {
            filePath = Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                "DataHocVien.json"
            );

            //Console.WriteLine("Duong dan file:");
            //Console.WriteLine(filePath);
        }

        public List<HocVien> LoadData()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("KHONG TIM THAY FILE JSON!");

                return new List<HocVien>();
            }

            //Console.WriteLine("Tim thay file JSON!");

            string json = File.ReadAllText(filePath);

            //Console.WriteLine("Noi dung JSON:");
            //Console.WriteLine(json);

            List<HocVien>? danhSachHocVien =
                JsonSerializer.Deserialize<List<HocVien>>(json);

            return danhSachHocVien ?? new List<HocVien>();
        }
        public void SaveData(List<HocVien> danhSachHocVien)
        {
            //chuyển object thành JSON.
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
//JSON được format đẹp, xuống dòng và thụt đầu dòng.
            };

            //List < HocVien > -> Serialize() -> string JSON
            string json = JsonSerializer.Serialize(
                danhSachHocVien,
                options
            );

            File.WriteAllText(filePath, json);
        }
        public List<HocVien> ImportCSV(string csvPath)
        {
            List<HocVien> danhSach = new List<HocVien>();

            if (!File.Exists(csvPath))
            {
                Console.WriteLine("Khong tim thay file CSV!");
                return danhSach;
            }

            string[] lines = File.ReadAllLines(csvPath, Encoding.UTF8);

            // Bỏ dòng tiêu đề
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                    continue;

                string[] data = lines[i].Split(',');

                if (data.Length < 7)
                    continue;

                DateTime ngaySinh;
                DateTime ngayDangKy;

                if (!DateTime.TryParse(data[2], out ngaySinh))
                    continue;

                if (!DateTime.TryParse(data[6], out ngayDangKy))
                    continue;

                HocVien hocVien = new HocVien(
                    data[0],
                    data[1],
                    ngaySinh,
                    data[3],
                    data[4],
                    data[5],
                    ngayDangKy
                );

                danhSach.Add(hocVien);
            }

            return danhSach;
        }

   
        public void ExportCSV(
            string csvPath,
            List<HocVien> danhSachHocVien)
        {
            StringBuilder csv = new StringBuilder();

            // Header
            csv.AppendLine(
                "MaHV,HoTen,NgaySinh,Phone,Email,DiaChi,NgayDangKy"
            );

            foreach (HocVien hv in danhSachHocVien)
            {
                csv.AppendLine(
                    $"{hv.maHV}," +
                    $"{hv.hoTen}," +
                    $"{hv.ngaySinh:dd/MM/yyyy}," +
                    $"{hv.phone}," +
                    $"{hv.email}," +
                    $"{hv.diaChi}," +
                    $"{hv.ngayDangKy:dd/MM/yyyy}"
                );
            }

            File.WriteAllText(
                csvPath,
                csv.ToString(),
                Encoding.UTF8
            );
        }
    }
}
