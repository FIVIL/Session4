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
    public class FifthsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public FifthsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Fifths
        [HttpGet]
        public IEnumerable<Fifth> GetFifths()
        {
            return _context.Fifths;
        }

        // GET: api/Fifths/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFifth([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fifth = await _context.Fifths.FindAsync(id);

            if (fifth == null)
            {
                return NotFound();
            }

            return Ok(fifth);
        }

        // PUT: api/Fifths/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFifth([FromRoute] int id, [FromBody] Fifth fifth)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fifth.FirstID)
            {
                return BadRequest();
            }

            _context.Entry(fifth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FifthExists(id))
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

        // POST: api/Fifths
        [HttpPost]
        public async Task<IActionResult> PostFifth([FromBody] Fifth fifth)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Fifths.Add(fifth);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FifthExists(fifth.FirstID))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFifth", new { id = fifth.FirstID }, fifth);
        }

        // DELETE: api/Fifths/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFifth([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fifth = await _context.Fifths.FindAsync(id);
            if (fifth == null)
            {
                return NotFound();
            }

            _context.Fifths.Remove(fifth);
            await _context.SaveChangesAsync();

            return Ok(fifth);
        }

        private bool FifthExists(int id)
        {
            return _context.Fifths.Any(e => e.FirstID == id);
        }
    }
}