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
    public class GroupsController : Controller
    {
        private readonly FireteamDbContext _context;

        public GroupsController(FireteamDbContext context)
        {
            _context = context;    
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            var fireteamDbContext = _context.Groups.Include(g => g.GroupType);
            return View(await fireteamDbContext.ToListAsync());
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .Include(g => g.GroupType)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            ViewData["GroupTypeID"] = new SelectList(_context.GroupTypes, "ID", "ID");
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,GroupTypeID,IsHidden,IsInviteOnly,Created,LastModified,IsDeleted")] Group @group)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@group);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["GroupTypeID"] = new SelectList(_context.GroupTypes, "ID", "ID", @group.GroupTypeID);
            return View(@group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups.SingleOrDefaultAsync(m => m.ID == id);
            if (@group == null)
            {
                return NotFound();
            }
            ViewData["GroupTypeID"] = new SelectList(_context.GroupTypes, "ID", "ID", @group.GroupTypeID);
            return View(@group);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,GroupTypeID,IsHidden,IsInviteOnly,Created,LastModified,IsDeleted")] Group @group)
        {
            if (id != @group.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(@group.ID))
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
            ViewData["GroupTypeID"] = new SelectList(_context.GroupTypes, "ID", "ID", @group.GroupTypeID);
            return View(@group);
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @group = await _context.Groups
                .Include(g => g.GroupType)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (@group == null)
            {
                return NotFound();
            }

            return View(@group);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @group = await _context.Groups.SingleOrDefaultAsync(m => m.ID == id);
            _context.Groups.Remove(@group);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.ID == id);
        }
    }
}
