using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Extensions;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SyllabusController : ControllerBase
    {
        private readonly UniversityDBContext _dbContext;
        private readonly ILogger<SyllabusController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SyllabusController(UniversityDBContext dbContext, ILogger<SyllabusController> logger, 
            IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/Syllabus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Syllabus>>> GetSyllabus()
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(SyllabusController), nameof(GetSyllabus));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);

            if (_dbContext.Syllabus == null)
            {
                _logger.LogCritical("Critical error: Syllabus resource not found!");
                return NotFound();
            }
            return await _dbContext.Syllabus.ToListAsync();
        }

        // GET: api/Syllabus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Syllabus>> GetSyllabus(int id)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(SyllabusController), nameof(GetSyllabus));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);

            if (_dbContext.Syllabus == null)
            {
                _logger.LogCritical("Critical error: Syllabus resource not found!");
                return NotFound();
            }

            _logger.LogInformation("Id param: {SyllabusId}", id);

            var syllabus = await _dbContext.Syllabus.FindAsync(id);

            if (syllabus == null)
            {
                _logger.LogInformation("Syllabus not found!");
                return NotFound();
            }

            return syllabus;
        }

        // Admin only
        // PUT: api/Syllabus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutSyllabus(int id, Syllabus syllabus)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(SyllabusController), nameof(PutSyllabus));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);
            _logger.LogInformation("Id param: {SyllabusId}", id);
            _logger.LogInformation("Request body = {@RequestBody}", syllabus);

            if (_dbContext.Syllabus == null)
            {
                _logger.LogCritical("Critical error: Syllabus resource not found!");
                return NotFound();
            }

            if (id != syllabus.Id)
            {
                _logger.LogInformation("Bad request: invalid student id");
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
                    _logger.LogInformation("Syllabus {SyllabusId} not found", id);
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation("Syllabus not found!");
                    throw;
                }
            }

            return NoContent();
        }

        // Admin only
        // POST: api/Syllabus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<Syllabus>> PostSyllabus(Syllabus syllabus)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(SyllabusController), nameof(PostSyllabus));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);
            _logger.LogInformation("Request body = {@RequestBody}", syllabus);

            if (_dbContext.Syllabus == null)
            {
                _logger.LogCritical("Critical error: Syllabus resource not found!");
                return NotFound();
            }
            _dbContext.Syllabus.Add(syllabus);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetSyllabus", new { id = syllabus.Id }, syllabus);
        }

        // Admin only
        // DELETE: api/Syllabus/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteSyllabus(int id)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(SyllabusController), nameof(DeleteSyllabus));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);

            if (_dbContext.Syllabus == null)
            {
                _logger.LogCritical("Critical error: Syllabus resource not found!");
                return NotFound();
            }

            _logger.LogInformation("Id param: {SyllabusId}", id);

            var syllabus = await _dbContext.Syllabus.FindAsync(id);

            if (syllabus == null)
            {
                _logger.LogInformation("Syllabus not found!");
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
