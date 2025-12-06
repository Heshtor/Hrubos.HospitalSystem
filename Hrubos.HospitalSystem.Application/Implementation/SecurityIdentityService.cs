using Hrubos.HospitalSystem.Application.Abstraction;
using Hrubos.HospitalSystem.Infrastructure.Identity;
using Hrubos.HospitalSystem.Infrastructure.Identity.Enums;
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
            return await _userManager.Users
                .Include(u => u.Specialization)
                .ToListAsync();
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
            var userInDb = await _userManager.FindByIdAsync(user.Id.ToString());
            if (userInDb == null) return false;

            userInDb.FirstName = user.FirstName;
            userInDb.LastName = user.LastName;
            userInDb.Email = user.Email;
            userInDb.PhoneNumber = user.PhoneNumber;
            userInDb.BirthNumber = user.BirthNumber;

            // Pokud má uživatel roli Doctor, aktualizuji specializaci a limit
            if (user.RoleName == nameof(Roles.Doctor))
            {
                userInDb.SpecializationId = user.SpecializationId;
                userInDb.MaxExaminationPerDay = user.MaxExaminationPerDay;
            }
            else // jinak nuluji
            {
                userInDb.SpecializationId = null;
                userInDb.MaxExaminationPerDay = 0;
            }

            // Změna údajů uživatele
            var result = await _userManager.UpdateAsync(userInDb);
            if (!result.Succeeded) return false;

            // Změna role uživatele
            if (!string.IsNullOrEmpty(user.RoleName))
            {
                var currentRoles = await _userManager.GetRolesAsync(userInDb);
                if (!currentRoles.Contains(user.RoleName))
                {
                    await _userManager.RemoveFromRolesAsync(userInDb, currentRoles);
                    await _userManager.AddToRoleAsync(userInDb, user.RoleName);
                }
            }

            return true;
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
