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
    [Route("api/platform-accounts")]
    public class PlatformAccountsController : Controller
    {
        private readonly FireteamDbContext _context;

        public PlatformAccountsController(FireteamDbContext context)
        {
            _context = context;
        }

        // GET: api/PlatformAccounts
        [HttpGet]
        public IEnumerable<PlatformAccount> GetPlatformAccounts()
        {
            return _context.PlatformAccounts;
        }

        // GET: api/PlatformAccounts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlatformAccount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var platformAccount = await _context.PlatformAccounts.SingleOrDefaultAsync(m => m.ID == id);

            if (platformAccount == null)
            {
                return NotFound();
            }

            return Ok(platformAccount);
        }

        // PUT: api/PlatformAccounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlatformAccount([FromRoute] int id, [FromBody] PlatformAccount platformAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != platformAccount.ID)
            {
                return BadRequest();
            }

            _context.Entry(platformAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatformAccountExists(id))
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

        // POST: api/PlatformAccounts
        [HttpPost]
        public async Task<IActionResult> PostPlatformAccount([FromBody] PlatformAccount platformAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PlatformAccounts.Add(platformAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlatformAccount", new { id = platformAccount.ID }, platformAccount);
        }

        // DELETE: api/PlatformAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlatformAccount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var platformAccount = await _context.PlatformAccounts.SingleOrDefaultAsync(m => m.ID == id);
            if (platformAccount == null)
            {
                return NotFound();
            }

            _context.PlatformAccounts.Remove(platformAccount);
            await _context.SaveChangesAsync();

            return Ok(platformAccount);
        }

        private bool PlatformAccountExists(int id)
        {
            return _context.PlatformAccounts.Any(e => e.ID == id);
        }
    }
}