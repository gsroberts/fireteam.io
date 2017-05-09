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
    [Route("api/blocked-users")]
    public class BlockedUsersController : Controller
    {
        private readonly FireteamDbContext _context;

        public BlockedUsersController(FireteamDbContext context)
        {
            _context = context;
        }

        // GET: api/BlockedUsers
        [HttpGet]
        public IEnumerable<BlockedUser> GetBlockedUsers()
        {
            return _context.BlockedUsers;
        }

        // GET: api/BlockedUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlockedUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blockedUser = await _context.BlockedUsers.SingleOrDefaultAsync(m => m.ID == id);

            if (blockedUser == null)
            {
                return NotFound();
            }

            return Ok(blockedUser);
        }

        // PUT: api/BlockedUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlockedUser([FromRoute] int id, [FromBody] BlockedUser blockedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != blockedUser.ID)
            {
                return BadRequest();
            }

            _context.Entry(blockedUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlockedUserExists(id))
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

        // POST: api/BlockedUsers
        [HttpPost]
        public async Task<IActionResult> PostBlockedUser([FromBody] BlockedUser blockedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.BlockedUsers.Add(blockedUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlockedUser", new { id = blockedUser.ID }, blockedUser);
        }

        // DELETE: api/BlockedUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlockedUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var blockedUser = await _context.BlockedUsers.SingleOrDefaultAsync(m => m.ID == id);
            if (blockedUser == null)
            {
                return NotFound();
            }

            _context.BlockedUsers.Remove(blockedUser);
            await _context.SaveChangesAsync();

            return Ok(blockedUser);
        }

        private bool BlockedUserExists(int id)
        {
            return _context.BlockedUsers.Any(e => e.ID == id);
        }
    }
}