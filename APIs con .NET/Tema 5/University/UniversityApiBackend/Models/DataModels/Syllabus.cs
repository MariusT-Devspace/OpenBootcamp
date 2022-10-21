using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApiBackend.Models.DataModels
{
    public class Syllabus: BaseEntity {
        [Required]
        public string List { get; set; } = string.Empty;
    }
}
