using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApiBackend.Models.DataModels
{
    public class Course: BaseEntity
    {
        public enum CourseLevel
        {
            Basic = 1,
            Medium,
            Advanced,
            Expert
        }

        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(280)]
        public string? ShortDescription { get; set; }

        public string? LongDescription { get; set; }

        public string? TargetAudience { get; set; }

        public string? Goals { get; set; }

        public string? Requirements { get; set; }

        public CourseLevel? Level { get; set; }

        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();
     
        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();

        [Required]
        public virtual Syllabus Syllabus { get; set; } = new Syllabus();
    }
}
