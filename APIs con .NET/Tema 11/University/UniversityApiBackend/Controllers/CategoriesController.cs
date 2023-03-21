using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Extensions;
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
        private readonly ILogger<CategoriesController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoriesController(UniversityDBContext dbContext, ICategoriesService categoriesService,
            ILogger<CategoriesController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _categoriesService = categoriesService;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(CategoriesController), nameof(GetCategories));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);
            if (_dbContext.Categories == null)
            {
                _logger.LogCritical("Critical error: Categories resource not found!");
                return NotFound();
            }
            return await _dbContext.Categories.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(CategoriesController), nameof(GetCategory));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);

            if (_dbContext.Categories == null)
            {
                _logger.LogCritical("Critical error: Categories resource not found!");
                return NotFound();
            }

            _logger.LogInformation("Id param: {CategoryId}", id);

            var category = await _dbContext.Categories.FindAsync(id);

            if (category == null)
            {
                _logger.LogInformation("Category not found!");
                return NotFound();
            }

            return category;
        }

        // GET: api/Categories/5/Courses
        [HttpGet("{id}/Courses")]
        public async Task<ActionResult<Category>> GetCategoryCourses(int id)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(CategoriesController), nameof(GetCategoryCourses));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);

            if (_dbContext.Categories == null)
            {
                _logger.LogCritical("Critical error: Categories resource not found!");
                return NotFound();
            }

            _logger.LogInformation("Id param: {CategoryId}", id);

            if (!CategoryExists(id))
            {
                _logger.LogInformation("Category not found!");
                return NotFound();
            }

            var courses = await _categoriesService.GetCategoryCoursesAsync(id);
            return Ok(courses);
        }

        // Admin only
        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(CategoriesController), nameof(PutCategory));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);
            _logger.LogInformation("Id param: {CategoryId}", id);
            _logger.LogInformation("Request body = {@RequestBody}", category);

            if (id != category.Id)
            {
                _logger.LogInformation("Bad request: invalid category id");
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
                    _logger.LogInformation("Category {CategoryId} not found", id);
                    return NotFound();
                }
                else
                {
                    _logger.LogError("Db Update Concurrency Exception");
                    throw;
                }
            }

            return NoContent();
        }

        // Admin only
        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(CategoriesController), nameof(PostCategory));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);
            _logger.LogInformation("Request body = {@RequestBody}", category);

            if (_dbContext.Categories == null)
          {
                _logger.LogCritical("Critical error: Categories resource not found!");
                return Problem("Entity set 'UniversityDBContext.Categories'  is null.");
          }
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // Admin only
        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(CategoriesController), nameof(DeleteCategory));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);

            if (_dbContext.Categories == null)
            {
                _logger.LogCritical("Critical error: Categories resource not found!");
                return NotFound();
            }

            _logger.LogInformation("Id param: {CategoryId}", id);

            var category = await _dbContext.Categories.FindAsync(id);
            if (category == null)
            {
                _logger.LogInformation("Category not found!");
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
