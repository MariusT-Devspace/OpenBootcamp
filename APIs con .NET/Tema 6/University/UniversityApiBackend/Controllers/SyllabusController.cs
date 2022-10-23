using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyllabusController : ControllerBase
    {
        private readonly UniversityDBContext _dbContext;

        public SyllabusController(UniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Syllabus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Syllabus>>> GetSyllabus()
        {
            if (_dbContext.Syllabus == null)
            {
                return NotFound();
            }
            return await _dbContext.Syllabus.ToListAsync();
        }

        // GET: api/Syllabus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Syllabus>> GetSyllabus(int id)
        {   
            if (_dbContext.Syllabus == null)
            {
                return NotFound();
            }

            var syllabus = await _dbContext.Syllabus.FindAsync(id);

            if (syllabus == null)
            {
                return NotFound();
            }

            return syllabus;
        }

        // PUT: api/Syllabus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSyllabus(int id, Syllabus syllabus)
        {
            if (id != syllabus.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(syllabus).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SyllabusExists(id))
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

        // POST: api/Syllabus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Syllabus>> PostSyllabus(Syllabus syllabus)
        {
            if (_dbContext.Syllabus == null)
            {
                return NotFound();
            }
            _dbContext.Syllabus.Add(syllabus);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetSyllabus", new { id = syllabus.Id }, syllabus);
        }

        // DELETE: api/Syllabus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSyllabus(int id)
        {
            if (_dbContext.Syllabus == null)
            {
                return NotFound();
            }

            var syllabus = await _dbContext.Syllabus.FindAsync(id);
            if (syllabus == null)
            {
                return NotFound();
            }

            _dbContext.Syllabus.Remove(syllabus);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool SyllabusExists(int id)
        {
            return (_dbContext.Syllabus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
