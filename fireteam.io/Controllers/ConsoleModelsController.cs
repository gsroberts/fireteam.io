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
    public class ConsoleModelsController : Controller
    {
        private readonly FireteamDbContext _context;

        public ConsoleModelsController(FireteamDbContext context)
        {
            _context = context;    
        }

        // GET: ConsoleModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ConsoleModels.ToListAsync());
        }

        // GET: ConsoleModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consoleModel = await _context.ConsoleModels
                .SingleOrDefaultAsync(m => m.ID == id);
            if (consoleModel == null)
            {
                return NotFound();
            }

            return View(consoleModel);
        }

        // GET: ConsoleModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConsoleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Manufacturer,Created,LastModified,IsDeleted")] ConsoleModel consoleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consoleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(consoleModel);
        }

        // GET: ConsoleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consoleModel = await _context.ConsoleModels.SingleOrDefaultAsync(m => m.ID == id);
            if (consoleModel == null)
            {
                return NotFound();
            }
            return View(consoleModel);
        }

        // POST: ConsoleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Manufacturer,Created,LastModified,IsDeleted")] ConsoleModel consoleModel)
        {
            if (id != consoleModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consoleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsoleModelExists(consoleModel.ID))
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
            return View(consoleModel);
        }

        // GET: ConsoleModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consoleModel = await _context.ConsoleModels
                .SingleOrDefaultAsync(m => m.ID == id);
            if (consoleModel == null)
            {
                return NotFound();
            }

            return View(consoleModel);
        }

        // POST: ConsoleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consoleModel = await _context.ConsoleModels.SingleOrDefaultAsync(m => m.ID == id);
            _context.ConsoleModels.Remove(consoleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ConsoleModelExists(int id)
        {
            return _context.ConsoleModels.Any(e => e.ID == id);
        }
    }
}
