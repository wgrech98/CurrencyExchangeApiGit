//using CurrencyExchangeApi.Data;
//using CurrencyExchangeApi.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace CurrencyExchangeApi.Controllers
//{
//    public class UsersController : Controller
//    {
//        private readonly AppDbContext _context;

//        public UsersController(AppDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Users
//        public async Task<IActionResult> Index()
//        {
//            return _context.Users != null ?
//                        View(await _context.Users.ToListAsync()) :
//                        Problem("Entity set 'AppDbContext.Users'  is null.");
//        }

//        // GET: Users/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Users/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("UserId,UserName,FirstName,LastName,Email")] ApplicationUserModel userModel)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(userModel);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(userModel);
//        }

//        // GET: Users/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null || _context.Users == null)
//            {
//                return NotFound();
//            }

//            var userModel = await _context.Users.FindAsync(id);
//            if (userModel == null)
//            {
//                return NotFound();
//            }
//            return View(userModel);
//        }

//        // POST: Users/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int? id, [Bind("UserId,UserName,FirstName,LastName,Email")] ApplicationUserModel userModel)
//        {
//            if (id != userModel.UserId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(userModel);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!UserModelExists(userModel.UserId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(userModel);
//        }

//        // GET: Users/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null || _context.Users == null)
//            {
//                return NotFound();
//            }

//            var userModel = await _context.Users
//                .FirstOrDefaultAsync(m => m.UserId == id);
//            if (userModel == null)
//            {
//                return NotFound();
//            }

//            return View(userModel);
//        }

//        // POST: Users/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int? id)
//        {
//            if (_context.Users == null)
//            {
//                return Problem("Entity set 'AppDbContext.Users'  is null.");
//            }
//            var userModel = await _context.Users.FindAsync(id);
//            if (userModel != null)
//            {
//                _context.Users.Remove(userModel);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool UserModelExists(int? id)
//        {
//            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
//        }
//    }
//}
