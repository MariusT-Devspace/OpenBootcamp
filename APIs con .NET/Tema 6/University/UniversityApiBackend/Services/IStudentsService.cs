using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface IStudentsService
    {
        Task<IEnumerable<Student>> GetStudentsWithCoursesAsync();
        Task<IEnumerable<Student>> GetStudentsWithNoCoursesAsync();
        Task<IEnumerable<Course>> GetStudentCoursesAsync(int studentId);
    }
}
