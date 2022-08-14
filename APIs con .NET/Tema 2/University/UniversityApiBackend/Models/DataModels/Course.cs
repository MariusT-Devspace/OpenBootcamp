using System.ComponentModel.DataAnnotations;

namespace UniversityApiBackend.Models.DataModels
{
    public class Course: BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(280)]
        public string? ShortDescription { get; set; }

        public string? LongDescription { get; set; }

        public string? TargetAudience { get; set; }

        public string? Goals { get; set; }

        public string? Requirements { get; set; }

        public enum Level
        {
            Básico = 1,
            Intermedio,
            Avanzado
        }

    }
}
