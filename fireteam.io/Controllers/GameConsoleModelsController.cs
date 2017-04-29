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
    public class GameConsoleModelsController : Controller
    {
        private readonly FireteamDbContext _context;

        public GameConsoleModelsController(FireteamDbContext context)
        {
            _context = context;    
        }

        // GET: GameConsoleModels
        public async Task<IActionResult> Index()
        {
            var fireteamDbContext = _context.GameConsoleModels.Include(g => g.ConsoleModel).Include(g => g.Game);
            return View(await fireteamDbContext.ToListAsync());
        }

        // GET: GameConsoleModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameConsoleModel = await _context.GameConsoleModels
                .Include(g => g.ConsoleModel)
                .Include(g => g.Game)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (gameConsoleModel == null)
            {
                return NotFound();
            }

            return View(gameConsoleModel);
        }

        // GET: GameConsoleModels/Create
        public IActionResult Create()
        {
            ViewData["ConsoleModelID"] = new SelectList(_context.ConsoleModels, "ID", "ID");
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID");
            return View();
        }

        // POST: GameConsoleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,GameID,ConsoleModelID,Created,LastModified,IsDeleted")] GameConsoleModel gameConsoleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gameConsoleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ConsoleModelID"] = new SelectList(_context.ConsoleModels, "ID", "ID", gameConsoleModel.ConsoleModelID);
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID", gameConsoleModel.GameID);
            return View(gameConsoleModel);
        }

        // GET: GameConsoleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameConsoleModel = await _context.GameConsoleModels.SingleOrDefaultAsync(m => m.ID == id);
            if (gameConsoleModel == null)
            {
                return NotFound();
            }
            ViewData["ConsoleModelID"] = new SelectList(_context.ConsoleModels, "ID", "ID", gameConsoleModel.ConsoleModelID);
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID", gameConsoleModel.GameID);
            return View(gameConsoleModel);
        }

        // POST: GameConsoleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,GameID,ConsoleModelID,Created,LastModified,IsDeleted")] GameConsoleModel gameConsoleModel)
        {
            if (id != gameConsoleModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gameConsoleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameConsoleModelExists(gameConsoleModel.ID))
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
            ViewData["ConsoleModelID"] = new SelectList(_context.ConsoleModels, "ID", "ID", gameConsoleModel.ConsoleModelID);
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID", gameConsoleModel.GameID);
            return View(gameConsoleModel);
        }

        // GET: GameConsoleModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gameConsoleModel = await _context.GameConsoleModels
                .Include(g => g.ConsoleModel)
                .Include(g => g.Game)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (gameConsoleModel == null)
            {
                return NotFound();
            }

            return View(gameConsoleModel);
        }

        // POST: GameConsoleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameConsoleModel = await _context.GameConsoleModels.SingleOrDefaultAsync(m => m.ID == id);
            _context.GameConsoleModels.Remove(gameConsoleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GameConsoleModelExists(int id)
        {
            return _context.GameConsoleModels.Any(e => e.ID == id);
        }
    }
}
