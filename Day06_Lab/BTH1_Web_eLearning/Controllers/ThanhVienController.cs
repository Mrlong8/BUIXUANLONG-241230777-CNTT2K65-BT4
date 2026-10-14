using BTH1_Web_eLearning.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTH1_Web_eLearning.Controllers
{
    public class ThanhVienController : Controller
    {
        private static List<ThanhVien> dsThanhVien = new List<ThanhVien>();

        public ThanhVienController()
        {
            if (!dsThanhVien.Any())
            {
                dsThanhVien = new List<ThanhVien>()
                {
                    new ThanhVien()
                    {
                        maTV = "TV01",
                        tenDN = "namha",
                        name = "Hải Nam",
                        password = "123",
                        email = "nam@gmail.com"
                    },
                    new ThanhVien()
                    {
                        maTV = "TV02",
                        tenDN = "minhtu",
                        name = "Minh Tú",
                        password = "456",
                        email = "tu@gmail.com"
                    },
                    new ThanhVien()
                    {
                        maTV = "TV03",
                        tenDN = "phonghoang",
                        name = "Hoàng Phong",
                        password = "789",
                        email = "phong@gmail.com"
                    }
                };
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(dsThanhVien);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ThanhVien tv)
        {
            Random rand = new Random();
            string randomCode;

            do
            {
                randomCode = "TV" + rand.Next(100, 99999);
            } while (dsThanhVien.Any(x => x.maTV == randomCode));

            tv.maTV = randomCode;

            dsThanhVien.Add(tv);

            return RedirectToAction("Index", "ThanhVien");
        }
    }
}