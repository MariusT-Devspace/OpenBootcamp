using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Course>> GetCategoryCoursesAsync(int categoryId);
    }
}
