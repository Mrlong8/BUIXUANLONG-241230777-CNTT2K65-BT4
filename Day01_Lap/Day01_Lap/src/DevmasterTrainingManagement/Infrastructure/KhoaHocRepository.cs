using BXLBT4.src.DevmasterTrainingManagement.Domain;
using System.Text.Json;

namespace BXLBT4.src.DevmasterTrainingManagement.Infrastructure
{
    internal class KhoaHocRepository
    {
        private readonly string filePath;

        public KhoaHocRepository()
        {
            filePath = Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                "DataKhoaHoc.json"
            );
        }

        public List<KhoaHoc> LoadData()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Khong tim thay file DataKhoaHoc.json");
                return new List<KhoaHoc>();
            }

            string json = File.ReadAllText(filePath);

            List<KhoaHoc>? danhSachKhoaHoc =
                JsonSerializer.Deserialize<List<KhoaHoc>>(json);

            return danhSachKhoaHoc ?? new List<KhoaHoc>();
        }

        public void SaveData(List<KhoaHoc> danhSachKhoaHoc)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(
                danhSachKhoaHoc,
                options
            );

            File.WriteAllText(filePath, json);
        }
    }
}