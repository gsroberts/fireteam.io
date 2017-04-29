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
    public class GroupTypesController : Controller
    {
        private readonly FireteamDbContext _context;

        public GroupTypesController(FireteamDbContext context)
        {
            _context = context;    
        }

        // GET: GroupTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroupTypes.ToListAsync());
        }

        // GET: GroupTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupType = await _context.GroupTypes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (groupType == null)
            {
                return NotFound();
            }

            return View(groupType);
        }

        // GET: GroupTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroupTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Created,LastModified,IsDeleted")] GroupType groupType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(groupType);
        }

        // GET: GroupTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupType = await _context.GroupTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (groupType == null)
            {
                return NotFound();
            }
            return View(groupType);
        }

        // POST: GroupTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Created,LastModified,IsDeleted")] GroupType groupType)
        {
            if (id != groupType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupTypeExists(groupType.ID))
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
            return View(groupType);
        }

        // GET: GroupTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupType = await _context.GroupTypes
                .SingleOrDefaultAsync(m => m.ID == id);
            if (groupType == null)
            {
                return NotFound();
            }

            return View(groupType);
        }

        // POST: GroupTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupType = await _context.GroupTypes.SingleOrDefaultAsync(m => m.ID == id);
            _context.GroupTypes.Remove(groupType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GroupTypeExists(int id)
        {
            return _context.GroupTypes.Any(e => e.ID == id);
        }
    }
}
