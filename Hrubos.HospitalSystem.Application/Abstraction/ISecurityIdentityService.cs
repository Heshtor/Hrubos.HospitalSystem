using System.Security.Claims;
using Hrubos.HospitalSystem.Infrastructure.Identity;

namespace Hrubos.HospitalSystem.Application.Abstraction
{
    public interface ISecurityIdentityService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<IList<string>> GetRolesAsync(string userId);
        Task<User> GetUserByIdAsync(string userId);
        Task<User> GetCurrentUserAsync(ClaimsPrincipal principal);
        Task<bool> EditUserAsync(User user);
        Task<bool> DeleteUserAsync(string userId);
    }
}
