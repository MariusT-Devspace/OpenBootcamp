using System.ComponentModel.DataAnnotations;

namespace QueriesExercise
{
    public class Student
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime Dob { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
