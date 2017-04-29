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
    public class GroupPlatformsController : Controller
    {
        private readonly FireteamDbContext _context;

        public GroupPlatformsController(FireteamDbContext context)
        {
            _context = context;    
        }

        // GET: GroupPlatforms
        public async Task<IActionResult> Index()
        {
            var fireteamDbContext = _context.GroupPlatform.Include(g => g.Group).Include(g => g.Platform);
            return View(await fireteamDbContext.ToListAsync());
        }

        // GET: GroupPlatforms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupPlatform = await _context.GroupPlatform
                .Include(g => g.Group)
                .Include(g => g.Platform)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (groupPlatform == null)
            {
                return NotFound();
            }

            return View(groupPlatform);
        }

        // GET: GroupPlatforms/Create
        public IActionResult Create()
        {
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID");
            ViewData["PlatformID"] = new SelectList(_context.Platforms, "ID", "ID");
            return View();
        }

        // POST: GroupPlatforms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,GroupID,PlatformID,Created,LastModified,IsDeleted")] GroupPlatform groupPlatform)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupPlatform);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID", groupPlatform.GroupID);
            ViewData["PlatformID"] = new SelectList(_context.Platforms, "ID", "ID", groupPlatform.PlatformID);
            return View(groupPlatform);
        }

        // GET: GroupPlatforms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupPlatform = await _context.GroupPlatform.SingleOrDefaultAsync(m => m.ID == id);
            if (groupPlatform == null)
            {
                return NotFound();
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID", groupPlatform.GroupID);
            ViewData["PlatformID"] = new SelectList(_context.Platforms, "ID", "ID", groupPlatform.PlatformID);
            return View(groupPlatform);
        }

        // POST: GroupPlatforms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,GroupID,PlatformID,Created,LastModified,IsDeleted")] GroupPlatform groupPlatform)
        {
            if (id != groupPlatform.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupPlatform);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupPlatformExists(groupPlatform.ID))
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
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID", groupPlatform.GroupID);
            ViewData["PlatformID"] = new SelectList(_context.Platforms, "ID", "ID", groupPlatform.PlatformID);
            return View(groupPlatform);
        }

        // GET: GroupPlatforms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupPlatform = await _context.GroupPlatform
                .Include(g => g.Group)
                .Include(g => g.Platform)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (groupPlatform == null)
            {
                return NotFound();
            }

            return View(groupPlatform);
        }

        // POST: GroupPlatforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupPlatform = await _context.GroupPlatform.SingleOrDefaultAsync(m => m.ID == id);
            _context.GroupPlatform.Remove(groupPlatform);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GroupPlatformExists(int id)
        {
            return _context.GroupPlatform.Any(e => e.ID == id);
        }
    }
}
