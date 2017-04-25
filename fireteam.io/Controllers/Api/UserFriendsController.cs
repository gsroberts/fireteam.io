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
    [Route("api/UserFriends")]
    public class UserFriendsController : Controller
    {
        private readonly FireteamDbContext _context;

        public UserFriendsController(FireteamDbContext context)
        {
            _context = context;
        }

        // GET: api/UserFriends
        [HttpGet]
        public IEnumerable<UserFriend> GetUserFriends()
        {
            return _context.UserFriends;
        }

        // GET: api/UserFriends/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserFriend([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userFriend = await _context.UserFriends.SingleOrDefaultAsync(m => m.ID == id);

            if (userFriend == null)
            {
                return NotFound();
            }

            return Ok(userFriend);
        }

        // PUT: api/UserFriends/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserFriend([FromRoute] int id, [FromBody] UserFriend userFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userFriend.ID)
            {
                return BadRequest();
            }

            _context.Entry(userFriend).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserFriendExists(id))
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

        // POST: api/UserFriends
        [HttpPost]
        public async Task<IActionResult> PostUserFriend([FromBody] UserFriend userFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserFriends.Add(userFriend);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserFriend", new { id = userFriend.ID }, userFriend);
        }

        // DELETE: api/UserFriends/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserFriend([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userFriend = await _context.UserFriends.SingleOrDefaultAsync(m => m.ID == id);
            if (userFriend == null)
            {
                return NotFound();
            }

            _context.UserFriends.Remove(userFriend);
            await _context.SaveChangesAsync();

            return Ok(userFriend);
        }

        private bool UserFriendExists(int id)
        {
            return _context.UserFriends.Any(e => e.ID == id);
        }
    }
}