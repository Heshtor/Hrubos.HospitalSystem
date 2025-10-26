using Hrubos.HospitalSystem.Infrastructure.Identity;

namespace Hrubos.HospitalSystem.Infrastructure.Database.Seeding
{
    internal class UserInit
    {
        public User GetAdmin()
        {
            User admin = new User()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Martin",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.cz",
                NormalizedEmail = "ADMIN@ADMIN.CZ",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEC4prnSMIdRUykdd65G87+g3lLCc9cqJ/re6T1TsQFv5xlMrmVIe4k7yMQiEYWpH3A==",
                SecurityStamp = "SEJEPXC646ZBNCDYSM3H5FRK5RWP2TN6",
                ConcurrencyStamp = "b09a83ae-cfd3-4ee7-97e6-fbcf0b0fe78c",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            return admin;
        }


        public User GetDoctor()
        {
            User doctor = new User()
            {
                Id = 2,
                FirstName = "Doktor",
                LastName = "Jedna",
                UserName = "doctor1",
                NormalizedUserName = "DOCTOR1",
                Email = "doctor1@doctor.cz",
                NormalizedEmail = "DOCTOR1@DOCTOR.CZ",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAECxrKr4YAVakrkIYFy7MgUA11ryq0Sgun00+cj9FnR6EHzH8EL9WRc3J60f5x2nv0g==",
                SecurityStamp = "MAJXOSATJKOEM4YFF32Y5G2XPR5OFEL6",
                ConcurrencyStamp = "7a8d96fd-5918-441b-b800-cbafa99de97b",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };

            return doctor;
        }
    }
}
