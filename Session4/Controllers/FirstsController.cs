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
    public class FirstsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public FirstsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Firsts
        [HttpGet]
        public IEnumerable<First> GetFirsts()
        {
            return _context.Firsts.Include(x => x.Seccond);
        }

        // GET: api/Firsts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFirst([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var first = await _context.Firsts.FindAsync(id);

            if (first == null)
            {
                return NotFound();
            }

            return Ok(first);
        }

        // PUT: api/Firsts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFirst([FromRoute] int id, [FromBody] First first)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != first.ID)
            {
                return BadRequest();
            }
            if (first.SeccondID == null && first.Seccond == null)
            {
                var Seccond = (await _context.Firsts.AsNoTracking().FirstOrDefaultAsync(x => x.ID == first.ID));
                first.SeccondID = (Seccond != null) ? Seccond.ID : 0;
            }
            if (first.SeccondID == null && first.Seccond != null)
            {
                var Seccond = await _context.Secconds.FirstOrDefaultAsync(x => x.MyProperty == first.Seccond.MyProperty);
                if (Seccond == null) return BadRequest();
                first.Seccond = null;
                first.SeccondID = Seccond.ID;
                _context.Entry(Seccond).State = EntityState.Modified;
            }
            else
            {
                var SeccondID = first.SeccondID ?? 0;
                var Seccond = (SeccondID != 0) ? await _context.Secconds.FindAsync(SeccondID) : null;
                first.Seccond = null;
                if (Seccond != null) _context.Entry(Seccond).State = EntityState.Modified;
            }
            _context.Entry(first).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirstExists(id))
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

        // POST: api/Firsts
        [HttpPost]
        public async Task<IActionResult> PostFirst([FromBody] First first)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (first.SeccondID == null && first.Seccond != null)
            {
                var Seccond = await _context.Secconds.FirstOrDefaultAsync(x => x.MyProperty == first.Seccond.MyProperty);
                if (Seccond == null) return BadRequest();
                first.Seccond = null;
                first.SeccondID = Seccond.ID;
                _context.Entry(Seccond).State = EntityState.Modified;
            }
            _context.Firsts.Add(first);
            _context.Entry(first).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFirst", new { id = first.ID }, first);
        }

        // DELETE: api/Firsts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFirst([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var first = await _context.Firsts.FindAsync(id);
            if (first == null)
            {
                return NotFound();
            }

            _context.Firsts.Remove(first);
            await _context.SaveChangesAsync();

            return Ok(first);
        }

        private bool FirstExists(int id)
        {
            return _context.Firsts.Any(e => e.ID == id);
        }
    }
}