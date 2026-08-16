using BXLBT4.src.DevmasterTrainingManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BXLBT4.src.DevmasterTrainingManagement.Infrastructure
{
    internal class ChamSocHocVienRepository
    {

        private readonly string filePath;
        public ChamSocHocVienRepository()
        {
            filePath = Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                "DataChamSocHOcVien.json"
                );
        }
        public List<ChamSocHocVien> LoadData()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Khong tim thay file DataDangKyKhoaHoc.json");
                return new List<ChamSocHocVien>();
            }

            string json = File.ReadAllText(filePath);
            List<ChamSocHocVien>? danhSachChamSoc = JsonSerializer.Deserialize<List<ChamSocHocVien>>(json);
            return danhSachChamSoc ?? new List<ChamSocHocVien>();
        }

        public void SaveData(List<ChamSocHocVien> danhSachChamSoc)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(danhSachChamSoc,options);
            File.WriteAllText(filePath, json);
        }



    }
}
