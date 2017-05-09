using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fireteam.Data;
using Fireteam.Models;

namespace Fireteam.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/activity-users")]
    public class ActivityUsersController : Controller
    {
        private readonly FireteamDbContext _context;

        public ActivityUsersController(FireteamDbContext context)
        {
            _context = context;
        }

        // GET: api/ActivityUsers
        [HttpGet]
        public IEnumerable<ActivityUser> GetActivityUsers()
        {
            return _context.ActivityUsers;
        }

        // GET: api/ActivityUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activityUser = await _context.ActivityUsers.SingleOrDefaultAsync(m => m.ID == id);

            if (activityUser == null)
            {
                return NotFound();
            }

            return Ok(activityUser);
        }

        // PUT: api/ActivityUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityUser([FromRoute] int id, [FromBody] ActivityUser activityUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activityUser.ID)
            {
                return BadRequest();
            }

            _context.Entry(activityUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ActivityUsers
        [HttpPost]
        public async Task<IActionResult> PostActivityUser([FromBody] ActivityUser activityUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ActivityUsers.Add(activityUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivityUser", new { id = activityUser.ID }, activityUser);
        }

        // DELETE: api/ActivityUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activityUser = await _context.ActivityUsers.SingleOrDefaultAsync(m => m.ID == id);
            if (activityUser == null)
            {
                return NotFound();
            }

            _context.ActivityUsers.Remove(activityUser);
            await _context.SaveChangesAsync();

            return Ok(activityUser);
        }

        private bool ActivityUserExists(int id)
        {
            return _context.ActivityUsers.Any(e => e.ID == id);
        }
    }
}