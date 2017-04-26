using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fireteam.Data;
using Fireteam.Models;

namespace fireteam.io.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/group-platforms")]
    public class GroupPlatformsController : Controller
    {
        private readonly FireteamDbContext _context;

        public GroupPlatformsController(FireteamDbContext context)
        {
            _context = context;
        }

        // GET: api/GroupPlatforms
        [HttpGet]
        public IEnumerable<GroupPlatform> GetGroupPlatform()
        {
            return _context.GroupPlatform;
        }

        // GET: api/GroupPlatforms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupPlatform([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupPlatform = await _context.GroupPlatform.SingleOrDefaultAsync(m => m.ID == id);

            if (groupPlatform == null)
            {
                return NotFound();
            }

            return Ok(groupPlatform);
        }

        // PUT: api/GroupPlatforms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupPlatform([FromRoute] int id, [FromBody] GroupPlatform groupPlatform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupPlatform.ID)
            {
                return BadRequest();
            }

            _context.Entry(groupPlatform).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupPlatformExists(id))
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

        // POST: api/GroupPlatforms
        [HttpPost]
        public async Task<IActionResult> PostGroupPlatform([FromBody] GroupPlatform groupPlatform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GroupPlatform.Add(groupPlatform);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupPlatform", new { id = groupPlatform.ID }, groupPlatform);
        }

        // DELETE: api/GroupPlatforms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupPlatform([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupPlatform = await _context.GroupPlatform.SingleOrDefaultAsync(m => m.ID == id);
            if (groupPlatform == null)
            {
                return NotFound();
            }

            _context.GroupPlatform.Remove(groupPlatform);
            await _context.SaveChangesAsync();

            return Ok(groupPlatform);
        }

        private bool GroupPlatformExists(int id)
        {
            return _context.GroupPlatform.Any(e => e.ID == id);
        }
    }
}