using BXLBT4.src.DevmasterTrainingManagement.Domain;
using System.Text.Json;

namespace BXLBT4.src.DevmasterTrainingManagement.Infrastructure
{
    internal class DangKyKhoaHocRepository
    {
        private readonly string filePath;

        public DangKyKhoaHocRepository()
        {
            filePath = Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                "DataDangKyKhoaHoc.json"
            );
        }

        public List<DangKyKhoaHoc> LoadData()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Khong tim thay file DataDangKyKhoaHoc.json");

                return new List<DangKyKhoaHoc>();
            }

            string json = File.ReadAllText(filePath);

            List<DangKyKhoaHoc>? danhSachDangKy =
                JsonSerializer.Deserialize<List<DangKyKhoaHoc>>(json);

            return danhSachDangKy ?? new List<DangKyKhoaHoc>();
        }

        public void SaveData(List<DangKyKhoaHoc> danhSachDangKy)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(
                danhSachDangKy,
                options
            );

            File.WriteAllText(filePath, json);
        }
    }
}