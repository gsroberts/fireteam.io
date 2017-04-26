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
    [Route("api/user-games")]
    public class UserGamesController : Controller
    {
        private readonly FireteamDbContext _context;

        public UserGamesController(FireteamDbContext context)
        {
            _context = context;
        }

        // GET: api/UserGames
        [HttpGet]
        public IEnumerable<UserGame> GetUserGames()
        {
            return _context.UserGames;
        }

        // GET: api/UserGames/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserGame([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userGame = await _context.UserGames.SingleOrDefaultAsync(m => m.ID == id);

            if (userGame == null)
            {
                return NotFound();
            }

            return Ok(userGame);
        }

        // PUT: api/UserGames/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserGame([FromRoute] int id, [FromBody] UserGame userGame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userGame.ID)
            {
                return BadRequest();
            }

            _context.Entry(userGame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserGameExists(id))
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

        // POST: api/UserGames
        [HttpPost]
        public async Task<IActionResult> PostUserGame([FromBody] UserGame userGame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserGames.Add(userGame);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserGame", new { id = userGame.ID }, userGame);
        }

        // DELETE: api/UserGames/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserGame([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userGame = await _context.UserGames.SingleOrDefaultAsync(m => m.ID == id);
            if (userGame == null)
            {
                return NotFound();
            }

            _context.UserGames.Remove(userGame);
            await _context.SaveChangesAsync();

            return Ok(userGame);
        }

        private bool UserGameExists(int id)
        {
            return _context.UserGames.Any(e => e.ID == id);
        }
    }
}