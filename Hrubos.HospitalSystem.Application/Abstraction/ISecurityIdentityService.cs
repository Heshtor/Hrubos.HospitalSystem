using System.Security.Claims;
using Hrubos.HospitalSystem.Infrastructure.Identity;

namespace Hrubos.HospitalSystem.Application.Abstraction
{
    public interface ISecurityIdentityService
    {
        Task<User> FindUserByUsername(string username);
        Task<User> FindUserByEmail(string email);
        Task<IList<string>> GetUserRoles(User user);
        Task<User> GetCurrentUser(ClaimsPrincipal principal);
    }
}
