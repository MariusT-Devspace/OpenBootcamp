using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly UniversityDBContext _dBContext;
        private readonly ILogger<StudentsService> _logger;

        public StudentsService(UniversityDBContext dBContext, ILogger<StudentsService> logger)
        {
            _dBContext = dBContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Student>> GetStudentsWithCoursesAsync()
        {
            _logger.LogInformation("{Service} - {Method}", nameof(StudentsService), nameof(GetStudentsWithCoursesAsync));

            return await (from student in _dBContext.Students
                  where student.Courses.Any()
                  select student).ToListAsync<Student>();
        }

        public async Task<IEnumerable<Student>> GetStudentsWithNoCoursesAsync()
        {
            _logger.LogInformation("{Service} - {Method}", nameof(StudentsService), nameof(GetStudentsWithNoCoursesAsync));

            return await (from student in _dBContext.Students
                          where !student.Courses.Any()
                          select student).ToListAsync<Student>();
        }
        public async Task<IEnumerable<Course>> GetStudentCoursesAsync(int studentId)
        {
            _logger.LogInformation("{Service} - {Method}", nameof(StudentsService), nameof(GetStudentCoursesAsync));
            _logger.LogInformation("Student id: {StudentId}", studentId);

            return await (from student in _dBContext.Students
                          where student.Id == studentId
                          select student.Courses).SingleAsync<IEnumerable<Course>>();
        }

    }
}
