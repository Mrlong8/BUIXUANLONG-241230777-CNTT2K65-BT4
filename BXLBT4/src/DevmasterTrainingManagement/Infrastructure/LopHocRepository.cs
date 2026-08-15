using BXLBT4.src.DevmasterTrainingManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BXLBT4.src.DevmasterTrainingManagement.Infrastructure
{
    internal class LopHocRepository
    {
        private readonly string filePath;

        public LopHocRepository()
        {
            filePath = Path.Combine(
                AppContext.BaseDirectory,
                "Data",
                "DataLopHoc.json"
            );
        }

        public List<LopHoc> LoadData()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Khong tim thay file json");
                return new List<LopHoc>();
            }

            string json = File.ReadAllText(filePath);
            List<LopHoc> danhSachLopHoc = JsonSerializer.Deserialize<List<LopHoc>>(json);

            return danhSachLopHoc ?? new List<LopHoc>();
            // ?? là câu lẹnh null-coalescing operator.
            // nếu ko null trả về danhSachLopHoc còn null trả về  new List<LopHoc>();
        }

    }
}
