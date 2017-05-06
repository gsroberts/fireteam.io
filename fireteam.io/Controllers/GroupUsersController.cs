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
    public class GroupUsersController : Controller
    {
        private readonly FireteamDbContext _context;

        public GroupUsersController(FireteamDbContext context)
        {
            _context = context;    
        }

        // GET: GroupUsers
        public async Task<IActionResult> Index(string userId)
        {
            var fireteamDbContext = (string.IsNullOrWhiteSpace(userId)) ? _context.GroupUsers
                                                                    .Where(g => g.UserID == userId)
                                                                    .Include(g => g.Group)
                                                                    .Include(g => g.User) : _context.GroupUsers
                                                                                                        .Include(g => g.Group)
                                                                                                        .Include(g => g.User);
            return View(await fireteamDbContext.ToListAsync());
        }

        // GET: GroupUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupUser = await _context.GroupUsers
                .Include(g => g.Group)
                .Include(g => g.User)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (groupUser == null)
            {
                return NotFound();
            }

            return View(groupUser);
        }

        // GET: GroupUsers/Create
        public IActionResult Create()
        {
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID");
            return View();
        }

        // POST: GroupUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,GroupID,UserID,IsGroupLeadership,Created,LastModified,IsDeleted")] GroupUser groupUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupUser);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID", groupUser.GroupID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", groupUser.UserID);
            return View(groupUser);
        }

        // GET: GroupUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupUser = await _context.GroupUsers.SingleOrDefaultAsync(m => m.ID == id);
            if (groupUser == null)
            {
                return NotFound();
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID", groupUser.GroupID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", groupUser.UserID);
            return View(groupUser);
        }

        // POST: GroupUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,GroupID,UserID,IsGroupLeadership,Created,LastModified,IsDeleted")] GroupUser groupUser)
        {
            if (id != groupUser.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupUserExists(groupUser.ID))
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
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID", groupUser.GroupID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", groupUser.UserID);
            return View(groupUser);
        }

        // GET: GroupUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupUser = await _context.GroupUsers
                .Include(g => g.Group)
                .Include(g => g.User)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (groupUser == null)
            {
                return NotFound();
            }

            return View(groupUser);
        }

        // POST: GroupUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupUser = await _context.GroupUsers.SingleOrDefaultAsync(m => m.ID == id);
            _context.GroupUsers.Remove(groupUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GroupUserExists(int id)
        {
            return _context.GroupUsers.Any(e => e.ID == id);
        }
    }
}
