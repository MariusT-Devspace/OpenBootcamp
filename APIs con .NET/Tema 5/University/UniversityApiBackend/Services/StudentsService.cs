using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly UniversityDBContext _dBContext;

        public StudentsService(UniversityDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<IEnumerable<Student>> GetStudentsWithCoursesAsync()
        {
           return await (from student in _dBContext.Students
                  where student.Courses.Any()
                  select student).ToListAsync<Student>();
        }

        public async Task<IEnumerable<Student>> GetStudentsWithNoCoursesAsync()
        {
            return await (from student in _dBContext.Students
                          where !student.Courses.Any()
                          select student).ToListAsync<Student>();
        }
        public async Task<IEnumerable<Course>> GetStudentCoursesAsync(int studentId)
        {
            return await (from student in _dBContext.Students
                          where student.Id == studentId
                          select student.Courses).SingleAsync<IEnumerable<Course>>();
        }

    }
}
