using Bxl28_9Bt7andLap5.Models.DataModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Bxl28_9Bt7andLap5.Controllers
{
    public class AccountController : Controller
    {
        private static List<Account> _accounts = new List<Account>();
        public IActionResult Index()
        {
       
            return View(_accounts);
        }
        public IActionResult Create()
        {
            Account model = new Account();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Account account)
        {
            if (ModelState.IsValid)
            {
                _accounts.Add(account);
                return RedirectToAction("Index");
            }
            return View(account);
        }

        [AcceptVerbs("GET","POST")]
        public IActionResult VerifyPhone(string phone)
        {
            Regex _isPhone = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
            if (!_isPhone.IsMatch(phone))
            {
                return Json($"Số điện thoại {phone} không đúng định dạng");
            }
            return Json(true);
        }
    }
}
