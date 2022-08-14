using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApiBackend.Models.DataModels
{
    public class Course: BaseEntity
    {
        public enum CourseLevel
        {
            Básico = 1,
            Intermedio,
            Avanzado
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

    }
}
