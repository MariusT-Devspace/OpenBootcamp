using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class CoursesService : ICoursesService
    {
        public IEnumerable<Course> GetCoursesByCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetCoursesWithNoSyllabus()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetStudentCourses(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
