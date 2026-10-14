using BTHLap03_ProfileAccount.Models;
using BTHLap03_ProfileAccount.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace BTHLap03_ProfileAccount.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = DataAccounts.accounts;
            return View(accounts);
        }
        
        public IActionResult Profile(int id)
        {
            var account = DataAccounts.accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }
    }
}
