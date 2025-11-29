using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Infrastructure.Identity;

namespace Hrubos.HospitalSystem.Application.Implementation
{
    public class SecurityIdentityService : ISecurityIdentityService
    {
        UserManager<User> userManager;

        public SecurityIdentityService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public Task<User> FindUserByEmail(string email)
        {
            return userManager.FindByEmailAsync(email);
        }

        public Task<User> FindUserByUsername(string username)
        {
            return userManager.FindByNameAsync(username);
        }

        public Task<IList<string>> GetUserRoles(User user)
        {
            return userManager.GetRolesAsync(user);
        }

        public Task<User> GetCurrentUser(ClaimsPrincipal principal)
        {
            return userManager.GetUserAsync(principal);
        }
    }
}
