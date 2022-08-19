using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueriesExercise
{
    public class Course
    {
        public enum CourseLevel
        {
            Basic = 1,
            Medium,
            Advanced,
            Expert
        }

        public string Name { get; set; } = string.Empty;

        public string? ShortDescription { get; set; }

        public string? LongDescription { get; set; }

        public string? TargetAudience { get; set; }

        public string? Goals { get; set; }

        public string? Requirements { get; set; }

        public CourseLevel? Level { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
     
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
