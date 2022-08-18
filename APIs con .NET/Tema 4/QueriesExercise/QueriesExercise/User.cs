using System.ComponentModel.DataAnnotations;

namespace QueriesExercise
{
    public class User
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required, StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
