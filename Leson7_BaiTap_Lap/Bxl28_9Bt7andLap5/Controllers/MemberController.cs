using Bxl28_9Bt7andLap5.Models.DataModel;
using Bxl28_9Bt7andLap5.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Bxl28_9Bt7andLap5.Controllers
{
    public class MemberController : Controller
    {
        public static List<Member> list = new List<Member>();
        public IActionResult Index()
        {
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RegisterViewModel member)
        {
            if (ModelState.IsValid)
            {
                Member m = new Member
                {
                    MenberId = Guid.NewGuid().ToString(),
                    UserName = member.UserName,
                    FullName = member.FullName,
                    Email = member.Email,
                    Phone = member.Phone,
                    BirthDay = member.Birthday,
                };
                list.Add(m);
                return RedirectToAction("Index");
            }

            return View("Create");
        }
    }
}
