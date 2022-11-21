using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
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

        public CoursesController(UniversityDBContext dbContext, ICoursesService coursesService)
        {
            _dbContext = dbContext;
            _coursesService = coursesService;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            if (_dbContext.Courses == null)
            {
                return NotFound();
            }
            return await _dbContext.Courses.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            if (_dbContext.Courses == null)
            {
                return NotFound();
            }
            var course = await _dbContext.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // GET: api/Courses/No-Syllabus
        [HttpGet("No-Syllabus")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesWithNoSyllabus()
        {
            var courses = await _coursesService.GetCoursesWithNoSyllabusAsync();
       
            return Ok(courses);
        }

        // GET: api/Courses/5/Syllabus
        [HttpGet("{id}/Syllabus")]
        public async Task<ActionResult<Syllabus>> GetCourseSyllabus(int id)
        {
            if (_dbContext.Courses == null)
            {
                return NotFound();
            }

            if (!CourseExists(id))
            {
                return NotFound();
            }

            var syllabus = await _coursesService.GetCourseSyllabusAsync(id);

            if (syllabus == null)
            {
                return NotFound();
            }
            return Ok(syllabus);
        }

        // GET: api/Courses/5/Students
        [HttpGet("{id}/Students")]
        public async Task<ActionResult<Syllabus>> GetCourseStudents(int id)
        {
            if (_dbContext.Courses == null)
            {
                return NotFound();
            }

            if (!CourseExists(id))
            {
                return NotFound();
            }

            var students = await _coursesService.GetCourseStudentsAsync(id);

            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }

        // Admin only
        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.Id)
            {
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
                    return NotFound();
                }
                else
                {
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
            if (_dbContext.Courses == null)
            {
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
            if (_dbContext.Courses == null)
            {
                return NotFound();
            }
            var course = await _dbContext.Courses.FindAsync(id);
            if (course == null)
            {
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
