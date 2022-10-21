using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;
using UniversityApiBackend.Services;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly UniversityDBContext _dbContext;
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(UniversityDBContext dbContext, ICategoriesService categoriesService)
        {
            _dbContext = dbContext;
            _categoriesService = categoriesService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            if (_dbContext.Categories == null)
            {
                return NotFound();
            }
            return await _dbContext.Categories.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            if (_dbContext.Categories == null)
            {
                return NotFound();
            }
            var category = await _dbContext.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // GET: api/Categories/5/Courses
        [HttpGet("{id}/Courses")]
        public async Task<ActionResult<Category>> GetCategoryCourses(int id)
        {
            if (_dbContext.Categories == null)
            {
                return NotFound();
            }

            if (!CategoryExists(id))
            {
                return NotFound();
            }

            var courses = await _categoriesService.GetCategoryCoursesAsync(id);
            return Ok(courses);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(category).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
          if (_dbContext.Categories == null)
          {
              return Problem("Entity set 'UniversityDBContext.Categories'  is null.");
          }
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (_dbContext.Categories == null)
            {
                return NotFound();
            }
            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return (_dbContext.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
