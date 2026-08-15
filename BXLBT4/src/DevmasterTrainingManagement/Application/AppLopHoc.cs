using BXLBT4.src.DevmasterTrainingManagement.Domain;
using BXLBT4.src.DevmasterTrainingManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BXLBT4.src.DevmasterTrainingManagement.Application
{
    internal class AppLopHoc
    {
        private List<LopHoc> danhSachLopHoc;
        private LopHocRepository repository;

        public AppLopHoc(LopHocRepository repository)
        {
            this.repository = repository;
            danhSachLopHoc = repository.LoadData();
        }

        public List<LopHoc> GetDanhSachLopHoc()
        {
            return danhSachLopHoc;
        }
    }
}
