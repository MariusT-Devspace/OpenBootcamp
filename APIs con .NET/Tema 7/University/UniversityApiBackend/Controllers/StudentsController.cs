using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using UniversityApiBackend.DataAccess;
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

        public StudentsController(UniversityDBContext dbContext, IStudentsService studentsService)
        {
            _dbContext = dbContext;
            _studentsService = studentsService;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
          if (_dbContext.Students == null)
          {
              return NotFound();
          }
            return await _dbContext.Students.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
          if (_dbContext.Students == null)
          {
              return NotFound();
          }
            var student = await _dbContext.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // GET api/Students/With-Courses
        [HttpGet("With-Courses")]
        public async Task<ActionResult<Student>> GetStudentsWithCourses()
        {
            var students = await _studentsService.GetStudentsWithCoursesAsync();

            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }
        
        // GET api/Students/With-No-Courses
        [HttpGet("With-No-Courses")]
        public async Task<ActionResult<Student>> GetStudentsWithNoCourses()
        {
            var students = await _studentsService.GetStudentsWithNoCoursesAsync();

            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }
        
        // GET api/Students/5/Courses
        [HttpGet("{id}/Courses")]
        public async Task<ActionResult<Student>> GetStudentCourses(int id)
        {
            if (_dbContext.Students == null)
            {
                return NotFound();
            }

            if (!StudentExists(id))
            {
                return NotFound();
            }

            var courses = await _studentsService.GetStudentCoursesAsync(id);

            if (courses == null)
            {
                return NotFound();
            }
            return Ok(courses);
        }

        // Admin only
        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
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
        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
          if (_dbContext.Students == null)
          {
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
            if (_dbContext.Students == null)
            {
                return NotFound();
            }
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
