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
    public class UserGamesController : Controller
    {
        private readonly FireteamDbContext _context;

        public UserGamesController(FireteamDbContext context)
        {
            _context = context;    
        }

        // GET: UserGames
        public async Task<IActionResult> Index()
        {
            var fireteamDbContext = _context.UserGames.Include(u => u.Game).Include(u => u.User);
            return View(await fireteamDbContext.ToListAsync());
        }

        // GET: UserGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGame = await _context.UserGames
                .Include(u => u.Game)
                .Include(u => u.User)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (userGame == null)
            {
                return NotFound();
            }

            return View(userGame);
        }

        // GET: UserGames/Create
        public IActionResult Create()
        {
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID");
            return View();
        }

        // POST: UserGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,GameID,Created,LastModified,IsDeleted")] UserGame userGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userGame);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID", userGame.GameID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", userGame.UserID);
            return View(userGame);
        }

        // GET: UserGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGame = await _context.UserGames.SingleOrDefaultAsync(m => m.ID == id);
            if (userGame == null)
            {
                return NotFound();
            }
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID", userGame.GameID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", userGame.UserID);
            return View(userGame);
        }

        // POST: UserGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,GameID,Created,LastModified,IsDeleted")] UserGame userGame)
        {
            if (id != userGame.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserGameExists(userGame.ID))
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
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID", userGame.GameID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", userGame.UserID);
            return View(userGame);
        }

        // GET: UserGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userGame = await _context.UserGames
                .Include(u => u.Game)
                .Include(u => u.User)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (userGame == null)
            {
                return NotFound();
            }

            return View(userGame);
        }

        // POST: UserGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userGame = await _context.UserGames.SingleOrDefaultAsync(m => m.ID == id);
            _context.UserGames.Remove(userGame);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserGameExists(int id)
        {
            return _context.UserGames.Any(e => e.ID == id);
        }
    }
}
