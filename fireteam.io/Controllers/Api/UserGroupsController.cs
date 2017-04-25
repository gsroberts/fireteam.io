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
    [Route("api/UserGroups")]
    public class UserGroupsController : Controller
    {
        private readonly FireteamDbContext _context;

        public UserGroupsController(FireteamDbContext context)
        {
            _context = context;
        }

        // GET: api/UserGroups
        [HttpGet]
        public IEnumerable<UserGroup> GetUserGroups()
        {
            return _context.UserGroups;
        }

        // GET: api/UserGroups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserGroup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userGroup = await _context.UserGroups.SingleOrDefaultAsync(m => m.ID == id);

            if (userGroup == null)
            {
                return NotFound();
            }

            return Ok(userGroup);
        }

        // PUT: api/UserGroups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserGroup([FromRoute] int id, [FromBody] UserGroup userGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userGroup.ID)
            {
                return BadRequest();
            }

            _context.Entry(userGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserGroupExists(id))
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

        // POST: api/UserGroups
        [HttpPost]
        public async Task<IActionResult> PostUserGroup([FromBody] UserGroup userGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserGroups.Add(userGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserGroup", new { id = userGroup.ID }, userGroup);
        }

        // DELETE: api/UserGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserGroup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userGroup = await _context.UserGroups.SingleOrDefaultAsync(m => m.ID == id);
            if (userGroup == null)
            {
                return NotFound();
            }

            _context.UserGroups.Remove(userGroup);
            await _context.SaveChangesAsync();

            return Ok(userGroup);
        }

        private bool UserGroupExists(int id)
        {
            return _context.UserGroups.Any(e => e.ID == id);
        }
    }
}