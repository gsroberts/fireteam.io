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
    public class GameTypesController : Controller
    {
        private readonly FireteamDbContext _context;

        public GameTypesController(FireteamDbContext context)
        {
            _context = context;    
        }

        // GET: GameTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GameTypes.ToListAsync());
        }

        // GET: GameTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameType = await _context.GameTypes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (gameType == null)
            {
                return NotFound();
            }

            return View(gameType);
        }

        // GET: GameTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Created,LastModified,IsDeleted")] GameType gameType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gameType);
        }

        // GET: GameTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameType = await _context.GameTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (gameType == null)
            {
                return NotFound();
            }
            return View(gameType);
        }

        // POST: GameTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Created,LastModified,IsDeleted")] GameType gameType)
        {
            if (id != gameType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameTypeExists(gameType.ID))
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
            return View(gameType);
        }

        // GET: GameTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameType = await _context.GameTypes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (gameType == null)
            {
                return NotFound();
            }

            return View(gameType);
        }

        // POST: GameTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameType = await _context.GameTypes.SingleOrDefaultAsync(m => m.ID == id);
            _context.GameTypes.Remove(gameType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GameTypeExists(int id)
        {
            return _context.GameTypes.Any(e => e.ID == id);
        }
    }
}
