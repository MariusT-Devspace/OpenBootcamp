using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface ICoursesService
    {
        IEnumerable<Course> GetCoursesByCategory(string categoryName);
        IEnumerable<Course> GetCoursesWithNoSyllabus();
        IEnumerable<Course> GetStudentCourses(int studentId);
    }
}
