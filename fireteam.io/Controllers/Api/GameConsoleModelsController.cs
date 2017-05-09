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
    [Route("api/game-console-models")]
    public class GameConsoleModelsController : Controller
    {
        private readonly FireteamDbContext _context;

        public GameConsoleModelsController(FireteamDbContext context)
        {
            _context = context;
        }

        // GET: api/GameConsoleModels
        [HttpGet]
        public IEnumerable<GameConsoleModel> GetGameConsoleModels()
        {
            return _context.GameConsoleModels;
        }

        // GET: api/GameConsoleModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameConsoleModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gameConsoleModel = await _context.GameConsoleModels.SingleOrDefaultAsync(m => m.ID == id);

            if (gameConsoleModel == null)
            {
                return NotFound();
            }

            return Ok(gameConsoleModel);
        }

        // PUT: api/GameConsoleModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameConsoleModel([FromRoute] int id, [FromBody] GameConsoleModel gameConsoleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gameConsoleModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(gameConsoleModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameConsoleModelExists(id))
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

        // POST: api/GameConsoleModels
        [HttpPost]
        public async Task<IActionResult> PostGameConsoleModel([FromBody] GameConsoleModel gameConsoleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GameConsoleModels.Add(gameConsoleModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameConsoleModel", new { id = gameConsoleModel.ID }, gameConsoleModel);
        }

        // DELETE: api/GameConsoleModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameConsoleModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gameConsoleModel = await _context.GameConsoleModels.SingleOrDefaultAsync(m => m.ID == id);
            if (gameConsoleModel == null)
            {
                return NotFound();
            }

            _context.GameConsoleModels.Remove(gameConsoleModel);
            await _context.SaveChangesAsync();

            return Ok(gameConsoleModel);
        }

        private bool GameConsoleModelExists(int id)
        {
            return _context.GameConsoleModels.Any(e => e.ID == id);
        }
    }
}