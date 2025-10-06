using Hrubos.HospitalSystem.Domain.Entities;

namespace Hrubos.HospitalSystem.Infrastructure.Database.Seeding
{
    internal class PatientInit
    {
        public List<Patient> GeneratePatients()
        {
            return new List<Patient>()
            {
                new Patient
                {
                    Id = 1,
                    UserName = "pacient1",
                    FirstName = "Tomáš",
                    LastName = "Horák",
                    Email = "tomas.horak@email.cz",
                    PhoneNumber = "601111111",
                    BirthNumber = "900101/1234"
                },
                new Patient
                {
                    Id = 2,
                    UserName = "pacient2",
                    FirstName = "Anna",
                    LastName = "Malá",
                    Email = "anna.mala@email.cz",
                    PhoneNumber = "602222222",
                    BirthNumber = "950202/2345"
                },
                new Patient
                {
                    Id = 3,
                    UserName = "pacient3",
                    FirstName = "Karel",
                    LastName = "Novotný",
                    Email = "karel.novotny@email.cz",
                    PhoneNumber = "603333333",
                    BirthNumber = "880303/3456"
                }
            };
        }
    }
}
