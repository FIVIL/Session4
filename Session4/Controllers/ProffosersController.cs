using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Session4.Models;

namespace Session4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProffosersController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public ProffosersController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Proffosers
        [HttpGet]
        [Produces(typeof(IList<Proffoser>))]
        public IActionResult GetProffosers()
        {
            var c=_context.Proffosers.AsNoTracking()
                .Include(x => x.Faculty)
                .Include(x => x.ProffessorFaculties).ThenInclude(y => y.Faculty).ThenInclude(z=>z.Proffosers)
                .ToList();
            return Ok(c);

        }

        // GET: api/Proffosers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProffoser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var proffoser = await _context.Proffosers.FindAsync(id);

            if (proffoser == null)
            {
                return NotFound();
            }

            return Ok(proffoser);
        }

        // PUT: api/Proffosers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProffoser([FromRoute] Guid id, [FromBody] Proffoser proffoser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proffoser.ID)
            {
                return BadRequest();
            }

            _context.Entry(proffoser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProffoserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Proffosers
        [HttpPost]
        public async Task<IActionResult> PostProffoser([FromBody] Proffoser proffoser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Proffosers.Add(proffoser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProffoser", new { id = proffoser.ID }, proffoser);
        }

        // DELETE: api/Proffosers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProffoser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var proffoser = await _context.Proffosers.FindAsync(id);
            if (proffoser == null)
            {
                return NotFound();
            }

            _context.Proffosers.Remove(proffoser);
            await _context.SaveChangesAsync();

            return Ok(proffoser);
        }

        private bool ProffoserExists(Guid id)
        {
            return _context.Proffosers.Any(e => e.ID == id);
        }
    }
}