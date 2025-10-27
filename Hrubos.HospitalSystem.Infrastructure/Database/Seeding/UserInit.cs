using Hrubos.HospitalSystem.Infrastructure.Identity;

namespace Hrubos.HospitalSystem.Infrastructure.Database.Seeding
{
    internal class UserInit
    {
        public User GetAdmin()
        {
            return new User
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
                SecurityStamp = Guid.NewGuid().ToString("N"),
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = true,
                AccessFailedCount = 0
            };
        }


        public List<User> GetDoctors()
        {
            return new List<User>()
            {
                new User
                {
                    Id = 2,
                    FirstName = "Jan",
                    LastName = "Novák",
                    UserName = "doctor1",
                    NormalizedUserName = "DOCTOR1",
                    Email = "jan.novak@nemocnice.cz",
                    NormalizedEmail = "JAN.NOVAK@NEMOCNICE.CZ",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAECxrKr4YAVakrkIYFy7MgUA11ryq0Sgun00+cj9FnR6EHzH8EL9WRc3J60f5x2nv0g==",
                    SecurityStamp = Guid.NewGuid().ToString("N"),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    PhoneNumber = "111222333",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    SpecializationId = 1,
                    MaxExaminationPerDay = 10
                },
                new User
                {
                    Id = 3,
                    FirstName = "Petr",
                    LastName = "Svoboda",
                    UserName = "doctor2",
                    NormalizedUserName = "DOCTOR2",
                    Email = "petr.svoboda@nemocnice.cz",
                    NormalizedEmail = "PETR.SVOBODA@NEMOCNICE.CZ",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEK4DkND+5IwQiNI01DelkSwKPGQnzZAxCmobmvF3J0w5Xr6YO4bUtzjJwe2qRzUv7g==",
                    SecurityStamp = Guid.NewGuid().ToString("N"),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    PhoneNumber = "222333444",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    SpecializationId = 2,
                    MaxExaminationPerDay = 5
                },
                new User
                {
                    Id = 4,
                    FirstName = "Lucie",
                    LastName = "Dvořáková",
                    UserName = "doctor3",
                    NormalizedUserName = "DOCTOR3",
                    Email = "lucie.dvorakova@nemocnice.cz",
                    NormalizedEmail = "LUCIE.DVORAKOVA@NEMOCNICE.CZ",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEMK02V+4Wdm0lgraNwSBHPhhYUFmVpoCrp103XwzNXTFK6/s8xx0AAdpsd2G2KquQQ==",
                    SecurityStamp = Guid.NewGuid().ToString("N"),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    PhoneNumber = "333444555",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    SpecializationId = 3,
                    MaxExaminationPerDay = 2
                },
                new User
                {
                    Id = 5,
                    FirstName = "Arnošt",
                    LastName = "Pátek",
                    UserName = "doctor4",
                    NormalizedUserName = "DOCTOR4",
                    Email = "arnost.patek@nemocnice.cz",
                    NormalizedEmail = "ARNOST.PATEK@NEMOCNICE.CZ",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEGrcdYyAHwCXTbk9VS3VItkcEq4bhgiPBFetA8rLbp/6Asw87PI2TqWE5csu8u6TDA==",
                    SecurityStamp = Guid.NewGuid().ToString("N"),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    PhoneNumber = "444555666",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    SpecializationId = 2,
                    MaxExaminationPerDay = 0
                }
            };
        }

        public List<User> GetPatients()
        {
            return new List<User>()
            {
                new User
                {
                    Id = 6,
                    FirstName = "Tomáš",
                    LastName = "Horák",
                    UserName = "patient1",
                    NormalizedUserName = "PACIENT1",
                    Email = "tomas.horak@email.cz",
                    NormalizedEmail = "TOMAS.HORAK@EMAIL.CZ",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEBacwHfAQ8oysuC+yEOFP2TakEie2+73wHf89V+TJX+Ioy5NfCTZkS0U/P5kN7yjmg==",
                    SecurityStamp = Guid.NewGuid().ToString("N"),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    PhoneNumber = "601111111",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    BirthNumber = "900101/1234"
                },
                new User
                {
                    Id = 7,
                    FirstName = "Anna",
                    LastName = "Malá",
                    UserName = "patient2",
                    NormalizedUserName = "PACIENT2",
                    Email = "anna.mala@email.cz",
                    NormalizedEmail = "ANNA.MALA@EMAIL.CZ",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEK31Pd3GzmAcXrVtoSezhRdeqGp0l5c6Zl0IjUvn6vAeslrjG7bgOuN4jHqQBRDbZA==",
                    SecurityStamp = Guid.NewGuid().ToString("N"),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    PhoneNumber = "602222222",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    BirthNumber = "950202/2345"
                },
                new User
                {
                    Id = 8,
                    FirstName = "Karel",
                    LastName = "Novotný",
                    UserName = "patient3",
                    NormalizedUserName = "PACIENT3",
                    Email = "karel.novotny@email.cz",
                    NormalizedEmail = "KAREL.NOVOTNY@EMAIL.CZ",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEGDwHucn5uWF1684moFrwbqoaym+z0IHUiN+/EDQnXgz6HiEbGnaqFT136phybDc4g==",
                    SecurityStamp = Guid.NewGuid().ToString("N"),
                    ConcurrencyStamp = Guid.NewGuid().ToString("D"),
                    PhoneNumber = "603333333",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    BirthNumber = "880303/3456"
                }
            };
        }
    }
}
