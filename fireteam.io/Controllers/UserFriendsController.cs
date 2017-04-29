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
    public class UserFriendsController : Controller
    {
        private readonly FireteamDbContext _context;

        public UserFriendsController(FireteamDbContext context)
        {
            _context = context;    
        }

        // GET: UserFriends
        public async Task<IActionResult> Index()
        {
            var fireteamDbContext = _context.UserFriends.Include(u => u.Friend).Include(u => u.FriendedUser);
            return View(await fireteamDbContext.ToListAsync());
        }

        // GET: UserFriends/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFriend = await _context.UserFriends
                .Include(u => u.Friend)
                .Include(u => u.FriendedUser)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (userFriend == null)
            {
                return NotFound();
            }

            return View(userFriend);
        }

        // GET: UserFriends/Create
        public IActionResult Create()
        {
            ViewData["FriendID"] = new SelectList(_context.Users, "ID", "ID");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID");
            return View();
        }

        // POST: UserFriends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserID,FriendID,CanAddToActivities,Created,LastModified,IsDeleted")] UserFriend userFriend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userFriend);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["FriendID"] = new SelectList(_context.Users, "ID", "ID", userFriend.FriendID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", userFriend.UserID);
            return View(userFriend);
        }

        // GET: UserFriends/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFriend = await _context.UserFriends.SingleOrDefaultAsync(m => m.ID == id);
            if (userFriend == null)
            {
                return NotFound();
            }
            ViewData["FriendID"] = new SelectList(_context.Users, "ID", "ID", userFriend.FriendID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", userFriend.UserID);
            return View(userFriend);
        }

        // POST: UserFriends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserID,FriendID,CanAddToActivities,Created,LastModified,IsDeleted")] UserFriend userFriend)
        {
            if (id != userFriend.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userFriend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserFriendExists(userFriend.ID))
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
            ViewData["FriendID"] = new SelectList(_context.Users, "ID", "ID", userFriend.FriendID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", userFriend.UserID);
            return View(userFriend);
        }

        // GET: UserFriends/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userFriend = await _context.UserFriends
                .Include(u => u.Friend)
                .Include(u => u.FriendedUser)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (userFriend == null)
            {
                return NotFound();
            }

            return View(userFriend);
        }

        // POST: UserFriends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userFriend = await _context.UserFriends.SingleOrDefaultAsync(m => m.ID == id);
            _context.UserFriends.Remove(userFriend);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserFriendExists(int id)
        {
            return _context.UserFriends.Any(e => e.ID == id);
        }
    }
}
