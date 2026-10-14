using Microsoft.AspNetCore.Mvc;

namespace BXLBaiThucHanhLap1.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
