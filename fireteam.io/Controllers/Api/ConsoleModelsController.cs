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
    [Route("api/console-models")]
    public class ConsoleModelsController : Controller
    {
        private readonly FireteamDbContext _context;

        public ConsoleModelsController(FireteamDbContext context)
        {
            _context = context;
        }

        // GET: api/ConsoleModels
        [HttpGet]
        public IEnumerable<ConsoleModel> GetConsoleModels()
        {
            return _context.ConsoleModels;
        }

        // GET: api/ConsoleModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetConsoleModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consoleModel = await _context.ConsoleModels.SingleOrDefaultAsync(m => m.ID == id);

            if (consoleModel == null)
            {
                return NotFound();
            }

            return Ok(consoleModel);
        }

        // PUT: api/ConsoleModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsoleModel([FromRoute] int id, [FromBody] ConsoleModel consoleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consoleModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(consoleModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsoleModelExists(id))
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

        // POST: api/ConsoleModels
        [HttpPost]
        public async Task<IActionResult> PostConsoleModel([FromBody] ConsoleModel consoleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ConsoleModels.Add(consoleModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsoleModel", new { id = consoleModel.ID }, consoleModel);
        }

        // DELETE: api/ConsoleModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsoleModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consoleModel = await _context.ConsoleModels.SingleOrDefaultAsync(m => m.ID == id);
            if (consoleModel == null)
            {
                return NotFound();
            }

            _context.ConsoleModels.Remove(consoleModel);
            await _context.SaveChangesAsync();

            return Ok(consoleModel);
        }

        private bool ConsoleModelExists(int id)
        {
            return _context.ConsoleModels.Any(e => e.ID == id);
        }
    }
}