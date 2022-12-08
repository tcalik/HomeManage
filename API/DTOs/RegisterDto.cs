using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,64}$", ErrorMessage = "Password complexity requirements not met") ]
        public string Password { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
