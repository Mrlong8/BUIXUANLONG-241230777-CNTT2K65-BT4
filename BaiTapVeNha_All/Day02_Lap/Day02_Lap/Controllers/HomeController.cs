using BXLBaiThucHanhLap1.Data;
using BXLBaiThucHanhLap1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BXLBaiThucHanhLap1.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View(ProductData.Products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
