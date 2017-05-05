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
    [Route("api/group-types")]
    public class GroupTypesController : Controller
    {
        private readonly FireteamDbContext _context;

        public GroupTypesController(FireteamDbContext context)
        {
            _context = context;
        }

        // GET: api/GroupTypes
        [HttpGet]
        public IEnumerable<GroupType> GetGroupTypes()
        {
            return _context.GroupTypes;
        }

        // GET: api/GroupTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupType = await _context.GroupTypes.SingleOrDefaultAsync(m => m.ID == id);

            if (groupType == null)
            {
                return NotFound();
            }

            return Ok(groupType);
        }

        // PUT: api/GroupTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupType([FromRoute] int id, [FromBody] GroupType groupType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupType.ID)
            {
                return BadRequest();
            }

            _context.Entry(groupType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupTypeExists(id))
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

        // POST: api/GroupTypes
        [HttpPost]
        public async Task<IActionResult> PostGroupType([FromBody] GroupType groupType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GroupTypes.Add(groupType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupType", new { id = groupType.ID }, groupType);
        }

        // DELETE: api/GroupTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupType = await _context.GroupTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (groupType == null)
            {
                return NotFound();
            }

            _context.GroupTypes.Remove(groupType);
            await _context.SaveChangesAsync();

            return Ok(groupType);
        }

        private bool GroupTypeExists(int id)
        {
            return _context.GroupTypes.Any(e => e.ID == id);
        }
    }
}