using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TH1.Models.DataModels;
using TH1.Models.BusinessModels;

public class AccountController : Controller
{
    private readonly BookStoreDbv2Context _context;

    public AccountController(BookStoreDbv2Context context)
    {
        _context = context;
    }

    // GET: Account
    public async Task<IActionResult> Index()
    {
        return View(await _context.Accounts.ToListAsync());
    }

    // GET: Account/Details/5
    public async Task<IActionResult> Details(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var account = await _context.Accounts
            .FirstOrDefaultAsync(m => m.AccountId == id);
        if (account == null)
        {
            return NotFound();
        }

        return View(account);
    }

    // GET: Account/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Account/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("AccountId,Username,Password,FullName,Picture,Email,Address,Phone,IsAdmin,Active")] Account account)
    {
        account.AccountId = Guid.NewGuid().ToString();
        ModelState.Remove("AccountId");
        ModelState.Remove("OrderBooks");
        if (ModelState.IsValid)
        {

            _context.Add(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(account);
    }

    // GET: Account/Edit/5
    public async Task<IActionResult> Edit(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var account = await _context.Accounts.FindAsync(id);
        if (account == null)
        {
            return NotFound();
        }
        return View(account);
    }

    // POST: Account/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string? id, [Bind("AccountId,Username,Password,FullName,Picture,Email,Address,Phone,IsAdmin,Active")] Account account)
    {
        if (id != account.AccountId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(account);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(account.AccountId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(account);
    }

    // GET: Account/Delete/5
    public async Task<IActionResult> Delete(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var account = await _context.Accounts
            .FirstOrDefaultAsync(m => m.AccountId == id);
        if (account == null)
        {
            return NotFound();
        }

        return View(account);
    }

    // POST: Account/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string? id)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account != null)
        {
            _context.Accounts.Remove(account);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool AccountExists(string? id)
    {
        return _context.Accounts.Any(e => e.AccountId == id);
    }
}