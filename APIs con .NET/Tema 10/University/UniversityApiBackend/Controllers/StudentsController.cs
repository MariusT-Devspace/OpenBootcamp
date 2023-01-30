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
    public class StudentsController : ControllerBase
    {
        private readonly UniversityDBContext _dbContext;
        private readonly IStudentsService _studentsService;
        private readonly ILogger<StudentsController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StudentsController(UniversityDBContext dbContext, IStudentsService studentsService, 
            ILogger<StudentsController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _studentsService = studentsService;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(StudentsController), nameof(GetStudents));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);

            if (_dbContext.Students == null)
            {
                _logger.LogCritical("Critical error: Students resource not found!");
                return NotFound();
            }
            return await _dbContext.Students.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(StudentsController), nameof(GetStudent));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);

            if (_dbContext.Students == null)
            {
                _logger.LogCritical("Critical error: Students resource not found!");
                return NotFound();
            }

            _logger.LogInformation("Id param: {StudentId}", id);

            var student = await _dbContext.Students.FindAsync(id);

            if (student == null)
            {
                _logger.LogInformation("Student not found!");
                return NotFound();
            }

            return student;
        }

        // GET api/Students/With-Courses
        [HttpGet("With-Courses")]
        public async Task<ActionResult<Student>> GetStudentsWithCourses()
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(StudentsController), nameof(GetStudentsWithCourses));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);


            if (_dbContext.Students == null)
            {
                _logger.LogCritical("Critical error: Students resource not found!");
                return NotFound();
            }

            var students = await _studentsService.GetStudentsWithCoursesAsync();

            return Ok(students);
        }
        
        // GET api/Students/With-No-Courses
        [HttpGet("With-No-Courses")]
        public async Task<ActionResult<Student>> GetStudentsWithNoCourses()
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(StudentsController), nameof(GetStudentsWithNoCourses));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);


            if (_dbContext.Students == null)
            {
                _logger.LogCritical("Critical error: Students resource not found!");
                return NotFound();
            }

            var students = await _studentsService.GetStudentsWithNoCoursesAsync();
            return Ok(students);
        }
        
        // GET api/Students/5/Courses
        [HttpGet("{id}/Courses")]
        public async Task<ActionResult<Student>> GetStudentCourses(int id)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(StudentsController), nameof(GetStudentCourses));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);

            if (_dbContext.Students == null)
            {
                _logger.LogCritical("Critical error: Students resource not found!");
                return NotFound();
            }

            _logger.LogInformation("Id param: {StudentId}", id);

            if (!StudentExists(id))
            {
                _logger.LogInformation("Student {StudentId} not found", id);
                return NotFound();
            }

            var courses = await _studentsService.GetStudentCoursesAsync(id);

            return Ok(courses);
        }

        // Admin only
        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(StudentsController), nameof(PutStudent));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);
            _logger.LogInformation("Id param: {StudentId}", id);
            _logger.LogInformation("Request body = {@RequestBody}", student);

            if (_dbContext.Students == null)
            {
                _logger.LogCritical("Critical error: Students resource not found!");
                return NotFound();
            }

            if (id != student.Id)
            {
                _logger.LogInformation("Bad request: invalid student id");
                return BadRequest();
            }

            _dbContext.Entry(student).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    _logger.LogInformation("Student {StudentId} not found", id);
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
        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(StudentsController), nameof(PostStudent));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);
            _logger.LogInformation("Request body = {@RequestBody}", student);

            if (_dbContext.Students == null)
            {
                _logger.LogCritical("Critical error: Students resource not found!");
                return Problem("Entity set 'UniversityDBContext.Students'  is null.");
            }
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // Admin only
        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(StudentsController), nameof(DeleteStudent));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);

            if (_dbContext.Students == null)
            {
                _logger.LogCritical("Critical error: Students resource not found!");
                return NotFound();
            }

            _logger.LogInformation("Id param: {StudentId}", id);

            var student = await _dbContext.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _dbContext.Students.Remove(student);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return (_dbContext.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
