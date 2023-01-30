using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly UniversityDBContext _dBContext;
        private readonly ILogger<CoursesService> _logger;

        public CoursesService(UniversityDBContext dBContext, ILogger<CoursesService> logger)
        {
            _dBContext = dBContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Course>> GetCoursesWithNoSyllabusAsync()
        {
            _logger.LogInformation("{Service} - {Method}", nameof(CoursesService), nameof(GetCoursesWithNoSyllabusAsync));

            return await (from course in _dBContext.Courses
                  where course.Syllabus == null
                  select course).ToListAsync<Course>();
        }

        public async Task<Syllabus> GetCourseSyllabusAsync(int courseId)
        {
            _logger.LogInformation("{Service} - {Method}", nameof(CoursesService), nameof(GetCourseSyllabusAsync));
            _logger.LogInformation("Course id: {CourseId}", courseId);

            return await (from course in _dBContext.Courses
                          where course.Id == courseId
                          select course.Syllabus).SingleAsync();
        }

        public async Task<IEnumerable<Student>> GetCourseStudentsAsync(int courseId)
        {
            _logger.LogInformation("{Service} - {Method}", nameof(CoursesService), nameof(GetCourseStudentsAsync));
            _logger.LogInformation("Course id: {CourseId}", courseId);

            return await (from course in _dBContext.Courses
                          where course.Id == courseId
                          select course.Students).SingleAsync<IEnumerable<Student>>();
        }
    }
}
