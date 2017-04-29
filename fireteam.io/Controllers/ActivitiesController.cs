using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fireteam.Data;
using Fireteam.Models;

namespace fireteam.io.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly FireteamDbContext _context;

        public ActivitiesController(FireteamDbContext context)
        {
            _context = context;    
        }

        // GET: Activities
        public async Task<IActionResult> Index()
        {
            var fireteamDbContext = _context.Activities.Include(a => a.ActivityType).Include(a => a.Game).Include(a => a.Group).Include(a => a.Organizer);
            return View(await fireteamDbContext.ToListAsync());
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .Include(a => a.ActivityType)
                .Include(a => a.Game)
                .Include(a => a.Group)
                .Include(a => a.Organizer)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            ViewData["ActivityTypeID"] = new SelectList(_context.ActivityTypes, "ID", "ID");
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID");
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID");
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AvailableSlots,ReservedSlots,StartTime,Duration,TimeZone,IsHidden,IsInviteOnly,ActivityTypeID,Description,Requirements,GameID,GroupID,UserID,Created,LastModified,IsDeleted")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ActivityTypeID"] = new SelectList(_context.ActivityTypes, "ID", "ID", activity.ActivityTypeID);
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID", activity.GameID);
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID", activity.GroupID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", activity.UserID);
            return View(activity);
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities.SingleOrDefaultAsync(m => m.ID == id);
            if (activity == null)
            {
                return NotFound();
            }
            ViewData["ActivityTypeID"] = new SelectList(_context.ActivityTypes, "ID", "ID", activity.ActivityTypeID);
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID", activity.GameID);
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID", activity.GroupID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", activity.UserID);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AvailableSlots,ReservedSlots,StartTime,Duration,TimeZone,IsHidden,IsInviteOnly,ActivityTypeID,Description,Requirements,GameID,GroupID,UserID,Created,LastModified,IsDeleted")] Activity activity)
        {
            if (id != activity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityExists(activity.ID))
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
            ViewData["ActivityTypeID"] = new SelectList(_context.ActivityTypes, "ID", "ID", activity.ActivityTypeID);
            ViewData["GameID"] = new SelectList(_context.Games, "ID", "ID", activity.GameID);
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID", activity.GroupID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "ID", activity.UserID);
            return View(activity);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .Include(a => a.ActivityType)
                .Include(a => a.Game)
                .Include(a => a.Group)
                .Include(a => a.Organizer)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = await _context.Activities.SingleOrDefaultAsync(m => m.ID == id);
            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ActivityExists(int id)
        {
            return _context.Activities.Any(e => e.ID == id);
        }
    }
}
