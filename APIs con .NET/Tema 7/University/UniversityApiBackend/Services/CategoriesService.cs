using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class CategoriesService : ICategoriesService
    {
        private UniversityDBContext _dbContext;

        public CategoriesService(UniversityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Course>> GetCategoryCoursesAsync(int categoryId)
        {
            return await (from category in _dbContext.Categories
                          where category.Id == categoryId
                          select category.Courses).SingleAsync<IEnumerable<Course>>();
        }
    }
}
