using Microsoft.AspNetCore.Identity;

namespace Hrubos.HospitalSystem.Infrastructure.Database.Seeding
{
    internal class UserRolesInit
    {
        public List<IdentityUserRole<int>> GetRoles()
        {
            return new List<IdentityUserRole<int>>()
            {
                // Admin
                new IdentityUserRole<int> { UserId = 1, RoleId = 1 }, // Admin
                //new IdentityUserRole<int> { UserId = 1, RoleId = 2 }, // Doctor
                //new IdentityUserRole<int> { UserId = 1, RoleId = 3 }, // Patient

                // Doktoři
                new IdentityUserRole<int> { UserId = 2, RoleId = 2 }, // Doctor
                //new IdentityUserRole<int> { UserId = 2, RoleId = 3 }, // Patient

                new IdentityUserRole<int> { UserId = 3, RoleId = 2 },
                //new IdentityUserRole<int> { UserId = 3, RoleId = 3 },

                new IdentityUserRole<int> { UserId = 4, RoleId = 2 },
                //new IdentityUserRole<int> { UserId = 4, RoleId = 3 },

                new IdentityUserRole<int> { UserId = 5, RoleId = 2 },
                //new IdentityUserRole<int> { UserId = 5, RoleId = 3 },

                // Pacienti
                new IdentityUserRole<int> { UserId = 6, RoleId = 3 }, // Patient

                new IdentityUserRole<int> { UserId = 7, RoleId = 3 },

                new IdentityUserRole<int> { UserId = 8, RoleId = 3 }
            };
        }
    }
}
