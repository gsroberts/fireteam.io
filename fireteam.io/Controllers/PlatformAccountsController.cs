using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fireteam.Data;
using Fireteam.Models;

namespace Fireteam.Controllers
{
    public class PlatformAccountsController : Controller
    {
        private readonly FireteamDbContext _context;

        public PlatformAccountsController(FireteamDbContext context)
        {
            _context = context;    
        }

        // GET: PlatformAccounts
        public async Task<IActionResult> Index()
        {
            var fireteamDbContext = _context.PlatformAccounts.Include(p => p.ConsoleModel).Include(p => p.Platform).Include(p => p.User);
            return View(await fireteamDbContext.ToListAsync());
        }

        // GET: PlatformAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platformAccount = await _context.PlatformAccounts
                .Include(p => p.ConsoleModel)
                .Include(p => p.Platform)
                .Include(p => p.User)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (platformAccount == null)
            {
                return NotFound();
            }

            return View(platformAccount);
        }

        // GET: PlatformAccounts/Create
        public IActionResult Create()
        {
            ViewData["ConsoleModelID"] = new SelectList(_context.ConsoleModels, "ID", "ID");
            ViewData["PlatformID"] = new SelectList(_context.Platforms, "ID", "ID");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID");
            return View();
        }

        // POST: PlatformAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,GamerTag,PlatformID,ConsoleModelID,UserID,Created,LastModified,IsDeleted")] PlatformAccount platformAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(platformAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ConsoleModelID"] = new SelectList(_context.ConsoleModels, "ID", "ID", platformAccount.ConsoleModelID);
            ViewData["PlatformID"] = new SelectList(_context.Platforms, "ID", "ID", platformAccount.PlatformID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", platformAccount.UserID);
            return View(platformAccount);
        }

        // GET: PlatformAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platformAccount = await _context.PlatformAccounts.SingleOrDefaultAsync(m => m.ID == id);
            if (platformAccount == null)
            {
                return NotFound();
            }
            ViewData["ConsoleModelID"] = new SelectList(_context.ConsoleModels, "ID", "ID", platformAccount.ConsoleModelID);
            ViewData["PlatformID"] = new SelectList(_context.Platforms, "ID", "ID", platformAccount.PlatformID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", platformAccount.UserID);
            return View(platformAccount);
        }

        // POST: PlatformAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,GamerTag,PlatformID,ConsoleModelID,UserID,Created,LastModified,IsDeleted")] PlatformAccount platformAccount)
        {
            if (id != platformAccount.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(platformAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatformAccountExists(platformAccount.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["ConsoleModelID"] = new SelectList(_context.ConsoleModels, "ID", "ID", platformAccount.ConsoleModelID);
            ViewData["PlatformID"] = new SelectList(_context.Platforms, "ID", "ID", platformAccount.PlatformID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", platformAccount.UserID);
            return View(platformAccount);
        }

        // GET: PlatformAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var platformAccount = await _context.PlatformAccounts
                .Include(p => p.ConsoleModel)
                .Include(p => p.Platform)
                .Include(p => p.User)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (platformAccount == null)
            {
                return NotFound();
            }

            return View(platformAccount);
        }

        // POST: PlatformAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var platformAccount = await _context.PlatformAccounts.SingleOrDefaultAsync(m => m.ID == id);
            _context.PlatformAccounts.Remove(platformAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PlatformAccountExists(int id)
        {
            return _context.PlatformAccounts.Any(e => e.ID == id);
        }
    }
}
