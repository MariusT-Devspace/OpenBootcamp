using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class CategoriesService : ICategoriesService
    {
        private UniversityDBContext _dbContext;
        private readonly ILogger<CategoriesService> _logger;

        public CategoriesService(UniversityDBContext dbContext, ILogger<CategoriesService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Course>> GetCategoryCoursesAsync(int categoryId)
        {
            _logger.LogInformation("{Service} - {Method}", nameof(CategoriesService), nameof(GetCategoryCoursesAsync));
            _logger.LogInformation("Category id: {CategoryId}", categoryId);

            return await (from category in _dbContext.Categories
                          where category.Id == categoryId
                          select category.Courses).SingleAsync<IEnumerable<Course>>();
        }
    }
}
