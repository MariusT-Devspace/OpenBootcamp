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
    public class CoursesController : ControllerBase
    {
        private readonly UniversityDBContext _dbContext;
        private readonly ICoursesService _coursesService;
        private readonly ILogger<CoursesController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CoursesController(UniversityDBContext dbContext, ICoursesService coursesService,
            ILogger<CoursesController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _coursesService = coursesService;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(StudentsController), nameof(GetCourses));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);


            if (_dbContext.Courses == null)
            {
                _logger.LogCritical("Critical error: Courses resource not found!");
                return NotFound();
            }
            return await _dbContext.Courses.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(StudentsController), nameof(GetCourse));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);

            if (_dbContext.Courses == null)
            {
                _logger.LogCritical("Critical error: Courses resource not found!");
                return NotFound();
            }

            _logger.LogInformation("Id param: {CourseId}", id);

            var course = await _dbContext.Courses.FindAsync(id);

            if (course == null)
            {
                _logger.LogInformation("Course not found!");
                return NotFound();
            }

            return course;
        }

        // GET: api/Courses/No-Syllabus
        [HttpGet("No-Syllabus")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesWithNoSyllabus()
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(StudentsController), nameof(GetCoursesWithNoSyllabus));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);

            var courses = await _coursesService.GetCoursesWithNoSyllabusAsync();
       
            return Ok(courses);
        }

        // GET: api/Courses/5/Syllabus
        [HttpGet("{id}/Syllabus")]
        public async Task<ActionResult<Syllabus>> GetCourseSyllabus(int id)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(StudentsController), nameof(GetCourseSyllabus));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);

            if (_dbContext.Courses == null)
            {
                _logger.LogCritical("Critical error: Courses resource not found!");
                return NotFound();
            }

            _logger.LogInformation("Id param: {CourseId}", id);

            if (!CourseExists(id))
            {
                _logger.LogInformation("Course not found!");
                return NotFound();
            }

            var syllabus = await _coursesService.GetCourseSyllabusAsync(id);

            return Ok(syllabus);
        }

        // GET: api/Courses/5/Students
        [HttpGet("{id}/Students")]
        public async Task<ActionResult<Syllabus>> GetCourseStudents(int id)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(StudentsController), nameof(GetCourseStudents));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);

            if (_dbContext.Courses == null)
            {
                _logger.LogCritical("Critical error: Courses resource not found!");
                return NotFound();
            }

            _logger.LogInformation("Id param: {CourseId}", id);

            if (!CourseExists(id))
            {
                _logger.LogInformation("Course not found!");
                return NotFound();
            }

            var students = await _coursesService.GetCourseStudentsAsync(id);

            return Ok(students);
        }

        // Admin only
        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(StudentsController), nameof(PutCourse));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);
            _logger.LogInformation("Id param: {CourseId}", id);
            _logger.LogInformation("Request body = {@RequestBody}", course);

            if (_dbContext.Courses == null)
            {
                _logger.LogCritical("Critical error: Courses resource not found!");
                return NotFound();
            }

            if (id != course.Id)
            {
                _logger.LogInformation("Bad request: invalid course id");
                return BadRequest();
            }

            _dbContext.Entry(course).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    _logger.LogInformation("Course {CourseId} not found", id);
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
        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(StudentsController), nameof(PostCourse));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);
            _logger.LogInformation("Request body = {@RequestBody}", course);

            if (_dbContext.Courses == null)
            {
                _logger.LogCritical("Critical error: Courses resource not found!");
                return NotFound();
            }
            _dbContext.Courses.Add(course);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // Admin only
        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            _logger.LogInformation("Correlation id: {CorrelationId}", _httpContextAccessor?.HttpContext?.GetCorrelationId().ToString());
            _logger.LogInformation("{Controller} - {CallMethod}", nameof(StudentsController), nameof(DeleteCourse));
            _logger.LogInformation("Request info: {Headers} ", _httpContextAccessor.HttpContext?.Request.Headers);

            if (_dbContext.Courses == null)
            {
                _logger.LogCritical("Critical error: Courses resource not found!");
                return NotFound();
            }

            _logger.LogInformation("Id param: {CourseId}", id);

            var course = await _dbContext.Courses.FindAsync(id);

            if (course == null)
            {
                _logger.LogInformation("Course not found!");
                return NotFound();
            }

            _dbContext.Courses.Remove(course);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return (_dbContext.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
