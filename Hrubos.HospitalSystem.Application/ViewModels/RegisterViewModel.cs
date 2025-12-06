using Hrubos.HospitalSystem.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace Hrubos.HospitalSystem.Application.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string? UserName { get; set; }

        [FirstLetterCapitalized]
        public string? FirstName { get; set; }

        [FirstLetterCapitalized]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Zadaný formát e-mailové adresy není platný.")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Zadaný formát telefonního čísla není platný.")]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Hesla se neshodují!")]
        public string? RepeatedPassword { get; set; }
    }
}
