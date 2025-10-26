using System.ComponentModel.DataAnnotations;

namespace Hrubos.HospitalSystem.Application.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string? Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Hesla se neshodují!")]
        public string? RepeatedPassword { get; set; }
    }
}
