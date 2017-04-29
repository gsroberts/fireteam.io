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
    public class BlockedUsersController : Controller
    {
        private readonly FireteamDbContext _context;

        public BlockedUsersController(FireteamDbContext context)
        {
            _context = context;    
        }

        // GET: BlockedUsers
        public async Task<IActionResult> Index()
        {
            var fireteamDbContext = _context.BlockedUsers.Include(b => b.Activity).Include(b => b.BlockingUser).Include(b => b.Group).Include(b => b.UserBeingBlocked);
            return View(await fireteamDbContext.ToListAsync());
        }

        // GET: BlockedUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blockedUser = await _context.BlockedUsers
                .Include(b => b.Activity)
                .Include(b => b.BlockingUser)
                .Include(b => b.Group)
                .Include(b => b.UserBeingBlocked)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (blockedUser == null)
            {
                return NotFound();
            }

            return View(blockedUser);
        }

        // GET: BlockedUsers/Create
        public IActionResult Create()
        {
            ViewData["ActivityID"] = new SelectList(_context.Activities, "ID", "ID");
            ViewData["BlockingUserID"] = new SelectList(_context.Users, "ID", "ID");
            ViewData["BlockingGroupID"] = new SelectList(_context.Groups, "ID", "ID");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID");
            return View();
        }

        // POST: BlockedUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,BlockingUserID,BlockingGroupID,ActivityID,Created,LastModified,IsDeleted")] BlockedUser blockedUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blockedUser);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ActivityID"] = new SelectList(_context.Activities, "ID", "ID", blockedUser.ActivityID);
            ViewData["BlockingUserID"] = new SelectList(_context.Users, "ID", "ID", blockedUser.BlockingUserID);
            ViewData["BlockingGroupID"] = new SelectList(_context.Groups, "ID", "ID", blockedUser.BlockingGroupID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", blockedUser.UserID);
            return View(blockedUser);
        }

        // GET: BlockedUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blockedUser = await _context.BlockedUsers.SingleOrDefaultAsync(m => m.ID == id);
            if (blockedUser == null)
            {
                return NotFound();
            }
            ViewData["ActivityID"] = new SelectList(_context.Activities, "ID", "ID", blockedUser.ActivityID);
            ViewData["BlockingUserID"] = new SelectList(_context.Users, "ID", "ID", blockedUser.BlockingUserID);
            ViewData["BlockingGroupID"] = new SelectList(_context.Groups, "ID", "ID", blockedUser.BlockingGroupID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", blockedUser.UserID);
            return View(blockedUser);
        }

        // POST: BlockedUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,BlockingUserID,BlockingGroupID,ActivityID,Created,LastModified,IsDeleted")] BlockedUser blockedUser)
        {
            if (id != blockedUser.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blockedUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlockedUserExists(blockedUser.ID))
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
            ViewData["ActivityID"] = new SelectList(_context.Activities, "ID", "ID", blockedUser.ActivityID);
            ViewData["BlockingUserID"] = new SelectList(_context.Users, "ID", "ID", blockedUser.BlockingUserID);
            ViewData["BlockingGroupID"] = new SelectList(_context.Groups, "ID", "ID", blockedUser.BlockingGroupID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", blockedUser.UserID);
            return View(blockedUser);
        }

        // GET: BlockedUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blockedUser = await _context.BlockedUsers
                .Include(b => b.Activity)
                .Include(b => b.BlockingUser)
                .Include(b => b.Group)
                .Include(b => b.UserBeingBlocked)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (blockedUser == null)
            {
                return NotFound();
            }

            return View(blockedUser);
        }

        // POST: BlockedUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blockedUser = await _context.BlockedUsers.SingleOrDefaultAsync(m => m.ID == id);
            _context.BlockedUsers.Remove(blockedUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BlockedUserExists(int id)
        {
            return _context.BlockedUsers.Any(e => e.ID == id);
        }
    }
}
