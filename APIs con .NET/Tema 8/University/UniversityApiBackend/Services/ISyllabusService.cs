using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface ISyllabusService
    {
        IEnumerable<Syllabus> GetCourseSyllabus(int courseId);
    }
}
