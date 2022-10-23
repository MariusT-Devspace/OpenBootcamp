using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly UniversityDBContext _dBContext;
        public CoursesService(UniversityDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<IEnumerable<Course>> GetCoursesWithNoSyllabusAsync()
        {
           return await (from course in _dBContext.Courses
                  where course.Syllabus == null
                  select course).ToListAsync<Course>();
        }

        public async Task<Syllabus> GetCourseSyllabusAsync(int courseId)
        {
            return await (from course in _dBContext.Courses
                          where course.Id == courseId
                          select course.Syllabus).SingleAsync();
        }

        public async Task<IEnumerable<Student>> GetCourseStudentsAsync(int courseId)
        {
            return await (from course in _dBContext.Courses
                          where course.Id == courseId
                          select course.Students).SingleAsync<IEnumerable<Student>>();
        }
    }
}
