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
    public class FourthsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public FourthsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Fourths
        [HttpGet]
        public IEnumerable<Fourth> GetFourths()
        {
            return _context.Fourths;
        }

        // GET: api/Fourths/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFourth([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fourth = await _context.Fourths.FindAsync(id);

            if (fourth == null)
            {
                return NotFound();
            }

            return Ok(fourth);
        }

        // PUT: api/Fourths/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFourth([FromRoute] int id, [FromBody] Fourth fourth)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fourth.ID)
            {
                return BadRequest();
            }

            _context.Entry(fourth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FourthExists(id))
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

        // POST: api/Fourths
        [HttpPost]
        public async Task<IActionResult> PostFourth([FromBody] Fourth fourth)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Fourths.Add(fourth);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFourth", new { id = fourth.ID }, fourth);
        }

        // DELETE: api/Fourths/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFourth([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fourth = await _context.Fourths.FindAsync(id);
            if (fourth == null)
            {
                return NotFound();
            }

            _context.Fourths.Remove(fourth);
            await _context.SaveChangesAsync();

            return Ok(fourth);
        }

        private bool FourthExists(int id)
        {
            return _context.Fourths.Any(e => e.ID == id);
        }
    }
}