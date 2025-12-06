using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Hrubos.HospitalSystem.Application.Implementation
{
    public class SecurityIdentityService : ISecurityIdentityService
    {
        private readonly UserManager<User> _userManager;

        public SecurityIdentityService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<IList<string>> GetRolesAsync(string userId)
        {
            var user = await GetUserByIdAsync(userId);
            if (user != null)
            {
                return await _userManager.GetRolesAsync(user);
            }
            return new List<string>();
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<User> GetCurrentUserAsync(ClaimsPrincipal principal)
        {
            var userId = _userManager.GetUserId(principal);

            if (string.IsNullOrEmpty(userId))
            {
                return null;
            }

            return await _userManager.Users
                .Include(u => u.Specialization)
                .FirstOrDefaultAsync(u => u.Id == int.Parse(userId));
        }

        public async Task<bool> EditUserAsync(User user)
        {
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = await GetUserByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                return result.Succeeded;
            }
            return false;
        }
    }
}
