using Hrubos.HospitalSystem.Application.ViewModels;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;

namespace Hrubos.HospitalSystem.Application.Abstraction
{
    public interface IAccountIdentityService
    {
        Task<bool> Login(LoginViewModel vm);
        Task Logout();

        Task<string[]> Register(RegisterViewModel vm, params Roles[] roles);
    }
}
