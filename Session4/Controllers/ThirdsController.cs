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
    public class ThirdsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public ThirdsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Thirds
        [HttpGet]
        public IEnumerable<Third> GetThirds()
        {
            return _context.Thirds;
        }

        // GET: api/Thirds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetThird([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var third = await _context.Thirds.FindAsync(id);

            if (third == null)
            {
                return NotFound();
            }

            return Ok(third);
        }

        // PUT: api/Thirds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThird([FromRoute] Guid id, [FromBody] Third third)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != third.ID)
            {
                return BadRequest();
            }

            _context.Entry(third).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThirdExists(id))
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

        // POST: api/Thirds
        [HttpPost]
        public async Task<IActionResult> PostThird([FromBody] Third third)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Thirds.Add(third);
            _context.Entry(third).State = EntityState.Added;
            var f = third.Fourths;
            third.Fourths = null;
            await _context.SaveChangesAsync();
            if (f != null && f.Count > 0)
            {
                for (int i = 0; i < f.Count; i++)
                {
                    f.ElementAt(i).ThirdID = third.ID;
                    f.ElementAt(i).Third = null;
                    _context.Entry(f.ElementAt(i)).State = EntityState.Modified;
                    _context.Fourths.Update(f.ElementAt(i));
                }
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction("GetThird", new { id = third.ID }, third);
        }

        // DELETE: api/Thirds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThird([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var third = await _context.Thirds.FindAsync(id);
            if (third == null)
            {
                return NotFound();
            }

            _context.Thirds.Remove(third);
            await _context.SaveChangesAsync();

            return Ok(third);
        }

        private bool ThirdExists(Guid id)
        {
            return _context.Thirds.Any(e => e.ID == id);
        }
    }
}