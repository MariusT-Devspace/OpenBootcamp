using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface ICoursesService
    {
        Task<IEnumerable<Course>> GetCoursesWithNoSyllabusAsync();
        Task<Syllabus> GetCourseSyllabusAsync(int courseId);
        Task<IEnumerable<Student>> GetCourseStudentsAsync(int courseId);
    }
}
