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
    public class ActivityUsersController : Controller
    {
        private readonly FireteamDbContext _context;

        public ActivityUsersController(FireteamDbContext context)
        {
            _context = context;    
        }

        // GET: ActivityUsers
        public async Task<IActionResult> Index(string username)
        {
            var activityUsers = (this.User != null) ? _context.ActivityUsers
                                                                    .Where(a => a.User.UserName == this.User.Identity.Name)
                                                                    .Include(a => a.Activity)
                                                                        .ThenInclude(a => a.ActivityType)
                                                                    .Include(a => a.User) : _context.ActivityUsers
                                                                                                            .Include(a => a.Activity)
                                                                                                                .ThenInclude(a => a.ActivityType)
                                                                                                            .Include(a => a.User);

            

            ViewData["Username"] = username;

            return View(await activityUsers.ToListAsync());
        }

        // GET: ActivityUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityUser = await _context.ActivityUsers
                .Include(a => a.Activity)
                .Include(a => a.User)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (activityUser == null)
            {
                return NotFound();
            }

            return View(activityUser);
        }

        // GET: ActivityUsers/Create
        public IActionResult Create()
        {
            ViewData["ActivityID"] = new SelectList(_context.Activities, "ID", "ID");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID");
            return View();
        }

        // POST: ActivityUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ActivityID,UserID,IsTentative,IsAlternate,HasBeenBooted,ReasonForBoot,Created,LastModified,IsDeleted")] ActivityUser activityUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activityUser);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ActivityID"] = new SelectList(_context.Activities, "ID", "ID", activityUser.ActivityID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", activityUser.UserID);
            return View(activityUser);
        }

        // GET: ActivityUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityUser = await _context.ActivityUsers.SingleOrDefaultAsync(m => m.ID == id);
            if (activityUser == null)
            {
                return NotFound();
            }
            ViewData["ActivityID"] = new SelectList(_context.Activities, "ID", "ID", activityUser.ActivityID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", activityUser.UserID);
            return View(activityUser);
        }

        // POST: ActivityUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ActivityID,UserID,IsTentative,IsAlternate,HasBeenBooted,ReasonForBoot,Created,LastModified,IsDeleted")] ActivityUser activityUser)
        {
            if (id != activityUser.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityUserExists(activityUser.ID))
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
            ViewData["ActivityID"] = new SelectList(_context.Activities, "ID", "ID", activityUser.ActivityID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", activityUser.UserID);
            return View(activityUser);
        }

        // GET: ActivityUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityUser = await _context.ActivityUsers
                .Include(a => a.Activity)
                .Include(a => a.User)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (activityUser == null)
            {
                return NotFound();
            }

            return View(activityUser);
        }

        // POST: ActivityUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityUser = await _context.ActivityUsers.SingleOrDefaultAsync(m => m.ID == id);
            _context.ActivityUsers.Remove(activityUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ActivityUserExists(int id)
        {
            return _context.ActivityUsers.Any(e => e.ID == id);
        }
    }
}
