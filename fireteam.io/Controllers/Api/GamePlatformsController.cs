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
    [Route("api/game-platforms")]
    public class GamePlatformsController : Controller
    {
        private readonly FireteamDbContext _context;

        public GamePlatformsController(FireteamDbContext context)
        {
            _context = context;
        }

        // GET: api/GamePlatforms
        [HttpGet]
        public IEnumerable<GamePlatform> GetGamePlatforms()
        {
            return _context.GamePlatforms;
        }

        // GET: api/GamePlatforms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGamePlatform([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gamePlatform = await _context.GamePlatforms.SingleOrDefaultAsync(m => m.ID == id);

            if (gamePlatform == null)
            {
                return NotFound();
            }

            return Ok(gamePlatform);
        }

        // PUT: api/GamePlatforms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGamePlatform([FromRoute] int id, [FromBody] GamePlatform gamePlatform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gamePlatform.ID)
            {
                return BadRequest();
            }

            _context.Entry(gamePlatform).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamePlatformExists(id))
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

        // POST: api/GamePlatforms
        [HttpPost]
        public async Task<IActionResult> PostGamePlatform([FromBody] GamePlatform gamePlatform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GamePlatforms.Add(gamePlatform);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGamePlatform", new { id = gamePlatform.ID }, gamePlatform);
        }

        // DELETE: api/GamePlatforms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGamePlatform([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gamePlatform = await _context.GamePlatforms.SingleOrDefaultAsync(m => m.ID == id);
            if (gamePlatform == null)
            {
                return NotFound();
            }

            _context.GamePlatforms.Remove(gamePlatform);
            await _context.SaveChangesAsync();

            return Ok(gamePlatform);
        }

        private bool GamePlatformExists(int id)
        {
            return _context.GamePlatforms.Any(e => e.ID == id);
        }
    }
}