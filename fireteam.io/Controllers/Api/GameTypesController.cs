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
    [Route("api/GameTypes")]
    public class GameTypesController : Controller
    {
        private readonly FireteamDbContext _context;

        public GameTypesController(FireteamDbContext context)
        {
            _context = context;
        }

        // GET: api/GameTypes
        [HttpGet]
        public IEnumerable<GameType> GetGameTypes()
        {
            return _context.GameTypes;
        }

        // GET: api/GameTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gameType = await _context.GameTypes.SingleOrDefaultAsync(m => m.ID == id);

            if (gameType == null)
            {
                return NotFound();
            }

            return Ok(gameType);
        }

        // PUT: api/GameTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameType([FromRoute] int id, [FromBody] GameType gameType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gameType.ID)
            {
                return BadRequest();
            }

            _context.Entry(gameType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameTypeExists(id))
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

        // POST: api/GameTypes
        [HttpPost]
        public async Task<IActionResult> PostGameType([FromBody] GameType gameType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GameTypes.Add(gameType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameType", new { id = gameType.ID }, gameType);
        }

        // DELETE: api/GameTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gameType = await _context.GameTypes.SingleOrDefaultAsync(m => m.ID == id);
            if (gameType == null)
            {
                return NotFound();
            }

            _context.GameTypes.Remove(gameType);
            await _context.SaveChangesAsync();

            return Ok(gameType);
        }

        private bool GameTypeExists(int id)
        {
            return _context.GameTypes.Any(e => e.ID == id);
        }
    }
}