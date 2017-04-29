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
    public class GamePlatformsController : Controller
    {
        private readonly FireteamDbContext _context;

        public GamePlatformsController(FireteamDbContext context)
        {
            _context = context;    
        }

        // GET: GamePlatforms
        public async Task<IActionResult> Index()
        {
            var fireteamDbContext = _context.GamePlatforms.Include(g => g.Game).Include(g => g.Platform);
            return View(await fireteamDbContext.ToListAsync());
        }

        // GET: GamePlatforms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamePlatform = await _context.GamePlatforms
                .Include(g => g.Game)
                .Include(g => g.Platform)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (gamePlatform == null)
            {
                return NotFound();
            }

            return View(gamePlatform);
        }

        // GET: GamePlatforms/Create
        public IActionResult Create()
        {
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID");
            ViewData["PlatformID"] = new SelectList(_context.Platforms, "ID", "ID");
            return View();
        }

        // POST: GamePlatforms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,GameID,PlatformID,Created,LastModified,IsDeleted")] GamePlatform gamePlatform)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gamePlatform);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID", gamePlatform.GameID);
            ViewData["PlatformID"] = new SelectList(_context.Platforms, "ID", "ID", gamePlatform.PlatformID);
            return View(gamePlatform);
        }

        // GET: GamePlatforms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamePlatform = await _context.GamePlatforms.SingleOrDefaultAsync(m => m.ID == id);
            if (gamePlatform == null)
            {
                return NotFound();
            }
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID", gamePlatform.GameID);
            ViewData["PlatformID"] = new SelectList(_context.Platforms, "ID", "ID", gamePlatform.PlatformID);
            return View(gamePlatform);
        }

        // POST: GamePlatforms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,GameID,PlatformID,Created,LastModified,IsDeleted")] GamePlatform gamePlatform)
        {
            if (id != gamePlatform.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gamePlatform);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GamePlatformExists(gamePlatform.ID))
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
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID", gamePlatform.GameID);
            ViewData["PlatformID"] = new SelectList(_context.Platforms, "ID", "ID", gamePlatform.PlatformID);
            return View(gamePlatform);
        }

        // GET: GamePlatforms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gamePlatform = await _context.GamePlatforms
                .Include(g => g.Game)
                .Include(g => g.Platform)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (gamePlatform == null)
            {
                return NotFound();
            }

            return View(gamePlatform);
        }

        // POST: GamePlatforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gamePlatform = await _context.GamePlatforms.SingleOrDefaultAsync(m => m.ID == id);
            _context.GamePlatforms.Remove(gamePlatform);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GamePlatformExists(int id)
        {
            return _context.GamePlatforms.Any(e => e.ID == id);
        }
    }
}
