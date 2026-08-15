using BXLBT4.src.DevmasterTrainingManagement.Application;
using BXLBT4.src.DevmasterTrainingManagement.ConsoleUI.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace BXLBT4.src.DevmasterTrainingManagement.ConsoleUI.Menus
{
    internal class MainMenu
    {
        public void ShowMenuMain()
        {
            Console.WriteLine();
            Console.WriteLine("============== HE THONG QUANLY DAO TAO  DEVMASTER =============");
            Console.WriteLine("=    1. Quan Ly Lop Hoc                                       =");
            Console.WriteLine("=    2. QUan Ly Khoa Hoc                                      =");
            Console.WriteLine("=    3. QUan Ly HOc Vien                                      =");
            Console.WriteLine("=    4. Dang Ky Khoa Hoc                                      =");
            Console.WriteLine("=    5. Cham Soc Hoc Vien                                     =");
            Console.WriteLine("=    0. Thoát                                                 =");
            Console.WriteLine("============== ================== =============================");

        }

        public void ShowMeNuQLLH()
        {
            Console.WriteLine();
            Console.WriteLine("============== QUAN LY LOP HOC ================");
            Console.WriteLine("|    1. Tao lop                               |");
            Console.WriteLine("|    2. Cap nhat lop                          |");
            Console.WriteLine("|    3. Kiem tra si so                        |");
            Console.WriteLine("|    4. Hien thi lop sap khai giang           |");
            Console.WriteLine("|    5. Hien thi lop dang hoc                 |");
            Console.WriteLine("|    6. Huy lop                               |");
            Console.WriteLine("|    0. Thoat                    p.quay lai   |");
            Console.WriteLine("===============================================");
        }
        public void ShowMenuQLKH()
        {
            Console.WriteLine();
            Console.WriteLine("============== QUAN LY KHOA HOC ================");
            Console.WriteLine("|    1. Them khoa hoc                          |");
            Console.WriteLine("|    2. Sua khoa hoc                           |");
            Console.WriteLine("|    3. Xoa khoa hoc                           |");
            Console.WriteLine("|    4. Tim kiem khoa hoc                      |");
            Console.WriteLine("|    5. Sap xep khoa hoc                       |");
            Console.WriteLine("|    6. Loc theo trang thai                    |");
            Console.WriteLine("|    7. Thong ke hoc phi                       |");
            Console.WriteLine("|    0. Thoat                    p.quay lai    |");
            Console.WriteLine("================================================");
        }
        public void ShowMenuQLHV()
        {
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine("|               QUAN LY HOC VIEN                 |");
            Console.WriteLine("==================================================");
            Console.WriteLine("|  1. Them hoc vien                              |");
            Console.WriteLine("|  2. Sua hoc vien                               |");
            Console.WriteLine("|  3. Xoa hoc vien                               |");
            Console.WriteLine("|  4. Kiem tra trung so dien thoai               |");
            Console.WriteLine("|  5. Tim theo ten                               |");
            Console.WriteLine("|  6. Tim theo so dien thoai                     |");
            Console.WriteLine("|  7. Tim theo email                             |");
            Console.WriteLine("|  8. Import hoc vien tu CSV                     |");
            Console.WriteLine("|  9. Export hoc vien sang CSV                   |");
            Console.WriteLine("|  0. Quay Lai                                   |");
            Console.WriteLine("==================================================");
        }
        public void ShowMenuDangKyHoc()
        {
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine("|              DANG KY HOC                       |");
            Console.WriteLine("==================================================");
            Console.WriteLine("|  1. Dang ky hoc                                |");
            Console.WriteLine("|  2. Kiem tra lop con cho                       |");
            Console.WriteLine("|  3. Kiem tra dang ky trung lop                 |");
            Console.WriteLine("|  4. Tinh so tien con thieu                     |");
            Console.WriteLine("|  5. Ghi nhan thanh toan                        |");
            Console.WriteLine("|  6. Huy dang ky                                |");
            Console.WriteLine("|  7. Thong ke cong no                           |");
            Console.WriteLine("|  0. Thoat                      p. Quay lai     |");
            Console.WriteLine("==================================================");
        }
        public void ShowMenuChamSocHocVien()
        {
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine("|             CHAM SOC HOC VIEN                  |");
            Console.WriteLine("==================================================");
            Console.WriteLine("|  1. Ghi lich su cham soc                       |");
            Console.WriteLine("|  2. Hien thi lich su theo hoc vien            |");
            Console.WriteLine("|  3. Hien thi lich hen hom nay                  |");
            Console.WriteLine("|  4. Hien thi lich hen qua han                  |");
            Console.WriteLine("|  5. Thong ke ket qua cham soc                  |");
            Console.WriteLine("|  0. Thoat                      p. Quay lai      |");
            Console.WriteLine("==================================================");
        }

    

    }
}
