using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Session4.Models;
using Session4.Models.SimpleModels;

namespace Session4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeccondsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public SeccondsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Secconds
        [HttpGet]
        public IEnumerable<Seccond> GetSecconds()
        {
            return _context.Secconds;
        }

        // GET: api/Secconds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeccond([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var seccond = await _context.Secconds.FindAsync(id);

            if (seccond == null)
            {
                return NotFound();
            }

            return Ok(seccond);
        }

        // PUT: api/Secconds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeccond([FromRoute] int id, [FromBody] Seccond seccond)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != seccond.ID)
            {
                return BadRequest();
            }

            _context.Entry(seccond).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeccondExists(id))
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

        // POST: api/Secconds
        [HttpPost]
        public async Task<IActionResult> PostSeccond([FromBody] Seccond seccond)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Secconds.Add(seccond);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeccond", new { id = seccond.ID }, seccond);
        }

        // DELETE: api/Secconds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeccond([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var seccond = await _context.Secconds.FindAsync(id);
            if (seccond == null)
            {
                return NotFound();
            }

            _context.Secconds.Remove(seccond);
            await _context.SaveChangesAsync();

            return Ok(seccond);
        }

        private bool SeccondExists(int id)
        {
            return _context.Secconds.Any(e => e.ID == id);
        }
    }
}