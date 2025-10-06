using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Infrastructure.Database.Seeding
{
    internal class DoctorInit
    {
        public List<Doctor> GenerateDoctors()
        {
            return new List<Doctor>()
            {
                new Doctor
                {
                    Id = 1,
                    UserName = "doktor1",
                    FirstName = "Jan",
                    LastName = "Novák",
                    Email = "jan.novak@nemocnice.cz",
                    PhoneNumber = "111222333",
                    SpecializationId = 1
                },
                new Doctor
                {
                    Id = 2,
                    UserName = "doktor2",
                    FirstName = "Petr",
                    LastName = "Svoboda",
                    Email = "petr.svoboda@nemocnice.cz",
                    PhoneNumber = "222333444",
                    SpecializationId = 2
                },
                new Doctor
                {
                    Id = 3,
                    UserName = "doktor3",
                    FirstName = "Lucie",
                    LastName = "Dvořáková",
                    Email = "lucie.dvorakova@nemocnice.cz",
                    PhoneNumber = "333444555",
                    SpecializationId = 3
                },
                new Doctor
                {
                    Id = 4,
                    UserName = "doktor4",
                    FirstName = "Arnošt",
                    LastName = "Pátek",
                    Email = "arnost.patek@nemocnice.cz",
                    PhoneNumber = "444555666",
                    SpecializationId = 2
                }
            };
        }
    }
}
