using Microsoft.AspNetCore.Mvc;

namespace BXLBaiThucHanhLap1.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
