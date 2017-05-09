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
    [Route("api/activity-types")]
    public class ActivityTypesController : Controller
    {
        private readonly FireteamDbContext _context;

        public ActivityTypesController(FireteamDbContext context)
        {
            _context = context;
        }

        // GET: api/ActivityTypes
        [HttpGet]
        public IEnumerable<ActivityType> GetActivityTypes()
        {
            return _context.ActivityTypes;
        }

        // GET: api/ActivityTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivityType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activityType = await _context.ActivityTypes.SingleOrDefaultAsync(m => m.ID == id);

            if (activityType == null)
            {
                return NotFound();
            }

            return Ok(activityType);
        }

        // PUT: api/ActivityTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivityType([FromRoute] int id, [FromBody] ActivityType activityType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != activityType.ID)
            {
                return BadRequest();
            }

            _context.Entry(activityType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityTypeExists(id))
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

        // POST: api/ActivityTypes
        [HttpPost]
        public async Task<IActionResult> PostActivityType([FromBody] ActivityType activityType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ActivityTypes.Add(activityType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivityType", new { id = activityType.ID }, activityType);
        }

        // DELETE: api/ActivityTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivityType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activityType = await _context.ActivityTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (activityType == null)
            {
                return NotFound();
            }

            _context.ActivityTypes.Remove(activityType);
            await _context.SaveChangesAsync();

            return Ok(activityType);
        }

        private bool ActivityTypeExists(int id)
        {
            return _context.ActivityTypes.Any(e => e.ID == id);
        }
    }
}