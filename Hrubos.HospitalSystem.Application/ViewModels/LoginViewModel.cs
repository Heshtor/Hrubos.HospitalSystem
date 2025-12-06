using System.ComponentModel.DataAnnotations;

namespace Hrubos.HospitalSystem.Application.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }

        public bool LoginFailed { get; set; }
    }
}
